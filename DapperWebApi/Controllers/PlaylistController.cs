using DapperWebApi.Entities;
using DapperWebApi.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace DapperWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistRepository _PlaylistRepository;
        public PlaylistController(IPlaylistRepository repo)
        {
            _PlaylistRepository = repo;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetPlaylist()
        {
            var Playlists = await _PlaylistRepository.GetPlaylist();
            return Ok(Playlists);
        }

        [HttpGet("{ID}")]
        public async Task<IActionResult> GetPlaylistByID(int ID)
        {
            try
            {
                var Playlist = await _PlaylistRepository.GetPlaylistByID(ID);
                if (Playlist is null)
                {
                    return NotFound();
                }
                return Ok(Playlist);
               
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpDelete("DeletePlaylist/{ID}")]
        public async Task<IActionResult> DeletePlaylist(int ID)
        {
            var message = await _PlaylistRepository.DeletePlaylist(ID);
            return Ok(message);
        }

        [HttpPost("SavePlaylist")]
        public async Task<IActionResult> SavePlaylist(Playlist Playlist)
        {
            var message = await _PlaylistRepository.CreatePlaylist(Playlist);
            return Ok(message);
        }


        [HttpPut("UpdatePlaylist")]
        public async Task<IActionResult> UpdatePlaylist(Playlist Playlist)
        {
            var message = await _PlaylistRepository.UpdatePlaylist(Playlist);
            return Ok(message);
        }
    }
}
