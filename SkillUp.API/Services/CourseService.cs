using AutoMapper;
using SkillUp.API.DTOs;
using SkillUp.API.Models;
using SkillUp.API.Repositories;

namespace SkillUp.API.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseDTO>> GetAllAsync()
        {
            var courses = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CourseDTO>>(courses);
        }

        public async Task<CourseDTO?> GetByIdAsync(int id)
        {
            var course = await _repository.GetByIdAsync(id);
            return course == null ? null : _mapper.Map<CourseDTO>(course);
        }

        public async Task<CourseDTO> CreateAsync(CreateCourseDTO createCourseDTO)
        {
            var course = _mapper.Map<Course>(createCourseDTO);
            var createdCourse = await _repository.CreateAsync(course);
            return _mapper.Map<CourseDTO>(createdCourse);
        }

        public async Task<CourseDTO?> UpdateAsync(int id, UpdateCourseDTO updateCourseDTO)
        {
            var course = await _repository.GetByIdAsync(id);
            if (course == null)
                return null;

            _mapper.Map(updateCourseDTO, course);
            var updatedCourse = await _repository.UpdateAsync(course);
            return _mapper.Map<CourseDTO>(updatedCourse);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}

