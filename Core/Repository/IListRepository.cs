using BienComun.Core.Entities;

namespace BienComun.Core.Repository;

public interface IListRepository
{
    Task AddAsync(GiftList list);
  
}
