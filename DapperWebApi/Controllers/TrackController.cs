using DapperWebApi.Entities;
using DapperWebApi.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperWebApi.Controllers
{
    [Route("api/Track")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly ITrackRepository _TrackRepository;
        public TrackController(ITrackRepository repo)
        {
            _TrackRepository = repo;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetTrack()
        {
            var Tracks = await _TrackRepository.GetTrack();
            return Ok(Tracks);
        }

        [HttpGet("Search/{filter}")]
        public async Task<IActionResult> SearchTrack(string filter)
        {
            var Tracks = await _TrackRepository.SearchTrack(filter);
            return Ok(Tracks);
        }

        [HttpGet("{ID}")]
        public async Task<IActionResult> GetTrackByID(int ID)
        {
            try
            {
                var Track = await _TrackRepository.GetTrackByID(ID);
                if (Track is null)
                {
                    return NotFound();
                }
                return Ok(Track);

                /*var json = JsonSerializer.Serialize(Track);
                return Content(json, "application/json");*/
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpDelete("DeleteTrack/{ID}")]
        public async Task<IActionResult> DeleteTrack(int ID)
        {
            var message = await _TrackRepository.DeleteTrack(ID);
            return Ok(message);
        }

        [HttpPost("SaveTrack")]
        public async Task<IActionResult> SaveTrack(Track Track)
        {
            var message = await _TrackRepository.CreateTrack(Track);
            return Ok(message);
        }


        [HttpPut("UpdateTrack")]
        public async Task<IActionResult> UpdateTrack(Track Track)
        {
            var message = await _TrackRepository.UpdateTrack(Track);
            return Ok(message);
        }
    }
}
