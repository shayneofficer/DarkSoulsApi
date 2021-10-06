using System.Collections.Generic;
using Amazon.DynamoDBv2.DocumentModel;
using DarksoulsApi.Dtos.DbModels;
using DarksoulsApi.Dtos.Requests;
using DarksoulsApi.Dtos.Responses;

namespace DarksoulsApi.Dtos.Mappers.Interfaces
{
    public interface IMapper
    {
        GetBossesResponse ToGetBossesResponse(IEnumerable<Document> bosses);
        GetBossResponse ToGetBossResponse(Document item);

        Document ToBossDocument(AddBossRequest addBossRequest);
    }
}