using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Tryitter.API.Data
{
    public class Tweet
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}