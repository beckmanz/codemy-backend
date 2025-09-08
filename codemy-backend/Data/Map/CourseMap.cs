using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CourseMap : IEntityTypeConfiguration<CourseModel>
{
    public void Configure(EntityTypeBuilder<CourseModel> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Title).IsRequired().HasMaxLength(250);
        builder.Property(c => c.Description).HasMaxLength(500);

        builder.HasIndex(c => c.Title).IsUnique();

        builder.HasMany(c => c.Lessons)
               .WithOne(l => l.Course)
               .HasForeignKey(l => l.CourseId);

        builder.HasMany(c => c.Reviews)
               .WithOne(r => r.Course)
               .HasForeignKey(r => r.CourseId);
    }
}