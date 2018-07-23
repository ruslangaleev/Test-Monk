using EmailSender.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailSender.Data
{
    /// <summary>
    /// Контекст для работы с базой данных.
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DbSet<MailStory> MailStories { get; set; }

        /// <summary>
        /// Контекст для работы с базой данных.
        /// </summary>
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    }
}
