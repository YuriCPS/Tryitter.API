namespace Tryitter.API.Data
{
    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual IList<User> Users { get; set; }
    }
}