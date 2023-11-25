namespace Online_Hairdresser.Data.Entity;

public class VenueWorker:AuditableEntity
{
    public int VenueId { get; set; }
    public Venue Venue { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string ServiceList { get; set; } //todo, example (VenueServiceId) 1,2,3,4,5
}