using DisplayLogic.Domain.Entities;

namespace DisplayLogic.Infrastructure.Test.Unit.DataMocks;

public static class ArticleMocks
{
    public static List<Article> TestArticles = new List<Article>()
    {
        new Article
        {
            Uuid = Guid.Parse("3d5d4cd1-b6f4-4ae4-a25a-918e185d6285"),
            Title = "Exploring the Flavors of Thai Cuisine",
            Content = "Thai cuisine is known for its bold flavors...",
            Author = new Author { Id = Guid.NewGuid(), Username = "john_doe" },
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
                    Id = 1,
                    Content = "Great article! I love Thai food.",
                    Author = new Author { Id = Guid.NewGuid(), Username = "jane_doe" },
                    CreatedAt = new DateTime(2023, 4, 11)
                },
                new Comment
                {
                    Id = 2,
                    Content = "Thai cuisine is amazing!",
                    Author = new Author { Id = Guid.NewGuid(), Username = "mark_smith" },
                    CreatedAt = new DateTime(2023, 4, 12)
                }
            }
        },
        new Article
        {
            Uuid = Guid.Parse("34507ff9-6b73-4bae-98c3-af2ce2668188"),
            Title = "The Magic of Italian Pasta",
            Content = "Italian pasta dishes are a staple in many households...",
            Author = new Author { Id = Guid.NewGuid(), Username = "jane_doe" },
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
                    Id = 3,
                    Content = "I can't wait to try some of these pasta dishes!",
                    Author = new Author { Id = Guid.NewGuid(), Username = "john_doe" },
                    CreatedAt = new DateTime(2023, 4, 9)
                },
                new Comment
                {
                    Id = 4,
                    Content = "The article is very informative!",
                    Author = new Author { Id = Guid.NewGuid(), Username = "mark_smith" },
                    CreatedAt = new DateTime(2023, 4, 10)
                }
            }
        }
    };
}
