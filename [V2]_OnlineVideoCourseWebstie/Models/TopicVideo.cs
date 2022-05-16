using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineVideoCourseWebsite.Models
{
    public class TopicVideo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TopicVideoId { get; set; }
        public long? TopicId { get; set; }
        public Topic? Topic { get; set; }
        public long? VideoId { get; set; }
        public Video? Video { get; set; }
    }
}
