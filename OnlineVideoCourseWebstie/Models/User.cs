using Microsoft.AspNetCore.Identity;
using OnlineVideoCourseWebsite.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineVideoCourseWebsite.Models
{
    public class User : IdentityUser<string>
    {
        [MaxLength(80), Required]
        public string FullName { get; set; }
        [MaxLength(1024)]
        public string? Description { get; set; }
        [MaxLength(1024)]
        public string? Thumbnail { get; set; } = Constants.UnregisteredUser;
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
