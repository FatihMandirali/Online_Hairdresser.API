using Online_Hairdresser.Models.Enums;

namespace Online_Hairdresser.Models.Models.Request.Venue;

public class VenueListRequest
{
    public int Page { get; set; }
    public string? Search { get; set; }
    public int CityCountyId { get; set; }
    public double Longitute { get; set; }
    public double Latitute { get; set; }
    public VenueTypeEnum VenueType { get; set; }
}