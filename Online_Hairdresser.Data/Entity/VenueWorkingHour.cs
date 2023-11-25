using Online_Hairdresser.Models.Enums;

namespace Online_Hairdresser.Data.Entity;

public class VenueWorkingHour:AuditableEntity
{
    public int VenueId { get; set; }
    public Venue Venue { get; set; }
    public DayOfWeekEnum Day { get; set; }
    public TimeSpan StartHour { get; set; }
    public TimeSpan EndHour { get; set; }
    public bool IsOpen { get; set; }
}