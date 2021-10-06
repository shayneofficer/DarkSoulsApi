namespace DarksoulsApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using DarksoulsApi.Services;
    using DarksoulsApi.Dtos.DbModels;
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
            var bosses = await _bossesService.GetBosses();
            return Ok(bosses);
        }

        /// <summary>
        /// Get a specific boss
        /// GET: api/Bosses/5
        /// </summary>
        [HttpGet("{id}/{bossName}")]
        public async Task<ActionResult<GetBossResponse>> GetBoss(int id, string bossName)
        {
            var boss = await _bossesService.GetBoss(id, bossName);
            return Ok(boss);
        }

        [HttpPost]
        public async Task AddBoss(AddBossRequest boss)
        {
             await _bossesService.AddBoss(boss);
        }
    }
}
