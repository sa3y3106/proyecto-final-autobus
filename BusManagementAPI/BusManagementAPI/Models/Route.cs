using System.ComponentModel.DataAnnotations;

namespace BusManagementAPI.Models
{
    public class BusRoute
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string RouteName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Origin { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Destination { get; set; } = string.Empty;

        [Required]
        public double Distance { get; set; }

        public ICollection<Schedule>? Schedules { get; set; }
    }
}