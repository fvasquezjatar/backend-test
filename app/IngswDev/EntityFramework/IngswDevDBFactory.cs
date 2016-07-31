using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace IngswDev.EntityFramework
{
    public class IngswDevDBFactory : IDbContextFactory<IngswDevDB>
    {
        public IngswDevDB Create()
        {
            var connString = Startup.Configuration["Data:SQLConnectionString"];
            var builder = new DbContextOptionsBuilder<IngswDevDB>()
                .UseSqlServer(connString);
            return new IngswDevDB(builder);
        }

        public IngswDevDB Create(DbContextFactoryOptions options)
        {
            var connString = Startup.Configuration["Data:SQLConnectionString"];
            var builder = new DbContextOptionsBuilder<IngswDevDB>()
                .UseSqlServer(connString);
            return new IngswDevDB(builder);
        }
    }
}
