using System.ComponentModel.DataAnnotations;

namespace Tryitter.API.Models.User
{
    public class GetUserDto
    {
        [Required]
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }    
}
