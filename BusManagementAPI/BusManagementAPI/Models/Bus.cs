using System.ComponentModel.DataAnnotations;

namespace BusManagementAPI.Models
{
    public class Bus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string BusNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Model { get; set; } = string.Empty;

        [Required]
        public int Capacity { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = string.Empty;

        public ICollection<Schedule>? Schedules { get; set; }
    }
}