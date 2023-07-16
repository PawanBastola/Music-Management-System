using DapperWebApi.Entities;
using DapperWebApi.IRepository;
using DapperWebApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DapperWebApi.Controllers
{
    [Route("api/Artist")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistRepository _artistRepository;
        public ArtistController(IArtistRepository repo)
        {
            _artistRepository = repo;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetArtist()
        {
            var Statuses = await _artistRepository.GetArtist();
            return Ok(Statuses);
        }

        [HttpGet("Search/{filter}")]
        public async Task<IActionResult> SearchTrack(string filter)
        {
            var Tracks = await _artistRepository.SearchArtist(filter);
            return Ok(Tracks);
        }


        [HttpGet("{ID}")]
        public async Task<IActionResult> GetArtistByID(int ID)
        {
            try
            {
                var artist = await _artistRepository.GetArtistByID(ID);
                if (artist is null)
                {
                    return NotFound();
                }
                return Ok(artist);

                /*var json = JsonSerializer.Serialize(artist);
                return Content(json, "application/json");*/
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpDelete("DeleteArtist/{ID}")]
        public async Task<IActionResult> DeleteArtist(int ID)
        {
            var message = await _artistRepository.DeleteArtist(ID);
            return Ok(message);
        }

        [HttpPost("SaveArtist")]
        public async Task<IActionResult> SaveArtist(Artist artist)
        {
            var message = await _artistRepository.CreateArtist(artist);
            return Ok(message);
        }


        [HttpPut("UpdateArtist")]
        public async Task<IActionResult> UpdateArtist(Artist artist)
        {
            var message = await _artistRepository.UpdateArtist(artist);
            return Ok(message);
        }
    }
}
