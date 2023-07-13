using DapperWebApi.Context;
using DapperWebApi.Entities.ResponseModel;
using DapperWebApi.Entities;
using DapperWebApi.IRepository;
using Dapper;

namespace DapperWebApi.Repository
{
    public class PlaylistRepository:IPlaylistRepository
    {
        private readonly DapperContext context;

        public PlaylistRepository(DapperContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<PlaylistResponseModel>> GetPlaylist()
        {
            var query = "Select PlaylistID,P.Title, Description,P.TrackID, P.Title from tblPlaylist P With(NOLOCK) Left Join tblTrack T With(NOLOCK) ON T.TrackID=P.TrackID";
            using (var connection = context.CreateConnection())
            {
                var status = await connection.QueryAsync<PlaylistResponseModel>(query);
                return status.ToList();
            }
        }

        public async Task<Playlist> GetPlaylistByID(int ID)
        {
            var query = "Select PlaylistID,Title,Description,TrackID from tblPlaylist With(NOLOCK) Where PlaylistID=@ID";
            using (var connection = context.CreateConnection())
            {
                connection.Open();
                var Playlist = await connection.QuerySingleOrDefaultAsync<Playlist>(query, new { ID });
                return Playlist;
            }
        }

        public async Task<string> DeletePlaylist(int ID)
        {
            var query = "Delete tblPlaylist Where PlaylistID=@ID";
            using (var connection = context.CreateConnection())
            {
                var message = await connection.ExecuteAsync(query, new { ID });
                if (message == 0)
                {
                    return "Unable to Delete Playlist";
                }
                else
                    return "Playlist deleted successfully";
            }
        }

        public async Task<string> CreatePlaylist(Playlist Playlist)
        {
            Playlist.CreatedBy = 1;
            var query = "INSERT INTO tblPlaylist(Title, Description, TrackID, CreatedBy, CreatedDate) VALUES(@Title, @Description,@TrackID,@CreatedBy,GETDATE())";
            using (var connection = context.CreateConnection())
            {
                var affectedrows = await connection.ExecuteAsync(query, Playlist);
                if (affectedrows == 0)
                {
                    return "Unable to Save Playlist";
                }
                else
                    return "Playlist Saved successfully";
            }
        }
        public async Task<string> UpdatePlaylist(Playlist Playlist)
        {

            var query = "Update tblPlaylist set Title=@Title,duration=@duration,genre=@genre,popularity=@popularity,ArtistID=@ArtistID,AlbumID=@AlbumID WHERE PlaylistID=@ID";
            using (var connection = context.CreateConnection())
            {
                var affectedrows = await connection.ExecuteAsync(query, Playlist);
                if (affectedrows == 0)
                {
                    return "Unable to Update Playlist";
                }
                else
                    return "Playlist Updated successfully";
            }
        }
    }
}
