using System.Collections.Generic;

namespace IngswDev.EntityFramework.Models.Security
{
    public class User : IEntity
    {
        public User()
        {
            AccessTokens = new HashSet<Token>();
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }

        public ICollection<Token> AccessTokens { get; set; }
    }
}
