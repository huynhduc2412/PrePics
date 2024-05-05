using PrePics.Models;

namespace PrePics.Repositories
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllAsync();
        Task<Tag> GetByIdAsync(string id);
        Task AddAsync(Tag t);
        Task DeleteAsync(string id);
        Task UpdateAsync(Tag t);
    }
}
