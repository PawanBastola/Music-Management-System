using DapperWebApi.Entities;
using DapperWebApi.Entities.ResponseModel;

namespace DapperWebApi.IRepository
{
    public interface IArtistRepository
    {
        public Task<IEnumerable<Artist>> GetArtist();
        public Task<IEnumerable<Artist>> SearchArtist(string filter);
        public Task<Artist> GetArtistByID(int ID);
        public Task<string> DeleteArtist(int ID);
        public Task<string> CreateArtist(Artist artist);
        public Task<string> UpdateArtist(Artist artist);    
    }
}
