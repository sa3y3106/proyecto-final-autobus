using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusManagementAPI.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BusId { get; set; }

        [ForeignKey("BusId")]
        public Bus? Bus { get; set; }

        [Required]
        public int RouteId { get; set; }

        [ForeignKey("RouteId")]
        public BusRoute? Route { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        public ICollection<Reservation>? Reservations { get; set; }
    }
}