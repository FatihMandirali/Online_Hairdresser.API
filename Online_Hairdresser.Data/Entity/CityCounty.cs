namespace Online_Hairdresser.Data.Entity;

public class CityCounty:AuditableEntity
{
    public string CityName { get; set; }    
    public string CountyName { get; set; }    
    public int PlateNumber { get; set; }    
    public string Region { get; set; }    
}