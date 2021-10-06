namespace DarksoulsApi.Dtos.DbModels.Interfaces
{
    public interface IEnemy 
    {
        int Id {get; set;}
        string Name {get; set;}
        string Location { get; set; }
        int HealthNG { get; set; }
        int HealthNGPlus {get; set;}
        int SoulsNG {get; set;}
        int SoulsNGPlus {get; set;}
    }
    
}