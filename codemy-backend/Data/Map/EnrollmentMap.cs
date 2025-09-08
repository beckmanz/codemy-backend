using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EnrollmentMap : IEntityTypeConfiguration<EnrollmentModel>
{
    public void Configure(EntityTypeBuilder<EnrollmentModel> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.CompletedLessonsJson);

        builder.HasIndex(e => new { e.StudentId, e.CourseId }).IsUnique();
    }
}