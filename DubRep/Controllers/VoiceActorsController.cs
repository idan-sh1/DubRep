using DubRep.Data;
using DubRep.Models.DTOs;
using DubRep.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DubRep.Controllers
{
    // localhost:xxx/api/voiceactors
    [Route("api/[controller]")]
    [ApiController]
    public class VoiceActorsController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public VoiceActorsController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllVoiceActors()
        {
            // 200 OK with the voice actors list in the response body
            return Ok(dbContext.VoiceActors.Include(_ => _.Roles).ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<VoiceActor> GetVoiceActorById(int id)
        {
            var voiceActor = dbContext.VoiceActors.Include(_ => _.Roles).Where(_ => _.Id == id).FirstOrDefault();
            if (voiceActor == null)
            {
                // 404 Not Found if the voice actor does not exist
                return NotFound();
            }

            // 200 OK with the voice actor in the response body
            return Ok(voiceActor);
        }

        [HttpPost]
        public IActionResult AddVoiceActor(AddVoiceActorDTO addVoiceActorDTO)
        {
            var voiceActorEntity = new VoiceActor()
            {
                Name = addVoiceActorDTO.Name,
                Country = addVoiceActorDTO.Country,
                ImageName = addVoiceActorDTO.ImageName
            };

            dbContext.VoiceActors.Add(voiceActorEntity);
            dbContext.SaveChanges();

            // 201 Created with the voice actor in the response body
            return CreatedAtAction(nameof(GetVoiceActorById), new { id =  voiceActorEntity.Id }, voiceActorEntity);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVoiceActor(int id, UpdateVoiceActorDTO updateVoiceActorDTO)
        {
            var voiceActor = dbContext.VoiceActors.Include(_ => _.Roles).Where(_ => _.Id == id).FirstOrDefault();
            if (voiceActor == null)
            {
                // 404 Not Found if the voice actor does not exist
                return NotFound();
            }

            voiceActor.Name = updateVoiceActorDTO.Name;
            voiceActor.Country = updateVoiceActorDTO.Country;
            voiceActor.ImageName = updateVoiceActorDTO.ImageName;

            dbContext.SaveChanges();

            // 200 OK with the voice actor in the response body
            return Ok(voiceActor);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVoiceActor(int id)
        {
            var voiceActor = dbContext.VoiceActors.Include(_ => _.Roles).Where(_ => _.Id == id).FirstOrDefault();
            if (voiceActor == null)
            {
                // 404 Not Found if the voice actor does not exist
                return NotFound();
            }

            dbContext.VoiceActors.Remove(voiceActor);
            dbContext.SaveChanges();

            return NoContent();
        }
    }
}
