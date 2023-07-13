using System.Security.Principal;

namespace DapperWebApi.Entities
{
    public class Album
    {
        public int AlbumID { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public int? CreatedBy { get; set; }
        
    }
}
