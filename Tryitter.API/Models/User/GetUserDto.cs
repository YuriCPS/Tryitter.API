using System.ComponentModel.DataAnnotations;

namespace Tryitter.API.Models.User
{
    public class GetUserDto : BaseUserDto
    {
        [Required]
        public int Id { get; set; }
    }    
}
