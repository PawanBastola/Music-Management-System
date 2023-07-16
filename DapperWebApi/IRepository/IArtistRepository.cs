using DapperWebApi.Entities;

namespace DapperWebApi.IRepository
{
    public interface IArtistRepository
    {
        public Task<IEnumerable<Artist>> GetArtist();
        public Task<Artist> GetArtistByID(int ID);
        public Task<string> DeleteArtist(int ID);
        public Task<string> CreateArtist(Artist artist);
        public Task<string> UpdateArtist(Artist artist);    
    }
}
