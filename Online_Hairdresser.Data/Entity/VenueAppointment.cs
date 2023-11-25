namespace Online_Hairdresser.Data.Entity;

public class VenueAppointment:AuditableEntity
{
    public int VenueId { get; set; }
    public Venue Venue { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }

    public string ServiceList { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Hour { get; set; }
    
}