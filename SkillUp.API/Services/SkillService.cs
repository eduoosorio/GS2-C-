using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SkillUp.API.Data;
using SkillUp.API.DTOs;
using SkillUp.API.Models;
using SkillUp.API.Repositories;

namespace SkillUp.API.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _repository;
        private readonly IMapper _mapper;
        private readonly SkillUpDbContext _context;

        public SkillService(ISkillRepository repository, IMapper mapper, SkillUpDbContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<SkillDTO>> GetAllAsync()
        {
            var skills = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<SkillDTO>>(skills);
        }

        public async Task<SkillDTO?> GetByIdAsync(int id)
        {
            var skill = await _repository.GetByIdAsync(id);
            return skill == null ? null : _mapper.Map<SkillDTO>(skill);
        }

        public async Task<SkillDTO> CreateAsync(CreateSkillDTO createSkillDTO)
        {
            var skill = _mapper.Map<Skill>(createSkillDTO);
            var createdSkill = await _repository.CreateAsync(skill);
            return _mapper.Map<SkillDTO>(createdSkill);
        }

        public async Task<SkillDTO?> UpdateAsync(int id, UpdateSkillDTO updateSkillDTO)
        {
            var skill = await _repository.GetByIdAsync(id);
            if (skill == null)
                return null;

            _mapper.Map(updateSkillDTO, skill);
            var updatedSkill = await _repository.UpdateAsync(skill);
            return _mapper.Map<SkillDTO>(updatedSkill);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TopSkillDTO>> GetTopSkillsAsync(int top = 10)
        {
            var topSkills = await _context.UserSkills
                .GroupBy(us => new { us.SkillId, us.Skill.Name })
                .Select(g => new TopSkillDTO
                {
                    SkillId = g.Key.SkillId,
                    SkillName = g.Key.Name,
                    Count = g.Count()
                })
                .OrderByDescending(ts => ts.Count)
                .Take(top)
                .ToListAsync();

            return topSkills;
        }
    }
}

