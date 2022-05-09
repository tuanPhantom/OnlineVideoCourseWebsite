using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _V2__OnlineVideoCourseWebsite.Models
{
    public class User : IdentityUser<string>
    {
        //[MaxLength(80), Required]
        //public string Name { get; set; }
        //[MaxLength(1024)]
        //public string Email { get; set; }
        [MaxLength(1024)]
        public string? Description { get; set; }
        [MaxLength(1024)]
        public string? Thumbnail { get; set; }
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
