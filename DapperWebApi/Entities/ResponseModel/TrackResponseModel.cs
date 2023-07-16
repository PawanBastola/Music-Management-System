namespace DapperWebApi.Entities.ResponseModel
{
    public class TrackResponseModel
    {

        public int TrackID { get; set; }
        public string Title { get; set; }
        public string duration { get; set; }
        public string genre { get; set; }
        public string popularity { get; set; }
        public int CreatedBy { get; set; }
        public int? ArtistID { get; set; }
        public int? AlbumID { get; set; }
        public string ArtistName { get; set; }
        public string Album { get; set; }

    }
}
