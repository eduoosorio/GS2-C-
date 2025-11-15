using SkillUp.API.Models;

namespace SkillUp.API.Repositories
{
    public interface ISkillRepository
    {
        Task<IEnumerable<Skill>> GetAllAsync();
        Task<Skill?> GetByIdAsync(int id);
        Task<Skill> CreateAsync(Skill skill);
        Task<Skill> UpdateAsync(Skill skill);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<IEnumerable<Skill>> GetTopSkillsAsync(int top);
    }
}

