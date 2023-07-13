using Dapper;
using DapperWebApi.Context;
using DapperWebApi.Entities;
using DapperWebApi.IRepository;

namespace DapperWebApi.Repository
{
    public class AlbumRepository:IAlbumRepository
    {


        private readonly DapperContext context;

        public AlbumRepository(DapperContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<Album>> GetAlbum()
        {
            var query = "SELECT AlbumID, Title, ReleaseDate FROM tblAlbum";
            using (var connection = context.CreateConnection())
            {
                var status = await connection.QueryAsync<Album>(query);
                return status.ToList();
            }
        }

        public async Task<Album> GetAlbumByID(int ID)
        {
            var query = "SELECT AlbumID, Title, ReleaseDate FROM tblAlbum Where AlbumID=@ID";
            using (var connection = context.CreateConnection())
            {
                
                var Album = await connection.QuerySingleOrDefaultAsync<Album>(query, new { ID });
                return Album;
            }
        }

        public async Task<string> DeleteAlbum(int ID)
        {
            var query = "Delete tblAlbum Where AlbumID=@ID";
            using (var connection = context.CreateConnection())
            {
                var message = await connection.ExecuteAsync(query, new { ID });
                if (message == 0)
                {
                    return "Unable to Delete Album";
                }
                else
                    return "Album deleted successfully";
            }
        }

        public async Task<string> CreateAlbum(Album album)
        {
            album.CreatedBy = 1;
            var query = "Insert into tblAlbum(Title, ReleaseDate,CreatedBy, CreatedDate) Values(@Title,@ReleaseDate,@CreatedBy,GETDATE())";
            using (var connection = context.CreateConnection())
            {
                var affectedrows = await connection.ExecuteAsync(query, album);
                if (affectedrows == 0)
                {
                    return "Unable to Save Album";
                }
                else
                    return "Album Saved successfully";
            }
        }
        public async Task<string> UpdateAlbum(Album Album)
        {

            var query = "Update tblAlbum set Title=@Title, ReleaseDate=@ReleaseDate where AlbumID=@AlbumID";
            using (var connection = context.CreateConnection())
            {
                var affectedrows = await connection.ExecuteAsync(query, Album);
                if (affectedrows == 0)
                {
                    return "Unable to Update Album";
                }
                else
                    return "Album Updated successfully";
            }
        }
    }
}
