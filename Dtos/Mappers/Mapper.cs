using System;
using System.Collections.Generic;
using System.Linq;
using Amazon.DynamoDBv2.DocumentModel;
using DarksoulsApi.Dtos.DbModels;
using DarksoulsApi.Dtos.Requests;
using DarksoulsApi.Dtos.Responses;

namespace DarksoulsApi.Dtos.Mappers
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
                ["BossId"] = addBossRequest.BossId,
                ["BossName"] = addBossRequest.BossName,
                ["Location"] = addBossRequest.Location,
                ["HealthNG"] = addBossRequest.HealthNG,
                ["HealthNGPlus"] = addBossRequest.HealthNGPlus,
                ["SoulsNG"] = addBossRequest.SoulsNG,
                ["SoulsNGPlus"] = addBossRequest.SoulsNGPlus
            };
        }

        #endregion

        #region Helper Functions

        private Boss ToBoss(Document item)
        {
            return new Boss
            {
                BossId = item["BossId"].AsInt(),
                Location = item["Location"],
                BossName = item["BossName"].AsString(),
                HealthNG  = item["HealthNG"].AsInt(),
                HealthNGPlus = item["HealthNGPlus"].AsInt(),
                SoulsNG = item["SoulsNG"].AsInt(),
                SoulsNGPlus = item["SoulsNGPlus"].AsInt(),
            };
        }

        #endregion

    }
}