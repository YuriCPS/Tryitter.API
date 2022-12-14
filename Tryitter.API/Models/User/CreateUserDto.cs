using System.ComponentModel.DataAnnotations;

namespace Tryitter.API.Models.User
{
    public class CreateUserDto : BaseUserDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Bio { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public int ModuleId { get; set; }
    }
}
