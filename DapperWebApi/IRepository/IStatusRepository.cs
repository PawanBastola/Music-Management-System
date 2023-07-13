using DapperWebApi.Entities;

namespace DapperWebApi.IRepository
{
    public interface IStatusRepository
    {
        public Task<IEnumerable<Statusm>> GetStatus();


    }
}
