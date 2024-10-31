using Microsoft.Extensions.Hosting;

namespace DubRep.Models.Entities
{
    public class Series
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Country { get; set; }

        public ICollection<Role> Cast { get; } = new List<Role>();

        public string? ImageName { get; set; }
    }
}
