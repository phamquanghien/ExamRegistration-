using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExamRegistration.Models;

public class ExamTime
{
    [Key]
    public int ExamTimeID { get; set; }
    [Required]
    public string? ExamTimeName { get; set; }
    [Required]
    public string? StartTime { get; set; }
    [Required]
    public string? FinishTime { get; set; }
    [Required]
    public int MaxRegistration { get; set; }
    [Required]
    public int? CurrentRegistration { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public bool IsFinish { get; set; }
    public Guid SubjectID { get; set; }
    [ForeignKey("Subject")]
    public Subject Subject { get; set; }
}