using System.ComponentModel.DataAnnotations;
namespace ExamRegistration.Models
{
    public class Student
    {
        [Key]
        [Required]
        public Guid StudentID { get; set; }
        public string? StudentCode { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? SubjectGroup { get; set; }
        [Required]
        public string? Subject { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}