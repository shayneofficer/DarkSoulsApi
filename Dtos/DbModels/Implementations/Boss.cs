using Amazon.DynamoDBv2.DataModel;

namespace DarksoulsApi.Dtos.DbModels.Implementations
{
    [DynamoDBTable("ds1_bosses")]
    public class Boss : Enemy
    {
        public bool IsBoss {get; set;}
    }
}