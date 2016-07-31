using System.Threading.Tasks;
using IngswDev.EntityFramework.Models.Security;
using IngswDev.Models;

namespace IngswDev.EntityFramework.Managers.Scopes
{
    public interface IUserManager
    {
        // async methods
        Task<bool> SignInAsync(LoginViewModel login);
        Task<bool> CreateAsync(RegisterViewModel register);
        // not async methods
        bool Authenticate(string userId, string token);
    }
}
