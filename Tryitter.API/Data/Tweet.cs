using System.ComponentModel.DataAnnotations.Schema;

namespace Tryitter.API.Data
{
    public class Tweet
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

  
        public int UserId { get; set; }
        public User User { get; set; }
    }
}