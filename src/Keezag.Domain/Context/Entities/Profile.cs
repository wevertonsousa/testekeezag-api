namespace Keezag.Domain.Context.Entities
{
    public class Profile
    {
        public int Type { get; set; }
        public string Avatar { get; set; }
        public string DocumentNumber { get; set; }
        public Address Address { get; set; }
    }
}
