using NetTopologySuite.Geometries;
using Online_Hairdresser.Models.Enums;

namespace Online_Hairdresser.Data.Entity;

public class Venue:AuditableEntity
{
    public int CityCountyId { get; set; }
    public CityCounty CityCounty { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Motto { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public double Star { get; set; }
    public string MainImage { get; set; }
    public double ProcessInterval { get; set; }
    public VenueTypeEnum VenueType { get; set; }
    public ICollection<VenueFile> VenueFiles { get; set; }
    public ICollection<VenueService> VenueServices { get; set; }
    public ICollection<VenueWorker> VenueWorkers { get; set; }
}