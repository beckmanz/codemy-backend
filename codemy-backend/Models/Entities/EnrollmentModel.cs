public class EnrollmentModel
{
    public int Id { get; set; }
    public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;

    public string CompletedLessonsJson { get; set; }

    public int StudentId { get; set; }
    public UserModel Student { get; set; }

    public int CourseId { get; set; }
    public CourseModel Course { get; set; }
}