using Amazon.DynamoDBv2.DataModel;
using DarksoulsApi.Dtos.DbModels.Interfaces;

namespace DarksoulsApi.Dtos.DbModels
{
    [DynamoDBTable("ds1_bosses")]
    public class Boss : IEnemy
    {
        [DynamoDBHashKey]
        public int BossId {get; set;}
        public string BossName { get; set; }
        public string Location { get; set; }
        public int HealthNG { get; set; }
        public int HealthNGPlus {get; set;}
        public int SoulsNG {get; set;}
        public int SoulsNGPlus {get; set;}
    }
}