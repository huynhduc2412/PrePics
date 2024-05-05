using PrePics.Models;

namespace PrePics.Repositories
{
    public interface IGalleryRepository
    {
        Task<IEnumerable<Gallery>> GetAllAsync();
        Task<Gallery> GetByIdAsync(string id);
        Task AddAsync(Gallery g);
        Task DeleteAsync(string id);
        Task UpdateAsync(Gallery g);
    }
}
