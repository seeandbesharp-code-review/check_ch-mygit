using System.ComponentModel.DataAnnotations;

namespace MyWebApi
{
    //In C#, public properties are written in PascalCase (UserId, FirstName, LastName, Password, Email).
    //If you rename them, text.txt still has the old names, so read it with
    //new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
    public class User
    {
        [Required]
        public int userId { get; set; }
        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }
        [Required]
        public string password { get; set; }
        [EmailAddress]
        public string email { get; set; }

    }
}
