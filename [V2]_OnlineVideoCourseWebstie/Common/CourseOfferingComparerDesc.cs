using OnlineVideoCourseWebsite.Models;

namespace OnlineVideoCourseWebsite.Common
{
    /**
    * @Overview a class to compare CourseOfferings in descending order by their OpenDate 
    */
    public class CourseOfferingComparerDesc : Comparer<CourseOffering>
    {
        public override int Compare(CourseOffering? x, CourseOffering? y)
        {
            // desc order in null cases
            if (x == null || x.OpenDate == null)
            {
                return y == null ? 0 : 1;
            }
            if (y == null || y.OpenDate == null)
            {
                return -1;
            }

            int nowX = x.OpenDate.Value.CompareTo(DateTime.Now); // negative result means the course opened
            int nowY = y.OpenDate.Value.CompareTo(DateTime.Now);

            if (nowX == nowY)
            {
                return 0;
            }
            else
            {
                if (nowX < 0 && nowY < 0)
                {
                    return nowX > nowY ? -1 : 1;
                }
                else if (nowX > 0 && nowY > 0)
                {
                    return nowX < nowY ? -1 : 1;
                }
                else
                {
                    return nowX < 0 ? -1 : 1;
                }
            }
        }
    }
}
