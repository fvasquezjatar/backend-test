using System;
using System.Collections.Generic;
using IngswDev.EntityFramework.Models.Security;
using IngswDev.Extensions;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using IngswDev.EntityFramework.Models.Entities;

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
            if (!_db.Events.Any())
            {
                _db.Events.Add(new Event()
                {
                    Title = "Pool Party",
                    Description = "Pool Party at Miami Beach",
                    Highlight = true,
                    ImageUri = "http://2.bp.blogspot.com/-FhsgZvMDCtQ/UdtTmCbzzII/AAAAAAAAFOo/EMk6jZV5nIs/s1600/pool-party-miami-south-beach.jpg",
                    TargetDates = new List<EventDate>()
                    {
                        new EventDate()
                        {
                            TargetDate = DateTime.Now.AddDays(35),
                            TimeZone = "Eastern Standard Time",
                            Deleted = false
                        },
                        new EventDate()
                        {
                            TargetDate = DateTime.Now.AddDays(15),
                            TimeZone = "Eastern Standard Time",
                            Deleted = false
                        }
                    }
                });
                _db.Events.Add(new Event()
                {
                    Title = "Cancun Pool Party",
                    Description = "Pool Party at Cancun",
                    Highlight = true,
                    ImageUri = "https://i.ytimg.com/vi/lbhF0pL_7a0/maxresdefault.jpg",
                    TargetDates = new List<EventDate>()
                    {
                        new EventDate()
                        {
                            TargetDate = DateTime.Now.AddDays(35),
                            TimeZone = "Eastern Standard Time",
                            Deleted = false
                        },
                        new EventDate()
                        {
                            TargetDate = DateTime.Now.AddDays(15),
                            TimeZone = "Eastern Standard Time",
                            Deleted = false
                        }
                    }
                });
                _db.Events.Add(new Event()
                {
                    Title = "Cancun Pool Party",
                    Description = "Pool Party at Cancun",
                    Highlight = true,
                    ImageUri = "https://i.ytimg.com/vi/lbhF0pL_7a0/maxresdefault.jpg",
                    TargetDates = new List<EventDate>()
                    {
                        new EventDate()
                        {
                            TargetDate = DateTime.Now.AddDays(35),
                            TimeZone = "Eastern Standard Time",
                            Deleted = false
                        },
                        new EventDate()
                        {
                            TargetDate = DateTime.Now.AddDays(15),
                            TimeZone = "Eastern Standard Time",
                            Deleted = false
                        }
                    }
                });
                _db.Events.Add(new Event()
                {
                    Title = "Cancun Pool Party",
                    Description = "Pool Party at Cancun",
                    Highlight = true,
                    ImageUri = "https://i.ytimg.com/vi/lbhF0pL_7a0/maxresdefault.jpg",
                    TargetDates = new List<EventDate>()
                    {
                        new EventDate()
                        {
                            TargetDate = DateTime.Now.AddDays(35),
                            TimeZone = "Eastern Standard Time",
                            Deleted = false
                        },
                        new EventDate()
                        {
                            TargetDate = DateTime.Now.AddDays(15),
                            TimeZone = "Eastern Standard Time",
                            Deleted = false
                        }
                    }
                });
                _db.Events.Add(new Event()
                {
                    Title = "Cancun Pool Party",
                    Description = "Pool Party at Cancun",
                    Highlight = true,
                    ImageUri = "https://i.ytimg.com/vi/lbhF0pL_7a0/maxresdefault.jpg",
                    TargetDates = new List<EventDate>()
                    {
                        new EventDate()
                        {
                            TargetDate = DateTime.Now.AddDays(35),
                            TimeZone = "Eastern Standard Time",
                            Deleted = false
                        },
                        new EventDate()
                        {
                            TargetDate = DateTime.Now.AddDays(15),
                            TimeZone = "Eastern Standard Time",
                            Deleted = false
                        }
                    }
                });
                _db.Events.Add(new Event()
                {
                    Title = "Cancun Pool Party",
                    Description = "Pool Party at Cancun",
                    Highlight = true,
                    ImageUri = "https://i.ytimg.com/vi/lbhF0pL_7a0/maxresdefault.jpg",
                    TargetDates = new List<EventDate>()
                    {
                        new EventDate()
                        {
                            TargetDate = DateTime.Now.AddDays(35),
                            TimeZone = "Eastern Standard Time",
                            Deleted = false
                        },
                        new EventDate()
                        {
                            TargetDate = DateTime.Now.AddDays(15),
                            TimeZone = "Eastern Standard Time",
                            Deleted = false
                        }
                    }
                });
                _db.SaveChangesAsync();
            }
            _logger?.LogInformation("Seed has completed");
            return Task.FromResult(0);
        }
    }
}
