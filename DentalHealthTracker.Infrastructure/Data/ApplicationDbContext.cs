using DentalHealthTracker.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DentalHealthTracker.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<HealthRecord> HealthRecords { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<HealthSuggestion> HealthSuggestions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Unique Constraint for Email
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // One-to-Many: User -> Goals
            modelBuilder.Entity<Goal>()
                .HasOne(g => g.User)
                .WithMany(u => u.Goals)
                .HasForeignKey(g => g.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many: User -> HealthRecords (ON DELETE NO ACTION)
            modelBuilder.Entity<HealthRecord>()
                .HasOne(hr => hr.User)
                .WithMany(u => u.HealthRecords)
                .HasForeignKey(hr => hr.UserId)
                .OnDelete(DeleteBehavior.NoAction); // NoAction ile cycle hatasını önledik

            // One-to-Many: Goal -> HealthRecords (ON DELETE NO ACTION)
            modelBuilder.Entity<HealthRecord>()
                .HasOne(hr => hr.Goal)
                .WithMany(g => g.HealthRecords)
                .HasForeignKey(hr => hr.GoalId)
                .OnDelete(DeleteBehavior.NoAction); // NoAction ile cycle hatasını önledik

            // One-to-Many: User -> Notes
            modelBuilder.Entity<Note>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notes)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HealthSuggestion>().HasData(
                new HealthSuggestion { Id = 1, Content = "Dişlerinizi günde en az 2 kez fırçalayın.", IsActive = true, CreatedAt = new DateTime(2024, 03, 20, 12, 00, 00) },
                new HealthSuggestion { Id = 2, Content = "Şekerli yiyeceklerden kaçının.", IsActive = true, CreatedAt = new DateTime(2024, 03, 20, 12, 00, 00) },
                new HealthSuggestion { Id = 3, Content = "Diş ipi kullanmayı ihmal etmeyin.", IsActive = true, CreatedAt = new DateTime(2024, 03, 20, 12, 00, 00) },
                new HealthSuggestion { Id = 4, Content = "Diş hekiminize düzenli olarak görünün.", IsActive = true, CreatedAt = new DateTime(2024, 03, 20, 12, 00, 00) },
                new HealthSuggestion { Id = 5, Content = "Sigara ve alkol tüketimini azaltın.", IsActive = true, CreatedAt = new DateTime(2024, 03, 20, 12, 00, 00) },
                new HealthSuggestion { Id = 6, Content = "Ağız çalkalama suyu kullanın.", IsActive = true, CreatedAt = new DateTime(2024, 03, 20, 12, 00, 00) },
                new HealthSuggestion { Id = 7, Content = "Sağlıklı beslenme diş sağlığınızı korur.", IsActive = true, CreatedAt = new DateTime(2024, 03, 20, 12, 00, 00) },
                new HealthSuggestion { Id = 8, Content = "Aşırı sert diş fırçalamaktan kaçının.", IsActive = true, CreatedAt = new DateTime(2024, 03, 20, 12, 00, 00) },
                new HealthSuggestion { Id = 9, Content = "Dişlerinizi yatmadan önce mutlaka fırçalayın.", IsActive = true, CreatedAt = new DateTime(2024, 03, 20, 12, 00, 00) },
                new HealthSuggestion { Id = 10, Content = "Asitli içecekleri sınırlayın.", IsActive = true, CreatedAt = new DateTime(2024, 03, 20, 12, 00, 00) }
            );
        }
    }
}
