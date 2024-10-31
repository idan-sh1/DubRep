using System.ComponentModel.DataAnnotations.Schema;

namespace DubRep.Models.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public int VoiceActorID { get; set; }
        public VoiceActor VoiceActor { get; set; } = null!;

        public int SeriesID { get; set; }
        public Series Series { get; set; } = null!;

        public required string[] Characters { get; set; }
    }
}
