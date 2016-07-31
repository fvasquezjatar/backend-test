using System.Threading.Tasks;
using IngswDev.EntityFramework.Models.Security;
using IngswDev.Models;

namespace IngswDev.EntityFramework.Managers.Scopes
{
    public interface IUserManager
    {
        // async methods
        Task<Token> SignInAsync(LoginViewModel login);
        Task<Token> CreateAsync(RegisterViewModel register);
        // not async methods
        bool Authenticate(string userId, string token);
    }
}
