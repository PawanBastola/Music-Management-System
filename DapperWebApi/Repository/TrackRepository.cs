using Dapper;
using DapperWebApi.Context;
using DapperWebApi.Entities;
using DapperWebApi.Entities.ResponseModel;
using DapperWebApi.IRepository;

namespace DapperWebApi.Repository
{
    public class TrackRepository : ITrackRepository
    {
        private readonly DapperContext context;

        public TrackRepository(DapperContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<TrackResponseModel>> GetTrack()
        {
            var query = "Select TrackID,T.Title,duration,T.genre,T.popularity,T.ArtistiD, A.Name ArtistName,T.AlbumID, AL.Title Album from tblTrack T With(NOLOCK) Left Join tblArtist A With(NOLOCK) ON A.ArtistID=T.ArtistID Left Join tblAlbum AL With(NOLOCK) ON AL.AlbumID=T.AlbumID";
            using (var connection = context.CreateConnection())
            {
                var status = await connection.QueryAsync<TrackResponseModel>(query);
                return status.ToList();
            }
        }

        public async Task<IEnumerable<TrackResponseModel>> SearchTrack(string filter)
        {
            filter = filter + "%";
            var query = "Select TrackID,T.Title,duration,T.genre,T.popularity,T.ArtistiD, A.Name ArtistName,T.AlbumID, AL.Title Album from tblTrack T With(NOLOCK) Left Join tblArtist A With(NOLOCK) ON A.ArtistID=T.ArtistID Left Join tblAlbum AL With(NOLOCK) ON AL.AlbumID=T.AlbumID where T.genre like @filter OR T.Title like @filter OR A.Name like @filter";
            using (var connection = context.CreateConnection())
            {
                var status = await connection.QueryAsync<TrackResponseModel>(query, new {filter});
                return status.ToList();
            }
        }

        public async Task<Track> GetTrackByID(int ID)
        {
            var query = "Select TrackID,Title,duration,genre,popularity,ArtistID,AlbumID from tblTrack T With(NOLOCK) Where TrackID=@ID";
            using (var connection = context.CreateConnection())
            {
                connection.Open();
                var Track = await connection.QuerySingleOrDefaultAsync<Track>(query, new { ID });
                return Track;
            }
        }

        public async Task<string> DeleteTrack(int ID)
        {
            var query = "Delete tblTrack Where TrackID=@ID";
            using (var connection = context.CreateConnection())
            {
                var message = await connection.ExecuteAsync(query, new { ID });
                if (message == 0)
                {
                    return "Unable to Delete Track";
                }
                else
                    return "Track deleted successfully";
            }
        }

        public async Task<string> CreateTrack(Track Track)
        {
            Track.CreatedBy = 1;
            var query = "INSERT INTO tblTrack (Title, duration, genre, popularity, CreatedBy, CreatedDate, ArtistID, AlbumID) VALUES(@Title, @duration, @genre, @popularity, @CreatedBy, GETDATE(), @ArtistID, @AlbumID)";
            using (var connection = context.CreateConnection())
            {
                var affectedrows = await connection.ExecuteAsync(query, Track);
                if (affectedrows == 0)
                {
                    return "Unable to Save Track";
                }
                else
                    return "Track Saved successfully";
            }
        }
        public async Task<string> UpdateTrack(Track Track)
        {

            var query = "Update tblTrack set Title=@Title,duration=@duration,genre=@genre,popularity=@popularity,ArtistID=@ArtistID,AlbumID=@AlbumID WHERE TrackID=@ID";
            using (var connection = context.CreateConnection())
            {
                var affectedrows = await connection.ExecuteAsync(query, Track);
                if (affectedrows == 0)
                {
                    return "Unable to Update Track";
                }
                else
                    return "Track Updated successfully";
            }
        }
    }
}
