using DapperWebApi.Entities;
using DapperWebApi.Entities.ResponseModel;

namespace DapperWebApi.IRepository
{
    public interface IPlaylistRepository
    {
        public Task<IEnumerable<PlaylistResponseModel>> GetPlaylist();
        public Task<IEnumerable<PlaylistResponseModel>> SearchPlaylist(string filter);
        public Task<Playlist> GetPlaylistByID(int ID);
        public Task<string> DeletePlaylist(int ID);
        public Task<string> CreatePlaylist(Playlist Playlist);
        public Task<string> UpdatePlaylist(Playlist Playlist);
    }
}
