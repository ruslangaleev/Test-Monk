using System.Threading.Tasks;

namespace EmailSender.Data.Infrastructure
{
    /// <summary>
    /// Единица работы с БД.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Сохраняет изменения в БД.
        /// </summary>
        Task SaveChangesAsync();
    }
}
