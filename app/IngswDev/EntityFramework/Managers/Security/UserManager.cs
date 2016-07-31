using IngswDev.EntityFramework.Managers.Scopes;
using IngswDev.EntityFramework.Repository.Security;
using IngswDev.Extensions;
using IngswDev.Models;
using System;
using System.Threading.Tasks;

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

        public async Task<bool> SignInAsync(LoginViewModel login)
        {
            if (string.IsNullOrEmpty(login?.Username) || string.IsNullOrEmpty(login.Password))
                return false;
            var username = login.Username;
            var passwordHash = login.Password.ComputeHash();
            return await _userRepo.SelectAsync(user => (user.Username.Equals(username) || user.Email.Equals(username))
                           && user.PasswordHash.Equals(passwordHash)) != null;
        }

        public Task<bool> CreateAsync(RegisterViewModel register)
        {
           throw new NotImplementedException();
        }

        public bool Authenticate(string userId, string accessToken)
        {
            var token = _tokenRepo.Find(accessToken);
            if (token == null || !token.UserId.Equals(userId))
                return false;
            return token.Expiration >= DateTime.UtcNow;
        }
    }
}
