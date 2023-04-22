using DisplayLogic.Domain.Entities;

namespace DisplayLogic.Infrastructure.Test.Unit.DataMocks;

public class CommentMocks
{
    public static List<Comment> TestComments = new List<Comment>
    {
        new Comment
        {
            Id = 1,
            Content = "Great article!",
            Author = new Author { Id = 1, Username = "author1" },
            CreatedAt = DateTime.Now.AddMinutes(-5),
            ArticleId = Guid.Parse("3d5d4cd1-b6f4-4ae4-a25a-918e185d6285")
        },
        new Comment
        {
            Id = 2,
            Content = "I found this very helpful.",
            Author = new Author { Id = 2, Username = "author2" },
            CreatedAt = DateTime.Now.AddMinutes(-10),
            ArticleId = Guid.Parse("3d5d4cd1-b6f4-4ae4-a25a-918e185d6285")
        },
        new Comment
        {
            Id = 3,
            Content = "Interesting insights.",
            Author = new Author { Id = 3, Username = "author3" },
            CreatedAt = DateTime.Now.AddMinutes(-15),
            ArticleId = Guid.Parse("34507ff9-6b73-4bae-98c3-af2ce2668188")
        },
        new Comment
        {
            Id = 4,
            Content = "I learned a lot from this article.",
            Author = new Author { Id = 4, Username = "author4" },
            CreatedAt = DateTime.Now.AddMinutes(-20),
            ArticleId = Guid.Parse("34507ff9-6b73-4bae-98c3-af2ce2668188")
        },
        new Comment
        {
            Id = 5,
            Content = "This is a must-read!",
            Author = new Author { Id = 5, Username = "author5" },
            CreatedAt = DateTime.Now.AddMinutes(-25),
            ArticleId = Guid.Parse("34507ff9-6b73-4bae-98c3-af2ce2668188")
        }
    };
}