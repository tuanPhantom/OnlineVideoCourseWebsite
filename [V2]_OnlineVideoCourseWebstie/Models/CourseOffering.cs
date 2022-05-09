using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _V2__OnlineVideoCourseWebsite.Models
{
    public class CourseOffering
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CourseOfferingId { get; set; }
        [Required]
        public int Year { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? OpenDate { get; set; }
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public long? CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
