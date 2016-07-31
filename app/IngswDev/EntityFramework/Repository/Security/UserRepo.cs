using System;
using IngswDev.EntityFramework.Models.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using IngswDev.Extensions;

namespace IngswDev.EntityFramework.Repository.Security
{
    public class UserRepo : Repository<User>
    {
        public UserRepo(IngswDevDB db, ILogger<Repository<User>> logger)
            : base(db, logger)
        {

        }

        public Task<User> FindAsync(string id)
        {
            return _db.Users.FirstOrDefaultAsync(key => key.Id.Equals(id));
        }

        public Task<int> CreateAsync(User user, string password)
        {
            user.Id = Guid.NewGuid().ToString("N");
            user.PasswordHash = password.ComputeHash();
            Add(user);
            return SaveAsync();
        }
    }
}
