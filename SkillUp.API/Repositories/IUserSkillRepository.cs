using SkillUp.API.Models;

namespace SkillUp.API.Repositories
{
    public interface IUserSkillRepository
    {
        Task<IEnumerable<UserSkill>> GetAllAsync();
        Task<UserSkill?> GetByIdAsync(int id);
        Task<UserSkill> CreateAsync(UserSkill userSkill);
        Task<UserSkill> UpdateAsync(UserSkill userSkill);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> ExistsUserSkillAsync(int userId, int skillId);
    }
}

