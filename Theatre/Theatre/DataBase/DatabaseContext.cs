using Microsoft.EntityFrameworkCore;
using Theatre.Models;

namespace Theatre.DataBase
{
    /// <summary>
    /// Контекст базы данных для работы с таблицей записей о представлениях.
    /// </summary>
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Свойство, предоставляющее доступ к таблице БД.
        /// </summary>
        public DbSet<Performance> Performances {
            get { return Set<Performance>(); }
        }

        /// <summary>
        /// Строка подлкючения к БД.
        /// </summary>
        private readonly string СonnectionString;

        /// <summary>
        /// Конструктор для инициализации контекста БД с указанной строкой подключения.
        /// </summary>
        /// <param name="connectionString">Строка подключения к БД.</param>
        public DatabaseContext(string connectionString)
        {
            СonnectionString = connectionString;
        }

        /// <summary>
        /// Метод, конфигурирующий контекст БД, устанавливая строку подключения и тип БД (SQLite).
        /// </summary>
        /// <param name="optionsBuilder">Объект для конфигурации параметров БД.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(СonnectionString);
        }
    }
}
