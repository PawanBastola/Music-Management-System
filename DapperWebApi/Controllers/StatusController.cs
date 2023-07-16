using DapperWebApi.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DapperWebApi.Controllers
{
    [Route("api/Status")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;
        public StatusController(IStatusRepository repo)
        {
            _statusRepository = repo;
        }

        [HttpGet]   
        public async Task<IActionResult> GetStatus()
        {
            var Statuses =  await _statusRepository.GetStatus();
            return Ok(Statuses);
        }
    }
}
