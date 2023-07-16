using System.Reflection.Metadata.Ecma335;

namespace DapperWebApi.Entities.ResponseModel
{
    public class AlbumResponseModel
    {
        public int AlbumID { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public string ArtistName { get; set; }
        public string TrackTitle { get; set; }


    }
}
