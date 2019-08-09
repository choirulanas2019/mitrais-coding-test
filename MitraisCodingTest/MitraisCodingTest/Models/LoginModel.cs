using System.ComponentModel.DataAnnotations;

namespace MitraisCodingTest.Models
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
    }
}