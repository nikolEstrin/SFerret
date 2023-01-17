namespace sferretAPI.Models
{
    public class PostMovie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Adult { get; set; }
        public string Collection { get; set; }
        public string Language { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public int Runtime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float AvgRating { get; set; }
    }
}
