using DubRep.Models.Entities;

namespace DubRep.Models.DTOs
{
    public class UpdateRoleDTO
    {
        public int VoiceActorID { get; set; }

        public int SeriesID { get; set; }

        public required string[] Characters { get; set; }
    }
}
