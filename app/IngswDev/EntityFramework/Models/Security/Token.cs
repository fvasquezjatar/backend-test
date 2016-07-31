using System;

namespace IngswDev.EntityFramework.Models.Security
{
    public class Token : IEntity
    {
        public long Id { get; set; }
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
