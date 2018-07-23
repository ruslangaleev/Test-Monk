using EmailSender.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailSender.Data.Repositories.Interfaces
{
    public interface IMailStoryRepository
    {
        Task<IEnumerable<MailStory>> GetAsync();

        Task AddAsync(MailStory mailStory);
    }
}
