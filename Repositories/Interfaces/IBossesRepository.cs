using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DocumentModel;
using DarksoulsApi.Dtos.DbModels;

namespace DarksoulsApi.Repositories.Interfaces
{
    public interface IBossesRepository
    {
        Task<Document> GetBoss(int id, string bossName);
        Task<IEnumerable<Document>> GetAllBosses();
        Task AddBoss(Document bossDocument);
    }
}