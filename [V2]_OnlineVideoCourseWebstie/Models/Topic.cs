using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _V2__OnlineVideoCourseWebsite.Models
{
    public class Topic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TopicId { get; set; }
        public string Title { get; set; }
        public List<Resource> Resources { get; set; } = new List<Resource>();
        public long? CourseOfferingId { get; set; }
        public CourseOffering? CourseOffering { get; set; }
        public List<TopicVideo> TopicVideos { get; set; } = new List<TopicVideo>();
    }
}
