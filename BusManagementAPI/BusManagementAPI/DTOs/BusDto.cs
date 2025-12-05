namespace BusManagementAPI.DTOs
{
    public class BusDto
    {
        public string BusNumber { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public int Year { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}