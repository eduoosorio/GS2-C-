using AutoMapper;
using SkillUp.API.DTOs;
using SkillUp.API.Models;
using SkillUp.API.Repositories;

namespace SkillUp.API.Services
{
    public class UserSkillService : IUserSkillService
    {
        private readonly IUserSkillRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;

        public UserSkillService(
            IUserSkillRepository repository,
            IUserRepository userRepository,
            ISkillRepository skillRepository,
            IMapper mapper)
        {
            _repository = repository;
            _userRepository = userRepository;
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserSkillDTO>> GetAllAsync()
        {
            var userSkills = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserSkillDTO>>(userSkills);
        }

        public async Task<UserSkillDTO?> GetByIdAsync(int id)
        {
            var userSkill = await _repository.GetByIdAsync(id);
            return userSkill == null ? null : _mapper.Map<UserSkillDTO>(userSkill);
        }

        public async Task<UserSkillDTO> CreateAsync(CreateUserSkillDTO createUserSkillDTO)
        {
            // Validate User and Skill exist
            var userExists = await _userRepository.ExistsAsync(createUserSkillDTO.UserId);
            var skillExists = await _skillRepository.ExistsAsync(createUserSkillDTO.SkillId);

            if (!userExists || !skillExists)
                throw new ArgumentException("User or Skill not found");

            // Check if UserSkill already exists
            var exists = await _repository.ExistsUserSkillAsync(createUserSkillDTO.UserId, createUserSkillDTO.SkillId);
            if (exists)
                throw new InvalidOperationException("User already has this skill");

            // Validate ProficiencyLevel
            if (createUserSkillDTO.ProficiencyLevel < 1 || createUserSkillDTO.ProficiencyLevel > 5)
                throw new ArgumentException("ProficiencyLevel must be between 1 and 5");

            var userSkill = _mapper.Map<UserSkill>(createUserSkillDTO);
            var createdUserSkill = await _repository.CreateAsync(userSkill);
            return _mapper.Map<UserSkillDTO>(createdUserSkill);
        }

        public async Task<UserSkillDTO?> UpdateAsync(int id, UpdateUserSkillDTO updateUserSkillDTO)
        {
            var userSkill = await _repository.GetByIdAsync(id);
            if (userSkill == null)
                return null;

            // Validate ProficiencyLevel
            if (updateUserSkillDTO.ProficiencyLevel < 1 || updateUserSkillDTO.ProficiencyLevel > 5)
                throw new ArgumentException("ProficiencyLevel must be between 1 and 5");

            _mapper.Map(updateUserSkillDTO, userSkill);
            var updatedUserSkill = await _repository.UpdateAsync(userSkill);
            return _mapper.Map<UserSkillDTO>(updatedUserSkill);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}

