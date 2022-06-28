namespace IntroToAPI.Models
{
    public class SearchResult<T>
    {
        public int count { get; set; }
        public List<T> results { get; set; } = new List<T>();
    }
}