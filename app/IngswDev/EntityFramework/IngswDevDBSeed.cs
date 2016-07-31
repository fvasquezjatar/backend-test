using System;
using IngswDev.EntityFramework.Models.Security;
using IngswDev.Extensions;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace IngswDev.EntityFramework
{
    public class IngswDevDBSeed : IIngswDevDBSeed
    {
        private readonly ILogger<IngswDevDBSeed> _logger;
        private readonly IngswDevDB _db;

        public IngswDevDBSeed(IngswDevDB db, ILogger<IngswDevDBSeed> logger)
        {
            _logger = logger;
            _db = db;
        }

        public Task SeedAsync()
        {
            if (_db == null)
                return Task.FromResult(0);
            _logger?.LogInformation("Running Seed method...");
            if (!_db.Users.Any(usr => usr.Email.Equals("admin@admin.com")))
            {
                _db.Users.Add(new User()
                {
                    Id = Guid.NewGuid().ToString("N"),
                    Email = "admin@admin.com",
                    Username = "administrator",
                    Name = "Administrator",
                    PasswordHash = "12345678".ComputeHash()
                });
                _db.SaveChangesAsync();
            }
            _logger?.LogInformation("Seed has completed");
            return Task.FromResult(0);
        }
    }
}
