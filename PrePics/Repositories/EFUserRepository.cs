using Microsoft.EntityFrameworkCore;
using PrePics.Models;

namespace PrePics.Repositories
{
    public class EFUserRepository : IUserRepository
    {
        private readonly PrePicsDbContext _context;
        public EFUserRepository(PrePicsDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(string id)
        {
            var userToDelete = await _context.users.FindAsync(id);
            if (userToDelete != null)
            {
                userToDelete.isActive = false;
                _context.Entry(userToDelete).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.users.ToListAsync();
        }
        public async Task<User> GetByIdAsync(string id)
        {
            return await _context.users.FindAsync(id);
        }
        public async Task UpdateAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
