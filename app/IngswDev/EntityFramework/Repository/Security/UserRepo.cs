using IngswDev.EntityFramework.Models.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace IngswDev.EntityFramework.Repository.Security
{
    public class UserRepo : Repository<UserRepo>
    {
        public UserRepo(IngswDevDB db, ILogger<Repository<UserRepo>> logger) 
            : base(db, logger)
        {

        }

        public Task<User> Find(string id)
        {
            return _db.Users.FirstOrDefaultAsync(key => key.Id.Equals(id));
        }
    }
}
