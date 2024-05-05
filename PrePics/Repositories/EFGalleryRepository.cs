using Microsoft.EntityFrameworkCore;
using PrePics.Models;

namespace PrePics.Repositories
{
    public class EFGalleryRepository : IGalleryRepository
    {
        private readonly PrePicsDbContext _context;
        public EFGalleryRepository(PrePicsDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Gallery t)
        {
            var f = _context.galleries.Add(t);
           await  _context.SaveChangesAsync();

        }
        public async Task<IEnumerable<Gallery>> GetAllAsync()
        {
            return await _context.galleries.ToListAsync();
        }
        public async Task<Gallery> GetByIdAsync(string id)
        {
            return await _context.galleries.FindAsync(id);
        }

        public async Task DeleteAsync(string Id)
        {
            var f = _context.galleries.FirstOrDefault(p => p.id == Id);
            if (f != null)
            {
                _context.galleries.Remove(f);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Gallery t)
        {
            _context.galleries.Update(t);
            await _context.SaveChangesAsync();
        }
    }
}
