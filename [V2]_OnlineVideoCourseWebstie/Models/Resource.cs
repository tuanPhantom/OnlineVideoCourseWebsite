using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _V2__OnlineVideoCourseWebstie.Models
{
    public class Resource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ResourceId { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public long? TopicId { get; set; }
        public Topic? Topic { get; set; }
    }
}