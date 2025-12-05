using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusManagementAPI.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ScheduleId { get; set; }

        [ForeignKey("ScheduleId")]
        public Schedule? Schedule { get; set; }

        [Required]
        [StringLength(100)]
        public string PassengerName { get; set; } = string.Empty;

        [Required]
        public int SeatNumber { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }
    }
}