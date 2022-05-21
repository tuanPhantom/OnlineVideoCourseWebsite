using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineVideoCourseWebsite.Models
{
    public class CourseOffering
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CourseOfferingId { get; set; }
        [Required]
        public int Year { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime OpenDate { get; set; }
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        public List<Topic> Topics { get; set; } = new List<Topic>();

        public long CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
