using System.ComponentModel.DataAnnotations;

namespace MyWebApi
{
    public class LoginUser
    {
        [Required]
        public string password { get; set; }
        [EmailAddress]
        public string email { get; set; }
    }
}
