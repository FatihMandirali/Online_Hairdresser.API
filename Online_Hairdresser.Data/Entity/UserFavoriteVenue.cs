namespace Online_Hairdresser.Data.Entity;

public class UserFavoriteVenue:AuditableEntity
{
    public int VenueId { get; set; }
    public Venue Venue { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}