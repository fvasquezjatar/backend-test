using IngswDev.EntityFramework.Map.Entities;
using IngswDev.EntityFramework.Map.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IngswDev.EntityFramework.Map
{
    public static class EntityTypeConfiguration
    {
        public static ModelBuilder AddCustomTypeConfigurations(this ModelBuilder modelBuilder)
        {
            // get all custom configurations and map one by one
            var configurations = modelBuilder.GetConfigurations();
            foreach (var cfg in configurations)
            {
                cfg.Map();
            }
            return modelBuilder;
        }

        private static IEnumerable<IEntityMap> GetConfigurations(this ModelBuilder modelBuilder)
        {
            // add custom IEntityMap configurations to be configure on Startup
            var configurations = new List<IEntityMap>
            {
                new UserMap(modelBuilder),
                new TokenMap(modelBuilder),
                new EventMap(modelBuilder),
                new EventDateMap(modelBuilder)
            };
            return configurations;
        }
    }
}
