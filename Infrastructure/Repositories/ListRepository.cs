using BienComun.Core.Entities;
using BienComun.Core.Repository;
using BIenComun.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienComun.Infrastructure.Repositories
{
    public class ListRepository : IListRepository
    {
        private readonly AppDbContext _context;

        public ListRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(GiftList list)
        {
            await _context.GiftLists.AddAsync(list);
            await _context.SaveChangesAsync();
        }

        // Puedes agregar más métodos según sea necesario
    }
}
