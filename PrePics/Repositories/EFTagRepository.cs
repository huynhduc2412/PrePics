using Microsoft.EntityFrameworkCore;
using PrePics.Models;

namespace PrePics.Repositories
{
    public class EFTagRepository : ITagRepository
    {
        private readonly PrePicsDbContext _context;
        public EFTagRepository(PrePicsDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Tag t)
        {
           var f = _context.tags.FirstOrDefault(p=>p.title == t.title);
            if (f == null || f.isDeleted==false)
            {
                _context.tags.Add(t);
                await _context.SaveChangesAsync();
            }

        }
        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await _context.tags.ToListAsync();
        }
        public async Task<Tag> GetByIdAsync(string id)
        {
            return await _context.tags.FindAsync(id);
        }

        public async Task DeleteAsync(string Id)
        {
            var f = _context.tags.FirstOrDefault(p => p.id == Id);
            if (f != null)
            {
                f.isDeleted = true;
                _context.tags.Update(f);
                await _context.SaveChangesAsync();
            }
        }
        
        public async Task UpdateAsync(Tag t)
        {
            _context.tags.Update(t);
            await _context.SaveChangesAsync();
        }
    }
}
