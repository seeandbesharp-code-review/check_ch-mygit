using System.ComponentModel.DataAnnotations;

namespace MyWebApi
{
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
