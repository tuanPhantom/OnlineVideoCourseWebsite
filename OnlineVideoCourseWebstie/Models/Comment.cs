using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineVideoCourseWebsite.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CommentId { get; set; }
        [Required]
        [MaxLength(1024)]
        public string CommentText { get; set; }
        public long UserId { get; set; }
        public User? User { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastModifiedDate { get; set; }
        public long VideoId { get; set; }
        public Video? Video { get; set; }
    }
}
