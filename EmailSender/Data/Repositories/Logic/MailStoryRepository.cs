using EmailSender.Data.Repositories.Interfaces;
using EmailSender.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailSender.Data.Repositories.Logic
{
    public class MailStoryRepository : IMailStoryRepository
    {
        private readonly DbSet<MailStory> _mailStories;

        public MailStoryRepository(DatabaseContext databaseContext)
        {
            var context = databaseContext ?? throw new ArgumentNullException(nameof(DatabaseContext));
            _mailStories = context.MailStories;
        }

        public async Task AddAsync(MailStory mailStory)
        {
            await _mailStories.AddAsync(mailStory);
        }

        public async Task<IEnumerable<MailStory>> GetAsync()
        {
            return await _mailStories.ToListAsync();
        }
    }
}
