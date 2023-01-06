using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamRegistration.Models
{
    public class StudentSubject
    {
        [Key]
        public Guid StudentSubjectID { get; set; }
        public Guid StudentID { get; set; }
        public Guid SubjectID { get; set; }
        [ForeignKey("Subject")]
        public Subject Subject { get; set; }
        [ForeignKey("Student")]
        public Student Student { get; set; }
    }
}