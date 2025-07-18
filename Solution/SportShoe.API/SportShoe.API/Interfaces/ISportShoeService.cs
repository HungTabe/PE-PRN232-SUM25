using SportShoeManagement.API.Models;
using SportShoeManagement.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportShoeManagement.API.Interfaces
{
    public interface ISportShoeService
    {
        Task<IEnumerable<SportShoe>> GetAllAsync();
        Task<SportShoe> GetByIdAsync(int id);
        Task<SportShoe> AddAsync(SportShoeCreateDto dto);
        Task<SportShoe> UpdateAsync(int id, SportShoeUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
} 