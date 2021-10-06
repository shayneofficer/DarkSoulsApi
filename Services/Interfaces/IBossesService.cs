using System.Collections.Generic;
using System.Threading.Tasks;
using DarksoulsApi.Dtos.DbModels;
using DarksoulsApi.Dtos.Requests;
using DarksoulsApi.Dtos.Responses;

namespace DarksoulsApi.Services
{
    public interface IBossesService
    {
        Task<GetBossResponse> GetBoss(int id, string bossName);
        Task<GetBossesResponse> GetBosses();
        Task AddBoss(AddBossRequest addBossRequest);
    }
}