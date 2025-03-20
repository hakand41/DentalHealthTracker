namespace DentalHealthTracker.Core.Entities
{
    public class HealthRecord
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GoalId { get; set; }  // İsteğe bağlı olabilir
        public DateTime RecordDate { get; set; } = DateTime.UtcNow;
        public TimeSpan RecordTime { get; set; }  // Gün içinde kayıt yapıldığı saat
        public int Duration { get; set; }  // Diş fırçalama süresi (saniye)
        public bool IsCompleted { get; set; }  // Fırçalama işlemi tamamlandı mı?

        // Diş sağlığına özel alanlar
        public int ToothBrushingCount { get; set; }  // Günlük fırçalama sayısı
        public int FlossingCount { get; set; }  // Diş ipi kullanma sayısı
        public int MouthwashUsage { get; set; }  // Ağız gargarası kullanıldı mı? (0 = hayır, 1 = evet)

        public User? User { get; set; }
        public Goal? Goal { get; set; }
    }
}
