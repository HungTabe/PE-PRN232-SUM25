using Microsoft.EntityFrameworkCore;
using SportShoeManagement.Data;
using SportShoeManagement.DTOs;
using SportShoeManagement.Interfaces;
using SportShoeManagement.Models;

namespace SportShoeManagement.Services
{
    public class SportShoeService : ISportShoeService
    {

        private readonly SportShoeDbContext _context;

        public SportShoeService(SportShoeDbContext context)
        {
            _context = context;
        }

        public async Task<SportShoe> AddAsync(SportShoeDto dto)
        {
            var shoe = new SportShoe
            {
                Name = dto.Name,
                Price = dto.Price,
                Category = dto.Category,
                IsDeleted = false,
            };
            _context.SportShoes.Add(shoe);
            await _context.SaveChangesAsync();
            return shoe;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var shoe = await _context.SportShoes.FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
            if (shoe == null) return false;
            shoe.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SportShoe>> GetAllAsync()
        {
            return await _context.SportShoes.Where(s => !s.IsDeleted).ToListAsync();
        }

        public async Task<SportShoe> GetByIdAsync(int id)
        {
            return await _context.SportShoes.FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        public async Task<SportShoe> UpdateAsync(int id, SportShoeDto dto)
        {
            var shoe = await _context.SportShoes.FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
            if (shoe == null) return null;
            shoe.Name = dto.Name;
            shoe.Price = dto.Price;
            shoe.Category = dto.Category;
            await _context.SaveChangesAsync();
            return shoe;
        }
    }
}
