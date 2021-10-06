using System.Collections.Generic;
using System.Linq;
using Amazon.DynamoDBv2.DocumentModel;
using DarksoulsApi.Dtos.DbModels.Implementations;
using DarksoulsApi.Dtos.Mappers.Interfaces;
using DarksoulsApi.Dtos.Requests;
using DarksoulsApi.Dtos.Responses;

namespace DarksoulsApi.Dtos.Mappers.Implementations
{
    public class Mapper : IMapper
    {
        #region Mapping functions 
        
        public GetBossesResponse ToGetBossesResponse(IEnumerable<Document> items)
        {
            var response = new GetBossesResponse();
            response.Bosses = items.Select(ToBoss).ToList();
            return response;
        }

        public GetBossResponse ToGetBossResponse(Document item)
        {
            var response = new GetBossResponse();
            response.Boss = ToBoss(item);
            return response;
        }

        public Document ToBossDocument(AddBossRequest addBossRequest)
        {
            return new Document 
            {
                ["Id"] = addBossRequest.Id.ToString(),
                ["Name"] = addBossRequest.Name,
                ["Location"] = addBossRequest.Location,
                ["HealthNG"] = addBossRequest.HealthNG,
                ["HealthNGPlus"] = addBossRequest.HealthNGPlus,
                ["SoulsNG"] = addBossRequest.SoulsNG,
                ["SoulsNGPlus"] = addBossRequest.SoulsNGPlus,
                ["IsBoss"] = addBossRequest.IsBoss
            };
        }

        #endregion

        #region Helper Functions

        private Boss ToBoss(Document item)
        {
            return new Boss
            {
                Id = item["Id"].AsInt(),
                Location = item["Location"],
                Name = item["Name"].AsString(),
                HealthNG  = item["HealthNG"].AsInt(),
                HealthNGPlus = item["HealthNGPlus"].AsInt(),
                SoulsNG = item["SoulsNG"].AsInt(),
                SoulsNGPlus = item["SoulsNGPlus"].AsInt(),
                IsBoss = item["IsBoss"].AsBoolean()
            };
        }

        #endregion

    }
}