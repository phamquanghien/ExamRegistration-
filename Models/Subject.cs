using System.ComponentModel.DataAnnotations;

namespace ExamRegistration.Models
{
    public class Subject
    {
        [Key]
        [Required]
        [Display(Name = "Học phần ID")]
        public Guid SubjectID { get; set; }
        [Display(Name = "Mã học phần")]
        public string SubjectCode { get; set; }
        [Required]
        [Display(Name = "Tên học phần")]
        public string? SubjectName { get; set; }
        [Required]
        [Display(Name = "Kích hoạt")]
        public bool IsActive { get; set; }
        public ICollection<SubjectGroup>? SubjectGroup {get; set; }
    }
}