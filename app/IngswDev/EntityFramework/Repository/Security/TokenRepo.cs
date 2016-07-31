using System;
using System.Linq;
using IngswDev.EntityFramework.Models.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace IngswDev.EntityFramework.Repository.Security
{
    public class TokenRepo : Repository<Token>
    {
        public TokenRepo(IngswDevDB db, ILogger<Repository<Token>> logger)
            : base(db, logger)
        {
        }

        public Task<Token> Find(long id)
        {
            return _db.AccessTokens.FirstOrDefaultAsync(key => key.Id.Equals(id));
        }

        public Token Find(string token)
        {
            return _db.AccessTokens.FirstOrDefault(tk => tk.AccessToken.Equals(token));
        }

        public async Task<Token> CreateNewAccessAsync(User user)
        {
            var token = new Token()
            {
                AccessToken = Guid.NewGuid().ToString("D"),
                Expiration = DateTime.Now.AddMinutes(30),
                User = user,
                UserId = user.Id,
            };
            Add(token);
            await SaveAsync();
            return token;
        }
    }
}
