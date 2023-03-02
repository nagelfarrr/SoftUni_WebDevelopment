namespace P01_StudentSystem.Data.Models;
using Enums;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Resource
{
    public int ResourceId { get; set; }

    [MaxLength(50)]
    [Required]
    public string? Name { get; set; }

    [Required]//non-unicode
    public string Url { get; set; } = null!;

    [Required]
    public ResourceType ResourceType { get; set; }

    [Required]
    [ForeignKey(nameof(Course))]
    public int CourseId { get; set; }

    public Course? Course { get; set; }

}

