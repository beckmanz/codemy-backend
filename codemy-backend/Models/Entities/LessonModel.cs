public class LessonModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Order { get; set; }
    public string VideoUrl { get; set; }
    public string SupportMaterialUrl { get; set; }
    public bool IsDemo { get; set; } = false;

    public int CourseId { get; set; }
    public CourseModel Course { get; set; }
}