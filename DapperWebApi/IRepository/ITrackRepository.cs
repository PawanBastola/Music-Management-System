using DapperWebApi.Entities;
using DapperWebApi.Entities.ResponseModel;

namespace DapperWebApi.IRepository
{
    public interface ITrackRepository
    {
        public Task<IEnumerable<TrackResponseModel>> GetTrack();
        public Task<IEnumerable<TrackResponseModel>> SearchTrack(string filter);

        public Task<Track> GetTrackByID(int ID);
        public Task<string> DeleteTrack(int ID);
        public Task<string> CreateTrack(Track track);
        public Task<string> UpdateTrack(Track track);
        
    }
}
