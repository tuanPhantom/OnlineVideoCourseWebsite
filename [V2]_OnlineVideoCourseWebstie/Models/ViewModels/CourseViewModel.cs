namespace _V2__OnlineVideoCourseWebstie.Models.ViewModels
{
    public class CourseViewModel
    {
        public Course Course { get; set; }
        public List<Topic> Topics { get; set; } = new List<Topic>();
    }
}
