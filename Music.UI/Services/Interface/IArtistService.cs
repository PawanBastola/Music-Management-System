using Music.UI.Model;

namespace Music.UI.Services.Interface
{
    public interface IArtistService
    {
        Task<List<ArtistModel>> GetArtists();
        Task<string> SaveArtists(ArtistModel artist);
        Task<string> UpdateArtists(ArtistModel artist);
        Task<ArtistModel> GetArtistByID(int ID);
        Task<string> DeleteArtist(int ID);
    }
}
