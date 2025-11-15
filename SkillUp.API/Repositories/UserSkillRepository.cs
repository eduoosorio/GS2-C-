using Microsoft.EntityFrameworkCore;
using SkillUp.API.Data;
using SkillUp.API.Models;

namespace SkillUp.API.Repositories
{
    public class UserSkillRepository : IUserSkillRepository
    {
        private readonly SkillUpDbContext _context;

        public UserSkillRepository(SkillUpDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserSkill>> GetAllAsync()
        {
            return await _context.UserSkills
                .Include(us => us.User)
                .Include(us => us.Skill)
                .ToListAsync();
        }

        public async Task<UserSkill?> GetByIdAsync(int id)
        {
            return await _context.UserSkills
                .Include(us => us.User)
                .Include(us => us.Skill)
                .FirstOrDefaultAsync(us => us.Id == id);
        }

        public async Task<UserSkill> CreateAsync(UserSkill userSkill)
        {
            _context.UserSkills.Add(userSkill);
            await _context.SaveChangesAsync();
            return userSkill;
        }

        public async Task<UserSkill> UpdateAsync(UserSkill userSkill)
        {
            userSkill.UpdatedAt = DateTime.UtcNow;
            _context.UserSkills.Update(userSkill);
            await _context.SaveChangesAsync();
            return userSkill;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var userSkill = await _context.UserSkills.FindAsync(id);
            if (userSkill == null)
                return false;

            _context.UserSkills.Remove(userSkill);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.UserSkills.AnyAsync(us => us.Id == id);
        }

        public async Task<bool> ExistsUserSkillAsync(int userId, int skillId)
        {
            return await _context.UserSkills.AnyAsync(us => us.UserId == userId && us.SkillId == skillId);
        }
    }
}

