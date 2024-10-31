using DubRep.Models.Entities;

namespace DubRep.Models.DTOs
{
    public class AddVoiceActorDTO
    {
        public required string Name { get; set; }

        public required string Country { get; set; }

        public string? ImageName { get; set; }
    }
}
