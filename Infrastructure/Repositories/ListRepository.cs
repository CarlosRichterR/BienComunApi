﻿using BienComun.Core.Entities;
using BienComun.Core.Repository;
using BIenComun.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<GiftList>> GetAllAsync()
        {
            return await _context.GiftLists
                .Include(l => l.Products)
                .ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var list = await _context.GiftLists.FindAsync(id);
            if (list != null)
            {
                _context.GiftLists.Remove(list);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<GiftList?> GetByIdWithProductsAsync(int id)
        {
            return await _context.GiftLists
                .Include(l => l.Products)
                    .ThenInclude(glp => glp.Product)
                        .ThenInclude(p => p.Images)
                .Include(l => l.Products)
                    .ThenInclude(glp => glp.Product)
                        .ThenInclude(p => p.Category)
                .Include(l => l.Products)
                    .ThenInclude(glp => glp.Product)
                        .ThenInclude(p => p.Supplier)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task UpdateAsync(GiftList list)
        {
            _context.GiftLists.Update(list);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GiftListProduct>> GetProductsWithContributionsAsync(int listId)
        {
            return await _context.GiftListProducts
                .Include(glp => glp.Contributions)
                .Include(glp => glp.Product)
                .Where(glp => glp.GiftListId == listId)
                .ToListAsync();
        }

        // Puedes agregar más métodos según sea necesario
    }
}
