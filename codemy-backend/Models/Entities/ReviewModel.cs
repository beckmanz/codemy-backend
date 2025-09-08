public class ReviewModel
{
    public int Id { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public DateTime ReviewDate { get; set; } = DateTime.UtcNow;

    public int StudentId { get; set; }
    public UserModel Student { get; set; }

    public int CourseId { get; set; }
    public CourseModel Course { get; set; }
}