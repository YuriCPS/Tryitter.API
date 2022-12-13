using System.ComponentModel.DataAnnotations;

namespace Tryitter.API.Models.User
{
    public class GetUserDetailsDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Bio { get; set; }
        [Required]
        public int ModuleId { get; set; }
    }
}
