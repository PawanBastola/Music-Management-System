using DapperWebApi.Entities;
using DapperWebApi.IRepository;
using DapperWebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperWebApi.Controllers
{
    [Route("api/Album")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumRepository _AlbumRepository;
        public AlbumController(IAlbumRepository repo)
        {
            _AlbumRepository = repo;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAlbum()
        {
            var Statuses = await _AlbumRepository.GetAlbum();
            return Ok(Statuses);
        }
        [HttpGet("Search/{filter}")]
        public async Task<IActionResult> SearchAlbum(string filter)
        {
            var Tracks = await _AlbumRepository.SearchAlbum(filter);
            return Ok(Tracks);
        }
        [HttpGet("{ID}")]
        public async Task<IActionResult> GetAlbumByID(int ID)
        {
            try
            {
                var Album = await _AlbumRepository.GetAlbumByID(ID);
                if (Album is null)
                {
                    return NotFound();
                }
                return Ok(Album);

            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpDelete("DeleteAlbum/{ID}")]
        public async Task<IActionResult> DeleteAlbum(int ID)
        {
            var message = await _AlbumRepository.DeleteAlbum(ID);
            return Ok(message);
        }

        [HttpPost("SaveAlbum")]
        public async Task<IActionResult> SaveAlbum(Album Album)
        {
            var message = await _AlbumRepository.CreateAlbum(Album);
            return Ok(message);
        }


        [HttpPut("UpdateAlbum")]
        public async Task<IActionResult> UpdateAlbum(Album Album)
        {
            var message = await _AlbumRepository.UpdateAlbum(Album);
            return Ok(message);
        }
    }
}
