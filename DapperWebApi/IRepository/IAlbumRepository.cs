using DapperWebApi.Entities;

namespace DapperWebApi.IRepository
{
    public interface IAlbumRepository
    {
        public Task<IEnumerable<Album>> GetAlbum();
        public Task<Album> GetAlbumByID(int ID);
        public Task<string> DeleteAlbum(int ID);
        public Task<string> CreateAlbum(Album album);
        public Task<string> UpdateAlbum(Album album);
    }
}
