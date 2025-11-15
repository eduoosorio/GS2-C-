namespace SkillUp.API.Models
{
    public class UserSkill
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SkillId { get; set; }
        public int ProficiencyLevel { get; set; } // 1-5
        public DateTime AcquiredAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Navigation Properties
        public virtual User User { get; set; } = null!;
        public virtual Skill Skill { get; set; } = null!;
    }
}

