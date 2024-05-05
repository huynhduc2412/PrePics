using PrePics.Models;

namespace PrePics.Repositories
{
    public interface IInCollectionRepository
    {
        Task<List<InCollection>> GetAllInCollectionsAsync();
        Task<InCollection> GetInCollectionByIdAsync(int id);
        Task AddInCollectionAsync(InCollection inCollection);
        Task UpdateInCollectionAsync(InCollection inCollection);
        Task DeleteInCollectionAsync(int id);
    }
}
