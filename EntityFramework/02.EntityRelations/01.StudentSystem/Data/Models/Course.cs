namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Course
{
    public Course()
    {
        this.StudentsCourses = new HashSet<StudentCourse>();
        this.Resources = new HashSet<Resource>();
        this.Homeworks = new HashSet<Homework>();
    }

    public int CourseId { get; set; }

    [MaxLength(80)]
    [Required]
    public string Name { get; set; } = null!;

    [MaxLength]// ????
    public string? Description { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    [Required]
    public decimal Price { get; set; }

    public virtual ICollection<StudentCourse> StudentsCourses { get; set; }

    public virtual ICollection<Resource> Resources { get; set; }

    public virtual ICollection<Homework> Homeworks { get; set; }
}
