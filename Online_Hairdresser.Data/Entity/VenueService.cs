namespace Online_Hairdresser.Data.Entity;

public class VenueService:AuditableEntity
{
    public int VenueId { get; set; }
    public Venue Venue { get; set; }
    public string Name { get; set; } //todo example: saç, sakal 
    public decimal Price { get; set; }
}