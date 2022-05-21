namespace OnlineVideoCourseWebsite.Models.ViewModels
{
    public class VideoViewModel
    {
        public Video Video { get; set; }
        public User Instructor { get; set; }

        public Course Course { get; set; }

        public List<Resource> Resources { get; set; }
    }
}
