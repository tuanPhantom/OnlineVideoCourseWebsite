using Microsoft.AspNetCore.Identity;

namespace _V2__OnlineVideoCourseWebsite.Models.ViewModels
{
    public class CoursesDashBoardViewModel
    {
        public List<Course>? Courses { get; set; }
        public string? Role { get; set; }
    }
}
