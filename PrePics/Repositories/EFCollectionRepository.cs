using Microsoft.EntityFrameworkCore;
using PrePics.Models;

namespace PrePics.Repositories
{
    public class EFCollectionRepository : ICollectionRepository
    {
        private readonly PrePicsDbContext _context;
        public EFCollectionRepository(PrePicsDbContext context)
        {
            _context = context;
        }
        public async Task<List<Collection>> GetAllCollectionsAsync()
        {
            return await _context.collections.ToListAsync();
        }

        public async Task<Collection> GetCollectionByIdAsync(string id)
        {
            return await _context.collections.FindAsync(id);
        }

        public async Task AddCollectionAsync(Collection collection)
        {
            _context.collections.Add(collection);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCollectionAsync(Collection collection)
        {
            _context.Entry(collection).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCollectionAsync(string id)
        {
            var collection = await _context.collections.FindAsync(id);
            if (collection != null)
            {
                _context.collections.Remove(collection);
                await _context.SaveChangesAsync();
            }
        }
    }
}
