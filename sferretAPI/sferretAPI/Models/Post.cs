namespace sferretAPI.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
