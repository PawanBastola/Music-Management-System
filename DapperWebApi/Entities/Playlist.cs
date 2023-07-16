namespace DapperWebApi.Entities
{
    public class Playlist
    {
        public int PlaylistID { get; set; }
        public string Title { get; set; }
        public int TrackID { get; set; }
        public string Description { get; set; }
        public int? CreatedBy { get; set; }
    }
}
