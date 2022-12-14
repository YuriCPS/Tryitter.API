using Tryitter.API.Models.User;

namespace Tryitter.API.Models.Module
{
    public class ModuleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public IList<GetUserDto> Users { get; set; }
    }
}
