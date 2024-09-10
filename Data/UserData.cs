using AuthJWTAPI.Models;

namespace AuthJWTAPI.Data
{
    public class UserData
    {
        public static List<User> Users = new List<User>
        {
            new User { Id = Guid.NewGuid().ToString(), Username = "user1", Password = "password1", Roles = new List<string> { "User" } },
            new User { Id = Guid.NewGuid().ToString(), Username = "admin", Password = "password2", Roles = new List<string> { "Admin" } },
        };
    }
}
