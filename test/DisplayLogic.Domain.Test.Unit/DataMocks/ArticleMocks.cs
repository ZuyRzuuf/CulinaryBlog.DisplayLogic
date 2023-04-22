using DisplayLogic.Domain.Entities;

namespace DisplayLogic.Domain.Test.Unit.DataMocks;

public static class ArticleMocks
{
    public static List<Article> TestArticles = new List<Article>()
    {
        new Article
        {
            Id = Guid.Parse("3d5d4cd1-b6f4-4ae4-a25a-918e185d6285"),
            Title = "Exploring the Flavors of Thai Cuisine",
            Content = "Thai cuisine is known for its bold flavors...",
            Author = new Author { Id = Guid.NewGuid(), Username = "john_doe" },
            PublishedDate = new DateTime(2023, 4, 10),
            ImageUrl = "https://example.com/images/thai-cuisine.jpg",
            Tags = new List<Tag>
            {
                new Tag { Id = Guid.NewGuid(), Name = "Thai cuisine" },
                new Tag { Id = Guid.NewGuid(), Name = "Asian cuisine" }
            },
            Comments = new List<Comment>
            {
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Content = "Great article! I love Thai food.",
                    Author = new Author { Id = Guid.NewGuid(), Username = "jane_doe" },
                    CreatedAt = new DateTime(2023, 4, 11)
                },
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Content = "Thai cuisine is amazing!",
                    Author = new Author { Id = Guid.NewGuid(), Username = "mark_smith" },
                    CreatedAt = new DateTime(2023, 4, 12)
                }
            }
        },
        new Article
        {
            Id = Guid.Parse("34507ff9-6b73-4bae-98c3-af2ce2668188"),
            Title = "The Magic of Italian Pasta",
            Content = "Italian pasta dishes are a staple in many households...",
            Author = new Author { Id = Guid.NewGuid(), Username = "jane_doe" },
            PublishedDate = new DateTime(2023, 4, 8),
            ImageUrl = "https://example.com/images/italian-pasta.jpg",
            Tags = new List<Tag>
            {
                new Tag { Id = Guid.NewGuid(), Name = "Italian cuisine" },
                new Tag { Id = Guid.NewGuid(), Name = "Pasta" }
            },
            Comments = new List<Comment>
            {
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Content = "I can't wait to try some of these pasta dishes!",
                    Author = new Author { Id = Guid.NewGuid(), Username = "john_doe" },
                    CreatedAt = new DateTime(2023, 4, 9)
                },
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Content = "The article is very informative!",
                    Author = new Author { Id = Guid.NewGuid(), Username = "mark_smith" },
                    CreatedAt = new DateTime(2023, 4, 10)
                }
            }
        }
    };
}
