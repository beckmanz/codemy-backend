using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class LessonMap : IEntityTypeConfiguration<LessonModel>
{
    public void Configure(EntityTypeBuilder<LessonModel> builder)
    {
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Title).IsRequired().HasMaxLength(250);
        builder.Property(l => l.VideoUrl).IsRequired();
    }
}