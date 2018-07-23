using System;
using System.Threading.Tasks;

namespace EmailSender.Data.Infrastructure
{
    /// <summary>
    /// Единица работы с БД.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;

        public UnitOfWork(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(DatabaseContext));
        }

        /// <summary>
        /// Сохраняет изменения в БД.
        /// </summary>
        public async Task SaveChangesAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }
    }
}
