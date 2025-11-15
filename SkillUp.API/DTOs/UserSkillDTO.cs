namespace SkillUp.API.DTOs
{
    public class UserSkillDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int SkillId { get; set; }
        public string SkillName { get; set; } = string.Empty;
        public int ProficiencyLevel { get; set; }
        public DateTime AcquiredAt { get; set; }
    }

    public class CreateUserSkillDTO
    {
        public int UserId { get; set; }
        public int SkillId { get; set; }
        public int ProficiencyLevel { get; set; }
    }

    public class UpdateUserSkillDTO
    {
        public int ProficiencyLevel { get; set; }
    }
}

