using DapperWebApi.Entities;
using DapperWebApi.Entities.ResponseModel;

namespace DapperWebApi.IRepository
{
    public interface IAlbumRepository
    {
        public Task<IEnumerable<Album>> GetAlbum();
        public Task<IEnumerable<AlbumResponseModel>> SearchAlbum(string filter);
        public Task<Album> GetAlbumByID(int ID);
        public Task<string> DeleteAlbum(int ID);
        public Task<string> CreateAlbum(Album album);
        public Task<string> UpdateAlbum(Album album);
    }
}
