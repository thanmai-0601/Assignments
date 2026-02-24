using Insurance_crud_api.DTOs;
using Insurance_crud_api.Models;

namespace Insurance_crud_api.Services.Interfaces
{
    public interface IPolicyService
    {
        Task<IEnumerable<Policy>> GetAllAsync();
        Task<Policy?> GetByIdAsync(int id);
        Task<Policy> CreateAsync(PolicyDto dto);
        Task<Policy?> UpdateAsync(int id, PolicyDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
