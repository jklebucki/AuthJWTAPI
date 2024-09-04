using System;

namespace AuthJWTAPI.Models
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Username { get; set; } = string.Empty;   
        public string Password { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = new List<string>();
        
    }
}
