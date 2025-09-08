
public class CourseModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public string CoverImageUrl { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;

    public int InstructorId { get; set; }
    public UserModel Instructor { get; set; }

    public ICollection<LessonModel> Lessons { get; set; }
    public ICollection<ReviewModel> Reviews { get; set; }
}