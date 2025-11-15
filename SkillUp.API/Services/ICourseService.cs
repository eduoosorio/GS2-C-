using SkillUp.API.DTOs;

namespace SkillUp.API.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDTO>> GetAllAsync();
        Task<CourseDTO?> GetByIdAsync(int id);
        Task<CourseDTO> CreateAsync(CreateCourseDTO createCourseDTO);
        Task<CourseDTO?> UpdateAsync(int id, UpdateCourseDTO updateCourseDTO);
        Task<bool> DeleteAsync(int id);
    }
}

