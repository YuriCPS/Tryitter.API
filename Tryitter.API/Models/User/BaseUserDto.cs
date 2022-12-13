using System.ComponentModel.DataAnnotations;

namespace Tryitter.API.Models.User
{
    public class BaseUserDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
