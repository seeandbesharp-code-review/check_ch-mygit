using System.ComponentModel.DataAnnotations;

namespace MyWebApi
{
    //In C#, public properties are written in PascalCase (Password, Email)
    public class LoginUser
    {
        [Required]
        public string password { get; set; }
        [EmailAddress]
        public string email { get; set; }
    }
}
