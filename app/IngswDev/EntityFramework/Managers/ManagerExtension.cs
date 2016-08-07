using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IngswDev.EntityFramework.Models.Entities;
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
                config.CreateMap<EventViewModel, Event>()
                    .ForMember(m => m.TargetDates, cfg => cfg.MapFrom(e => new HashSet<EventDate>(e.TargetDates.Select(s => new EventDate()
                    {
                        TargetDate = s,
                        TimeZone = "Eastern Standard Time",
                        Deleted = false
                    }).ToList())));
            });
        }
    }
}
