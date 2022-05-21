namespace OnlineVideoCourseWebsite.Common
{
    /**
     * @effects a class provides a static dictionary to store key-pair values
     * @Author Phan Quang Tuan
     */
    public class BinPattern
    {
        // make sure that when using Bin, the key should be unique in case of multi-threading or multi-user
        public static IDictionary<Object, Object> Bin { get; } = new Dictionary<Object, Object>();
        private BinPattern()
        {

        }
    }
}
