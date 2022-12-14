using System.ComponentModel.DataAnnotations;

namespace Tryitter.API.Models.Tweet
{
    public class UpdateTweetDto : BaseTweetDto
    {
        [Required]
        public int Id { get; set; }
    }
}
