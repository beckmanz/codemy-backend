using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ReviewMap : IEntityTypeConfiguration<ReviewModel>
{
    public void Configure(EntityTypeBuilder<ReviewModel> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasIndex(r => new { r.StudentId, r.CourseId }).IsUnique();

        builder.Property(r => r.Rating).IsRequired();
    }
}