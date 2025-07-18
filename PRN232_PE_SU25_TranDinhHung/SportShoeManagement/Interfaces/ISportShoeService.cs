using SportShoeManagement.DTOs;
using SportShoeManagement.Models;

namespace SportShoeManagement.Interfaces
{
    public interface ISportShoeService
    {
        // Get List
        Task<IEnumerable<SportShoe>> GetAllAsync();
        // Get by Id
        Task<SportShoe> GetByIdAsync(int id);
        // Add 
        Task<SportShoe> AddAsync(SportShoeDto dto);
        // Update
        Task<SportShoe> UpdateAsync(int id ,SportShoeDto dto);
        // Delete
        Task<bool> DeleteAsync(int id);


    }
}
