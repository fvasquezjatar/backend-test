using AutoMapper;
using IngswDev.EntityFramework.Models.Security;
using IngswDev.Extensions;
using IngswDev.Models;
using Microsoft.AspNetCore.Builder;

namespace IngswDev.EntityFramework.Managers
{
    public static class ManagerExtension
    {
        public static void AddMapperConfigurations(this IApplicationBuilder app)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<RegisterViewModel, User>()
                    .ForMember(m => m.PasswordHash, opt => opt.MapFrom(p => p.Password.ComputeHash()));
            });
        }
    }
}
