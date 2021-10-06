namespace DarksoulsApi.Dtos.DbModels.Interfaces
{
    public interface IEnemy 
    {
        string Location { get; set; }
        int HealthNG { get; set; }
        int HealthNGPlus {get; set;}
        int SoulsNG {get; set;}
        int SoulsNGPlus {get; set;}
    }
    
}