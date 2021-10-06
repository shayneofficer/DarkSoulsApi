using System.Threading.Tasks;
using DarksoulsApi.Dtos.Mappers.Interfaces;
using DarksoulsApi.Dtos.Requests;
using DarksoulsApi.Dtos.Responses;
using DarksoulsApi.Repositories.Interfaces;

namespace DarksoulsApi.Services.Implementations
{
    public class BossesService : IBossesService
    {
        #region Fields
        private readonly IBossesRepository _bossesRepository;
        private readonly IMapper _mapper;

        #endregion

        public BossesService(IBossesRepository bossesRepository, IMapper mapper)
        {
            _bossesRepository = bossesRepository;
            _mapper = mapper;
        }

        #region Functions

        public async Task<GetBossResponse> GetBoss(int id, string bossName)
        {
            var result =  await _bossesRepository.GetBoss(id, bossName);
            var mappedResult = _mapper.ToGetBossResponse(result);
            return mappedResult;
        }

        public async Task<GetBossesResponse> GetBosses()
        {
            var result = await _bossesRepository.GetAllBosses();
            var mappedResult = _mapper.ToGetBossesResponse(result);
            return mappedResult;
        }

        public async Task AddBoss(AddBossRequest addBossRequest)
        {
            var mappedRequest = _mapper.ToBossDocument(addBossRequest);
            await _bossesRepository.AddBoss(mappedRequest);
        }

        #endregion
    }
}