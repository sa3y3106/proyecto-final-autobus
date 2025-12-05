namespace BusManagementAPI.DTOs
{
    public class ReservationDto
    {
        public int ScheduleId { get; set; }
        public string PassengerName { get; set; } = string.Empty;
        public int SeatNumber { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}