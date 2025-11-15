using SkillUp.API.DTOs;

namespace SkillUp.API.Services
{
    public interface ISkillService
    {
        Task<IEnumerable<SkillDTO>> GetAllAsync();
        Task<SkillDTO?> GetByIdAsync(int id);
        Task<SkillDTO> CreateAsync(CreateSkillDTO createSkillDTO);
        Task<SkillDTO?> UpdateAsync(int id, UpdateSkillDTO updateSkillDTO);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<TopSkillDTO>> GetTopSkillsAsync(int top = 10);
    }
}

