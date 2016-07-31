using IngswDev.EntityFramework.Managers.Scopes;
using IngswDev.EntityFramework.Repository.Security;
using IngswDev.Extensions;
using IngswDev.Models;
using System;
using System.Threading.Tasks;
using AutoMapper;
using IngswDev.EntityFramework.Models.Security;

namespace IngswDev.EntityFramework.Managers.Security
{
    public class UserManager : IUserManager
    {
        private readonly TokenRepo _tokenRepo;
        private readonly UserRepo _userRepo;

        public UserManager(UserRepo userRepo, TokenRepo tokenRepo)
        {
            _userRepo = userRepo;
            _tokenRepo = tokenRepo;
        }


        public static UserManager GetInstance()
        {
            var dbFactory = new IngswDevDBFactory();
            var db = dbFactory.Create();
            var userRepo = new UserRepo(db, null);
            var tokenRepo = new TokenRepo(db, null);
            return new UserManager(userRepo, tokenRepo);
        }

        public async Task<string> SignInAsync(LoginViewModel login)
        {
            if (string.IsNullOrEmpty(login?.Username) || string.IsNullOrEmpty(login.Password))
                return string.Empty;
            var username = login.Username;
            var passwordHash = login.Password.ComputeHash();
            var usr = await _userRepo.SelectAsync(user => (user.Username.Equals(username) || user.Email.Equals(username))
                           && user.PasswordHash.Equals(passwordHash));
            return usr != null ? usr.Id : string.Empty;
        }

        public async Task<string> CreateAsync(RegisterViewModel register)
        {
            var user = Mapper.Map<User>(register);
            user.Id = Guid.NewGuid().ToString("N");
            await _userRepo.CreateAsync(user, register.Password);
            return user.Id;
        }

        public Task<User> FindByIdAsync(string userId)
        {
            return _userRepo.FindAsync(userId);
        }

        public bool Authenticate(string userId, string accessToken)
        {
            var token = _tokenRepo.Find(accessToken);
            if (token == null || !token.UserId.Equals(userId))
                return false;
            return token.Expiration <= DateTime.UtcNow;
        }

        public async Task<Token> AllowAccess(string userId)
        {
            var user = await _userRepo.FindAsync(userId);
            if (user == null)
                return null;
            return await _tokenRepo.CreateNewAccessAsync(user);
        }
    }
}
