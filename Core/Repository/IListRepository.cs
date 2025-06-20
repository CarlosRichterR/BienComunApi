using BienComun.Core.Entities;

namespace BienComun.Core.Repository;

public interface IListRepository
{
    Task AddAsync(GiftList list);
    Task<List<GiftList>> GetAllAsync();
    Task<GiftList?> GetByIdWithProductsAsync(int id);
    Task UpdateAsync(GiftList list);
    Task DeleteAsync(int id);
    Task<List<GiftListProduct>> GetProductsWithContributionsAsync(int listId);
}
