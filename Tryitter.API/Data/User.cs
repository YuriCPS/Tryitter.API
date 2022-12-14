using System.ComponentModel.DataAnnotations.Schema;

namespace Tryitter.API.Data
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }

        [ForeignKey(nameof(ModuleId))]
        public int ModuleId { get; set; }
        public Module Module { get; set; }
    }
}
