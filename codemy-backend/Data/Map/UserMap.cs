using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserMap : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Name).IsRequired().HasMaxLength(150);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(150);
        builder.HasIndex(u => u.Email).IsUnique();

        builder.Property(u => u.PasswordHash).IsRequired();

        builder.Property(u => u.Role).HasConversion<string>();
        
        builder.HasMany(u => u.CreatedCourses)
               .WithOne(c => c.Instructor)
               .HasForeignKey(c => c.InstructorId);

        builder.HasMany(u => u.Enrollments)
               .WithOne(e => e.Student)
               .HasForeignKey(e => e.StudentId);
        
        builder.HasMany(u => u.Reviews)
               .WithOne(r => r.Student)
               .HasForeignKey(r => r.StudentId);
    }
}