namespace Class_10.Models
{
    public class Post{
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int BlogId { get; set; }

        // entity framework relationship
        // navigation properties
        public Blog Blog { get; set; }
    }
}