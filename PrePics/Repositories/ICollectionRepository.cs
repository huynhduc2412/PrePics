using PrePics.Models;


namespace PrePics.Repositories
{
    public interface ICollectionRepository
    {
        Task<List<Collection>> GetAllCollectionsAsync();
        Task<Collection> GetCollectionByIdAsync(string id);
        Task AddCollectionAsync(Collection collection);
        Task UpdateCollectionAsync(Collection collection);
        Task DeleteCollectionAsync(string id);
    }
}
