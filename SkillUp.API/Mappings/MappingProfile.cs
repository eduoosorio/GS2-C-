using AutoMapper;
using SkillUp.API.DTOs;
using SkillUp.API.Models;

namespace SkillUp.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User Mappings
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<CreateUserDTO, User>();
            CreateMap<UpdateUserDTO, User>();

            // Skill Mappings
            CreateMap<Skill, SkillDTO>().ReverseMap();
            CreateMap<CreateSkillDTO, Skill>();
            CreateMap<UpdateSkillDTO, Skill>();

            // Course Mappings
            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<CreateCourseDTO, Course>();
            CreateMap<UpdateCourseDTO, Course>();

            // UserSkill Mappings
            CreateMap<UserSkill, UserSkillDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.SkillName, opt => opt.MapFrom(src => src.Skill.Name));
            CreateMap<CreateUserSkillDTO, UserSkill>();
            CreateMap<UpdateUserSkillDTO, UserSkill>();
        }
    }
}

