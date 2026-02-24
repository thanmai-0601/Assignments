using Insurance_crud_api.Data;
using Insurance_crud_api.DTOs;
using Insurance_crud_api.Models;
using Insurance_crud_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Insurance_crud_api.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly AppDbContext _context;

        public PolicyService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Policy>> GetAllAsync()
        {
            return await _context.Policies.ToListAsync();
        }

        public async Task<Policy?> GetByIdAsync(int id)
        {
            return await _context.Policies.FindAsync(id);
        }

        public async Task<Policy> CreateAsync(PolicyDto dto)
        {
            var policy = new Policy
            {
                PolicyName     = dto.PolicyName,
                Provider       = dto.Provider,
                Premium        = dto.Premium,
                CoverageAmount = dto.CoverageAmount
            };

            _context.Policies.Add(policy);
            await _context.SaveChangesAsync();
            return policy;
        }

        public async Task<Policy?> UpdateAsync(int id, PolicyDto dto)
        {
            var policy = await _context.Policies.FindAsync(id);
            if (policy == null) return null;

            policy.PolicyName     = dto.PolicyName;
            policy.Provider       = dto.Provider;
            policy.Premium        = dto.Premium;
            policy.CoverageAmount = dto.CoverageAmount;

            await _context.SaveChangesAsync();
            return policy;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var policy = await _context.Policies.FindAsync(id);
            if (policy == null) return false;

            _context.Policies.Remove(policy);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
