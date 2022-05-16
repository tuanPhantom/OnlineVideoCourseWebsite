using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineVideoCourseWebsite.Models
{
    public class Enrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EnrollmentId { get; set; }
        public int? Grade { get; set; }
        public String? UserId { get; set; }
        public User? User { get; set; }
        public long CourseOfferingId { get; set; }
        public CourseOffering? CourseOffering { get; set; }
    }
}
