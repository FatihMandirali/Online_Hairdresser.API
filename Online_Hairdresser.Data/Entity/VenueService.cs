namespace Online_Hairdresser.Data.Entity;

public class VenueService:AuditableEntity
{
    public int VenueId { get; set; }
    public Venue Venue { get; set; }
    public int ServiceId { get; set; }
    public Service Service { get; set; }
    
    public decimal Price { get; set; }
}