using System.ComponentModel.DataAnnotations;

namespace Tryitter.API.Models.Tweet
{
    public class GetTweetDto : BaseTweetDto
    {
        [Required]
        public int Id { get; set; }
    }
}
