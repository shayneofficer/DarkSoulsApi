namespace DarksoulsApi.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using DarksoulsApi.Services;
    using DarksoulsApi.Dtos.Responses;
    using DarksoulsApi.Dtos.Requests;

    [Route("api/bosses")]
    [ApiController]
    public class BossesController : ControllerBase
    {
        private readonly IBossesService _bossesService;

        public BossesController(IBossesService bossesService)
        {
            _bossesService = bossesService;
        }

        /// <summary>
        /// Get all bosses
        // GET: api/Bosses
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<GetBossesResponse>> GetBosses()
        {
            var result = await _bossesService.GetBosses();

            if(result.Bosses == null)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Get a specific boss
        /// GET: api/Bosses/5
        /// </summary>
        [HttpGet("{id}/{bossName}")]
        public async Task<ActionResult<GetBossResponse>> GetBoss(int id, string bossName)
        {
            var result = await _bossesService.GetBoss(id, bossName);

            if(result == null)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task AddBoss(AddBossRequest boss)
        {
            await _bossesService.AddBoss(boss);
        }
    }
}
