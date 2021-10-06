namespace DarksoulsApi.Dtos.Requests
{
    public class AddBossRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location {get; set;}

        public int HealthNG {get; set;}

        public int HealthNGPlus {get; set;}

        public int SoulsNG {get; set;}

        public int SoulsNGPlus {get; set;}

        public bool IsBoss {get; set;}
    }
}