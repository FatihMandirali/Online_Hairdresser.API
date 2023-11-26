using Online_Hairdresser.Models.Enums;

namespace Online_Hairdresser.Data.Entity;

public class Service:AuditableEntity
{
    public string Name { get; set; }
    public string Image { get; set; }//todo example: saç, sakal 
    public VenueTypeEnum VenueType { get; set; }
}