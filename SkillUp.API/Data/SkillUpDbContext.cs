using Microsoft.EntityFrameworkCore;
using SkillUp.API.Models;

namespace SkillUp.API.Data
{
    public class SkillUpDbContext : DbContext
    {
        public SkillUpDbContext(DbContextOptions<SkillUpDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // UserSkill - Composite Key
            modelBuilder.Entity<UserSkill>()
                .HasKey(us => us.Id);

            modelBuilder.Entity<UserSkill>()
                .HasIndex(us => new { us.UserId, us.SkillId })
                .IsUnique();

            // Relationships
            modelBuilder.Entity<UserSkill>()
                .HasOne(us => us.User)
                .WithMany(u => u.UserSkills)
                .HasForeignKey(us => us.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserSkill>()
                .HasOne(us => us.Skill)
                .WithMany(s => s.UserSkills)
                .HasForeignKey(us => us.SkillId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurar precisão do decimal para Price
            modelBuilder.Entity<Course>()
                .Property(c => c.Price)
                .HasPrecision(18, 2);

            // Seed Data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Skills
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "Inteligência Artificial", Description = "Conhecimento em IA e Machine Learning", Category = "Tecnologia", CreatedAt = DateTime.UtcNow },
                new Skill { Id = 2, Name = "Cloud Computing", Description = "Habilidades em serviços de nuvem (AWS, Azure, GCP)", Category = "Tecnologia", CreatedAt = DateTime.UtcNow },
                new Skill { Id = 3, Name = "Data Science", Description = "Análise de dados e estatística", Category = "Tecnologia", CreatedAt = DateTime.UtcNow },
                new Skill { Id = 4, Name = "Liderança Ágil", Description = "Gestão de equipes em metodologias ágeis", Category = "Gestão", CreatedAt = DateTime.UtcNow },
                new Skill { Id = 5, Name = "Comunicação Digital", Description = "Habilidades de comunicação em ambientes digitais", Category = "Soft Skills", CreatedAt = DateTime.UtcNow }
            );

            // Seed Courses
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Title = "Fundamentos de IA", Description = "Curso introdutório sobre Inteligência Artificial", Duration = 40, Instructor = "Dr. João Silva", Price = 299.99m, CreatedAt = DateTime.UtcNow },
                new Course { Id = 2, Title = "AWS Essentials", Description = "Curso completo sobre Amazon Web Services", Duration = 60, Instructor = "Maria Santos", Price = 399.99m, CreatedAt = DateTime.UtcNow },
                new Course { Id = 3, Title = "Data Science com Python", Description = "Análise de dados usando Python e Pandas", Duration = 50, Instructor = "Carlos Oliveira", Price = 349.99m, CreatedAt = DateTime.UtcNow }
            );
        }
    }
}

