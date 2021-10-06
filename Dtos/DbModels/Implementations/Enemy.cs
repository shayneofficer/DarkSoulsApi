using Amazon.DynamoDBv2.DataModel;
using DarksoulsApi.Dtos.DbModels.Interfaces;

namespace DarksoulsApi.Dtos.DbModels.Implementations
{
    public class Enemy : IEnemy
    {
        [DynamoDBHashKey]
        public int Id {get; set;}
        public string Name { get; set; }
        public string Location { get; set; }
        public int HealthNG { get; set; }
        public int HealthNGPlus {get; set;}
        public int SoulsNG {get; set;}
        public int SoulsNGPlus {get; set;}
    }
}