using System.Collections.Generic;
using DarksoulsApi.Dtos.DbModels.Implementations;

namespace DarksoulsApi.Dtos.Responses
{
    public class GetBossesResponse
    {
        public List<Boss> Bosses {get; set;}
    }
}