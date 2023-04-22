using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Interfaces;

namespace DisplayLogic.Infrastructure.Resolvers;

/// <inheritdoc />
public class ArticleService : IArticleService
{
    private static readonly List<Article> _articles = new()
    {
        new Article
        {
            Id = Guid.Parse("3d5d4cd1-b6f4-4ae4-a25a-918e185d6285"),
            Title = "Exploring the Flavors of Thai Cuisine",
            Content = "Thai cuisine is known for its bold flavors...",
            Author = new Author { Id = Guid.Parse("e97ffece-bca2-4f06-84f9-a2d792afea20"), Username = "john_doe" },
            PublishedDate = new DateTime(2023, 4, 10),
            ImageUrl = "https://example.com/images/thai-cuisine.jpg",
            Tags = new List<Tag>
            {
                new Tag { Id = 1, Name = "Thai cuisine" },
                new Tag { Id = 2, Name = "Asian cuisine" }
            },
            Comments = new List<Comment>
            {
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Content = "Great article! I love Thai food.",
                    Author = new Author { Id = Guid.Parse("f7cbdcf2-6291-42af-89f2-82e2dc3380bd"), Username = "jane_doe" },
                    CreatedAt = new DateTime(2023, 4, 11)
                },
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Content = "Thai cuisine is amazing!",
                    Author = new Author { Id = Guid.Parse("164127d7-c6f7-4481-9671-1b986a462833"), Username = "mark_smith" },
                    CreatedAt = new DateTime(2023, 4, 12)
                }
            }
        },
        new Article
        {
            Id = Guid.Parse("34507ff9-6b73-4bae-98c3-af2ce2668188"),
            Title = "The Magic of Italian Pasta",
            Content = "Italian pasta dishes are a staple in many households...",
            Author = new Author { Id = Guid.Parse("689cffbf-2c88-4cb0-abce-f6bea1b28f3b"), Username = "jane_doe" },
            PublishedDate = new DateTime(2023, 4, 8),
            ImageUrl = "https://example.com/images/italian-pasta.jpg",
            Tags = new List<Tag>
            {
                new Tag { Id = 3, Name = "Italian cuisine" },
                new Tag { Id = 4, Name = "Pasta" }
            },
            Comments = new List<Comment>
            {
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Content = "I can't wait to try some of these pasta dishes!",
                    Author = new Author { Id = Guid.Parse("e97ffece-bca2-4f06-84f9-a2d792afea20"), Username = "john_doe" },
                    CreatedAt = new DateTime(2023, 4, 9)
                },
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Content = "The article is very informative!",
                    Author = new Author { Id = Guid.Parse("164127d7-c6f7-4481-9671-1b986a462833"), Username = "mark_smith" },
                    CreatedAt = new DateTime(2023, 4, 10)
                }
            }
        }
    };

    /// <inheritdoc />
    public List<Article> GetAllArticles() => _articles;

    /// <inheritdoc />
    public Article? GetArticleById(Guid uuid)
    {
        return _articles.FirstOrDefault(article => article.Id == uuid);
    }
}