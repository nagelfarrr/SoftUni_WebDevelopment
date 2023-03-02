namespace P01_StudentSystem.Data.Models;
using Enums;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Homework
{
    public int HomeworkId { get; set; }

    [Required]//non-unicode
    public string? Content { get; set; }

    [Required]
    public ContentType ContentType { get; set; }

    [Required]
    public DateTime SubmissionTime { get; set; }

    [Required]
    [ForeignKey(nameof(Student))]
    public int StudentId { get; set; }
    public Student Student { get; set; }

    [Required]
    [ForeignKey(nameof(Course))]
    public int CourseId { get; set; }
    public Course Course { get; set; }
}
