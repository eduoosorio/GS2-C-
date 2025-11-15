using Microsoft.EntityFrameworkCore;
using SkillUp.API.Data;
using SkillUp.API.Models;

namespace SkillUp.API.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly SkillUpDbContext _context;

        public SkillRepository(SkillUpDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Skill>> GetAllAsync()
        {
            return await _context.Skills.ToListAsync();
        }

        public async Task<Skill?> GetByIdAsync(int id)
        {
            return await _context.Skills
                .Include(s => s.UserSkills)
                .ThenInclude(us => us.User)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Skill> CreateAsync(Skill skill)
        {
            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();
            return skill;
        }

        public async Task<Skill> UpdateAsync(Skill skill)
        {
            skill.UpdatedAt = DateTime.UtcNow;
            _context.Skills.Update(skill);
            await _context.SaveChangesAsync();
            return skill;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null)
                return false;

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Skills.AnyAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Skill>> GetTopSkillsAsync(int top)
        {
            return await _context.Skills
                .OrderByDescending(s => s.UserSkills.Count)
                .Take(top)
                .ToListAsync();
        }
    }
}

