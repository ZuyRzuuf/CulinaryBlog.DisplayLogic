namespace DisplayLogic.Domain.Entities;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; }
    public Author Author { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid ArticleId { get; set; }
}