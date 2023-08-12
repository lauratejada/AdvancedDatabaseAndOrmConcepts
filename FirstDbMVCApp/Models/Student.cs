using Microsoft.Build.Framework;
using System.ComponentModel;

namespace FirstDbMVCApp.Models
{
    public class Student
    {
        [DisplayName("Student Number")]
        public Guid Id { get; set; }

        [Required]
        public string FullName { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
    }
}
