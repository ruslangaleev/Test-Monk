using EmailSender.Data.Repositories.Interfaces;
using EmailSender.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailSender.Data.Repositories.Logic
{
    /// <summary>
    /// Репозиторий для работы с историей сообщений.
    /// </summary>
    public class MailStoryRepository : IMailStoryRepository
    {
        /// <summary>
        /// История сообщений.
        /// </summary>
        private readonly DbSet<MailStory> _mailStories;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="databaseContext"></param>
        public MailStoryRepository(DatabaseContext databaseContext)
        {
            var context = databaseContext ?? throw new ArgumentNullException(nameof(DatabaseContext));
            _mailStories = context.MailStories;
        }

        /// <summary>
        /// Добавит новую историю сообщения.
        /// </summary>
        public async Task AddAsync(MailStory mailStory)
        {
            await _mailStories.AddAsync(mailStory);
        }

        /// <summary>
        /// Вернет список всех сообщений.
        /// </summary>
        public async Task<IEnumerable<MailStory>> GetAsync()
        {
            return await _mailStories.ToListAsync();
        }
    }
}
