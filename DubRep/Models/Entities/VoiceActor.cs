namespace DubRep.Models.Entities
{
    public class VoiceActor
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Country { get; set; }

        public ICollection<Role> Roles { get; } = new List<Role>();

        public string? ImageName { get; set; }
    }
}
