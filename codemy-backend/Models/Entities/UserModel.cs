public class UserModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public UserRole Role { get; set; }
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

    public ICollection<CourseModel> CreatedCourses { get; set; }

    public ICollection<EnrollmentModel> Enrollments { get; set; }
    public ICollection<ReviewModel> Reviews { get; set; }
}