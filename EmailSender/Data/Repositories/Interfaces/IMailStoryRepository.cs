using EmailSender.Models;
using System.Threading.Tasks;

namespace EmailSender.Data.Repositories.Interfaces
{
    public interface IMailStoryRepository
    {
        Task Add(MailStory mailStory);
    }
}
