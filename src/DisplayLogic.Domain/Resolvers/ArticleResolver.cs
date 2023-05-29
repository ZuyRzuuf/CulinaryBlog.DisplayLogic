using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Filters;
using DisplayLogic.Domain.Interfaces;

namespace DisplayLogic.Domain.Resolvers;

/// <inheritdoc />
public class ArticleResolver : IArticleResolver
{
    private static readonly List<Article> Articles = new()
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
                new Tag { Id = Guid.NewGuid(), Name = "Thai cuisine" },
                new Tag { Id = Guid.NewGuid(), Name = "Asian cuisine" }
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
                new Tag { Id = Guid.NewGuid(), Name = "Italian cuisine" },
                new Tag { Id = Guid.NewGuid(), Name = "Pasta" }
            }
        }
    };

    /// <inheritdoc />
    public List<Article> GetAllArticles() => Articles;

    /// <inheritdoc />
    public Article? GetArticleById(Guid id)
    {
        return Articles.FirstOrDefault(article => article.Id == id);
    }

    /// <inheritdoc />
    public List<Article> GetFilteredArticles(ArticleFilter? filters)
    {
        var articles = Articles;

        if (filters == null) return articles;
        
        if (filters.Ids != null && filters.Ids.Any())
        {
            articles = articles.Where(article => filters.Ids.Contains(article.Id)).ToList();
        }
        else if (filters.TagIds != null && filters.TagIds.Any())
        {
            articles = articles.Where(article => article.Tags.Any(tag => filters.TagIds.Contains(tag.Id))).ToList();
        }
        else if (filters.TagNames != null && filters.TagNames.Any())
        {
            articles = articles.Where(article => article.Tags.Any(tag => filters.TagNames.Contains(tag.Name))).ToList();
        }
        else if (filters.Id != null)
        {
            articles = articles.Where(article => article.Id == filters.Id).ToList();
        }

        return articles;
    }
}