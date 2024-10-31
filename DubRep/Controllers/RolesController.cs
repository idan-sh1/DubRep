using DubRep.Data;
using DubRep.Models.DTOs;
using DubRep.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DubRep.Controllers
{
    // localhost:xxx/api/roles
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public RolesController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllRoles()
        {
            // 200 OK with the roles list in the response body
            return Ok(dbContext.Roles.Include(_ => _.VoiceActor).Include(_ => _.Series).ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Role> GetRoleById(int id)
        {
            var role = dbContext.Roles.Include(_ => _.VoiceActor).Include(_ => _.Series).Where(_ => _.Id == id).FirstOrDefault();

            if (role == null)
            {
                // 404 Not Found if the role does not exist
                return NotFound();
            }
            // 200 OK with the role in the response body
            return Ok(role);
        }

        [HttpPost]
        public IActionResult AddRole(AddRoleDTO addRoleDTO)
        {
            // Find the voice actor and series by objects their ID's
            var voiceActor = dbContext.VoiceActors.Find(addRoleDTO.VoiceActorID);
            var series = dbContext.Series.Find(addRoleDTO.SeriesID);

            // Check that the role belong to a valid voice actor and series
            if (voiceActor == null || series == null)
            {
                // 404 Not Found if the voice actor or series does not exist
                return NotFound();
            }

            // Create new role entity
            var roleEntity = new Role()
            {
                VoiceActorID = addRoleDTO.VoiceActorID,
                SeriesID = addRoleDTO.SeriesID,
                Characters = addRoleDTO.Characters
            };

            dbContext.Roles.Add(roleEntity);

            dbContext.SaveChanges();

            // 201 Created with the role in the response body
            return CreatedAtAction(nameof(GetRoleById), new { id = roleEntity.Id }, roleEntity);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRole(int id, UpdateRoleDTO updateRoleDTO)
        {
            var role = dbContext.Roles.Include(_ => _.VoiceActor).Include(_ => _.Series).Where(_ => _.Id == id).FirstOrDefault();
            if (role == null)
            {
                // 404 Not Found if the role does not exist
                return NotFound();
            }

            role.VoiceActorID = updateRoleDTO.VoiceActorID;
            role.SeriesID = updateRoleDTO.SeriesID;
            role.Characters = updateRoleDTO.Characters;

            dbContext.SaveChanges();

            // 200 OK with the role in the response body
            return Ok(role);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            var role = dbContext.Roles.Include(_ => _.VoiceActor).Include(_ => _.Series).Where(_ => _.Id == id).FirstOrDefault();
            if (role == null)
            {
                // 404 Not Found if the role does not exist
                return NotFound();
            }

            dbContext.Roles.Remove(role);
            dbContext.SaveChanges();

            return NoContent();
        }
    }
}
