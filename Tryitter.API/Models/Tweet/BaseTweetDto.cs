using System.ComponentModel.DataAnnotations;

namespace Tryitter.API.Models.Tweet
{
    public class BaseTweetDto
    {
        [Required]
        [StringLength(300, ErrorMessage = "Tweet content cannot be longer than 300 characters.", MinimumLength = 1)]
        public string Content { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
