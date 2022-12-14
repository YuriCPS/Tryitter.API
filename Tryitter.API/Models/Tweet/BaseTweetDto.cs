using System.ComponentModel.DataAnnotations;

namespace Tryitter.API.Models.Tweet
{
    public class BaseTweetDto
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
