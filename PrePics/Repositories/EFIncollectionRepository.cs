using Microsoft.EntityFrameworkCore;
using PrePics.Models;

namespace PrePics.Repositories
{
    public class EFIncollectionRepository : IInCollectionRepository
    {
        private readonly PrePicsDbContext _context;
        public EFIncollectionRepository(PrePicsDbContext context)
        {
            _context = context;
        }
        public async Task<List<InCollection>> GetAllInCollectionsAsync()
        {
            return await _context.inCollections.ToListAsync();
        }

        public async Task<InCollection> GetInCollectionByIdAsync(int id)
        {
            return await _context.inCollections.FindAsync(id);
        }

        public async Task AddInCollectionAsync(InCollection inCollection)
        {
            _context.inCollections.Add(inCollection);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateInCollectionAsync(InCollection inCollection)
        {
            _context.Entry(inCollection).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInCollectionAsync(int id)
        {
            var inCollection = await _context.inCollections.FindAsync(id);
            if (inCollection != null)
            {
                _context.inCollections.Remove(inCollection);
                await _context.SaveChangesAsync();
            }
        }
    }
}
