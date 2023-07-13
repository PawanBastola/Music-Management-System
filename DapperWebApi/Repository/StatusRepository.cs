using Dapper;
using DapperWebApi.Context;
using DapperWebApi.Entities;
using DapperWebApi.IRepository;

namespace DapperWebApi.Repository
{
    public class StatusRepository : IStatusRepository
    {
        private readonly DapperContext context;

        public StatusRepository(DapperContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<Statusm>> GetStatus()
        {

            var query = "SELECT StatusId, Status FROM tblStatus";
            using (var connection = context.CreateConnection())
            {
                var status = await connection.QueryAsync<Statusm>(query);
                return status.ToList();
            }
        }

    }
}

