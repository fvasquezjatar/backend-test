using System.Threading.Tasks;
using IngswDev.EntityFramework.Models.Security;
using IngswDev.Models;

namespace IngswDev.EntityFramework.Managers.Scopes
{
    public interface IUserManager
    {
        // async methods
        Task<string> SignInAsync(LoginViewModel login);
        Task<string> CreateAsync(RegisterViewModel register);
        Task<User> FindByIdAsync(string userId);
        // not async methods
        bool Authenticate(string userId, string token);
        Task<Token> AllowAccess(string userId);
    }
}
