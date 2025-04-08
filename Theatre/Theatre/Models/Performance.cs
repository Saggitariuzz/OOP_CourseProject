using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theatre.Models
{
    public class Performance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string PerformanceName { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string DirectorName { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Genre { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime PremiereDate { get; set; }

        [Required]
        [Column(TypeName = "time")]
        public TimeSpan Duration { get; set; }

        [Required]
        [Column(TypeName = "numeric")]
        public decimal TicketCost { get; set; }
    }
}
