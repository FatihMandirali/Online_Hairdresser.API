namespace Online_Hairdresser.Data.Entity;

public class VenueFile:AuditableEntity
{
    public int VenueId { get; set; }
    public Venue Venue { get; set; }
    public string Path { get; set; }
}