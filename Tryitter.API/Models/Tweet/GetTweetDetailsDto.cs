using System.ComponentModel.DataAnnotations;

namespace Tryitter.API.Models.Tweet
{
    public class GetTweetDetailsDto : BaseTweetDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
