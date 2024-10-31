using DubRep.Data;
using DubRep.Models.DTOs;
using DubRep.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DubRep.Controllers
{
    // localhost:xxx/api/series
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public SeriesController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllSeries()
        {
            // 200 OK with the series list in the response body
            return Ok(dbContext.Series.Include(_ => _.Cast).ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Series> GetSeriesById(int id)
        {
            var series = dbContext.Series.Include(_ => _.Cast).Where(_ => _.Id == id).FirstOrDefault();
            if (series == null)
            {
                // 404 Not Found if the series does not exist
                return NotFound();
            }
            // 200 OK with the series in the response body
            return Ok(series);
        }

        [HttpPost]
        public IActionResult AddSeries(AddSeriesDTO addSeriesDTO)
        {
            var seriesEntity = new Series()
            {
                Name = addSeriesDTO.Name,
                Country = addSeriesDTO.Country,
                ImageName = addSeriesDTO.ImageName
            };

            dbContext.Series.Add(seriesEntity);
            dbContext.SaveChanges();

            // 201 Created with the series in the response body
            return CreatedAtAction(nameof(GetSeriesById), new { id = seriesEntity.Id }, seriesEntity);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSeries(int id, UpdateSeriesDTO updateSeriesDTO)
        {
            var series = dbContext.Series.Include(_ => _.Cast).Where(_ => _.Id == id).FirstOrDefault();
            if (series == null)
            {
                // 404 Not Found if the series does not exist
                return NotFound();
            }

            series.Name = updateSeriesDTO.Name;
            series.Country = updateSeriesDTO.Country;
            series.ImageName = updateSeriesDTO.ImageName;

            dbContext.SaveChanges();

            // 200 OK with the series in the response body
            return Ok(series);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSeries(int id)
        {
            var series = dbContext.Series.Include(_ => _.Cast).Where(_ => _.Id == id).FirstOrDefault();
            if (series == null)
            {
                // 404 Not Found if the series does not exist
                return NotFound();
            }

            dbContext.Series.Remove(series);
            dbContext.SaveChanges();

            return NoContent();
        }
    }
}
