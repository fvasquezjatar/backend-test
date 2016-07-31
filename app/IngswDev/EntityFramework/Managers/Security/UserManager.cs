using IngswDev.EntityFramework.Managers.Scopes;
using IngswDev.EntityFramework.Repository.Security;

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
    }
}
