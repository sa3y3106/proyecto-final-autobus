namespace BusManagementAPI.DTOs
{
    public class RouteDto
    {
        public string RouteName { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public double Distance { get; set; }
    }
}