namespace Online_Hairdresser.Models.Models.Response.CityCount;

public class CityCountResponse
{
    public string CityName { get; set; }
    public List<CountyResponse> Counties { get; set; }
}

public class CountyResponse
{
    public string CountyName { get; set; }
    public int Id { get; set; }
}