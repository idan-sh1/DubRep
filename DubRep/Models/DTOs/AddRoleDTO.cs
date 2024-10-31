using DubRep.Models.Entities;

namespace DubRep.Models.DTOs
{
    public class AddRoleDTO
    {
        public int VoiceActorID { get; set; }

        public int SeriesID { get; set; }

        public required string[] Characters { get; set; }
    }
}
