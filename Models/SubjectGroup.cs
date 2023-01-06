using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamRegistration.Models
{
    public class SubjectGroup
    {
        [Key]
        public Guid SubjectGroupID { get; set; }
        public string? SubjectGroupName { get; set; }
        public Guid SubjectID { get; set; }
        [Required]
        public Subject Subject { get; set; }
    }
}