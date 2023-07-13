using Microsoft.Extensions.Primitives;

namespace DapperWebApi.Entities
{
    public class Artist
    {
        public int ArtistID { get; set; }
        public string? Name { get; set; }
        public string? genre { get; set; }
        public string? popularity { get; set; }
        public int? CreatedBy { get; set; }
        

    }
}
