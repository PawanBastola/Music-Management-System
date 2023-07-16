using Dapper;
using DapperWebApi.Context;
using DapperWebApi.Entities;
using DapperWebApi.Entities.ResponseModel;
using DapperWebApi.IRepository;

namespace DapperWebApi.Repository
{
    public class ArtistRepository : IArtistRepository
    {

        private readonly DapperContext context;

        public ArtistRepository(DapperContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<Artist>> GetArtist()
        {
            var query = "SELECT ArtistID, Name, genre, popularity, CreatedBY FROM tblArtist";
            using (var connection = context.CreateConnection())
            {
                var status = await connection.QueryAsync<Artist>(query);
                return status.ToList();
            }
        }


        public async Task<IEnumerable<Artist>> SearchArtist(string filter)
        {
            filter = filter + "%";
            var query = "SELECT ArtistID, Name, genre, popularity, CreatedBY FROM tblArtist WITH(NOLOCK) Where Name Like @filter OR genre LIKE @filter";
            using (var connection = context.CreateConnection())
            {
                var searchresult = await connection.QueryAsync<Artist>(query, new { filter });
                return searchresult.ToList();
            }
        }

        public async Task<Artist> GetArtistByID(int ID)
        {
            var query = "SELECT ArtistID,Name, genre, popularity,CreatedBY FROM tblArtist Where ArtistID=@ID";
            using (var connection = context.CreateConnection())
            {
                connection.Open();
                var artist = await connection.QuerySingleOrDefaultAsync<Artist>(query, new { ID });
                return artist;
            }
        }

        public async Task<string> DeleteArtist(int ID)
        {
            var query = "Delete tblArtist Where ArtistID=@ID";
            using (var connection = context.CreateConnection())
            {
                var message = await connection.ExecuteAsync(query, new { ID });
                if (message == 0)
                {
                    return "Unable to Delete Artist";
                }
                else
                    return "Artist deleted successfully";
            }
        }

        public async Task<string> CreateArtist(Artist artist)
        {
            artist.CreatedBy = 1;
            var query = "Insert into tblArtist(Name,genre, popularity,CreatedBy, CreatedDate) Values(@Name,@genre,@popularity,@CreatedBy,GETDATE())";
            using (var connection = context.CreateConnection())
            {
                var affectedrows = await connection.ExecuteAsync(query, artist);
                if (affectedrows == 0)
                {
                    return "Unable to Save Artist";
                }
                else
                    return "Artist Saved successfully";
            }
        }
        public async Task<string> UpdateArtist(Artist artist)
        {

            var query = "Update tblArtist set Name =@Name, genre=@genre, popularity=@popularity where ArtistID=@ArtistID";
            using (var connection = context.CreateConnection())
            {
                var affectedrows = await connection.ExecuteAsync(query, artist);
                if (affectedrows == 0)
                {
                    return "Unable to Update Artist";
                }
                else
                    return "Artist Updated successfully";
            }
        }

    }
}
