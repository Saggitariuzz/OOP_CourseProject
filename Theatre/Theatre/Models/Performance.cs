using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theatre.Models
{
    /// <summary>
    /// Класс, представляющий запись о тетральном представлении в БД.
    /// </summary>
    public class Performance
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Название спектакля.
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string PerformanceName { get; set; }

        /// <summary>
        /// Имя режиссера.
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string DirectorName { get; set; }

        /// <summary>
        /// Жанр спектакля.
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Genre { get; set; }

        /// <summary>
        /// Дата премьеры спектакля.
        /// </summary>
        [Required]
        [Column(TypeName = "date")]
        public DateTime PremiereDate { get; set; }

        /// <summary>
        /// Продолжительность спектакля.
        /// </summary>
        [Required]
        [Column(TypeName = "time")]
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Стоимость билета на спектакль.
        /// </summary>
        [Required]
        [Column(TypeName = "numeric")]
        public decimal TicketCost { get; set; }
    }
}
