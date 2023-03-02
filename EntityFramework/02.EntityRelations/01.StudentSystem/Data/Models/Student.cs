namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Student
{
    public Student()
    {
        StudentsCourses = new HashSet<StudentCourse>();
        Homeworks = new HashSet<Homework>();
    }

    public int StudentId { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [MaxLength(10)]
    //non-unicode
    public string? PhoneNumber { get; set; }

    [Required]//maybe not
    public DateTime RegisteredOn { get; set; }

    public DateTime? Birthday { get; set; }

    public virtual ICollection<StudentCourse> StudentsCourses { get; set; }

    public virtual ICollection<Homework> Homeworks { get; set; }

}

