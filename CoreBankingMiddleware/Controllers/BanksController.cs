using CoreBankingMiddleware.BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreBankingMiddleware.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        protected GeneralClass _GeneralClass;

        public BanksController(GeneralClass generalClass)
        {
            _GeneralClass = generalClass;
        }

        [HttpGet("GetBank")]
        public async Task<ActionResult> GetBank()
        {
            return Ok(await _GeneralClass.GetBank());
        }
    }
}
