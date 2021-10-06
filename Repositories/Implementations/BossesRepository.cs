using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using DarksoulsApi.Repositories.Interfaces;

namespace DarksoulsApi.Repositories.Implementations
{
    public class BossesRepository : IBossesRepository
    {
        #region Fields

        private readonly string _tableName = "ds1_enemies";
        private readonly Table _table;

        #endregion

        #region Constructors
        public BossesRepository(IAmazonDynamoDB dynamoDbClient)
        {
            _table = Table.LoadTable(dynamoDbClient, _tableName);
        }

        #endregion

        #region IBossesRepository implementation

        public async Task<Document> GetBoss(int id, string bossName)
        {
            return await _table.GetItemAsync(id, bossName);
        }

        public async Task<IEnumerable<Document>> GetAllBosses()
        {
            var config = new ScanOperationConfig();
            var result =  await _table.Scan(config).GetRemainingAsync();
            return result;
        }

        public async Task AddBoss(Document bossDocument)
        {
            await _table.PutItemAsync(bossDocument);
        }

        #endregion
    }
}