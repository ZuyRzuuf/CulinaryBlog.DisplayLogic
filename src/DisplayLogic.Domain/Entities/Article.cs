namespace DisplayLogic.Domain.Entities;

public class Article
{
    public Guid Uuid { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Author Author { get; set; }
    public DateTime PublishedDate { get; set; }
    public string ImageUrl { get; set; }
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
