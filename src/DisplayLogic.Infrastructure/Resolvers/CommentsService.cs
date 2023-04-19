using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Interfaces;

namespace DisplayLogic.Infrastructure.Resolvers;

/// <inheritdoc />
public class CommentService : ICommentService
    {
        private readonly List<Comment> _comments;

        public CommentService()
        {
            _comments = new List<Comment>
            {
                new Comment
                {
                    Id = 1,
                    Content = "First sample comment.",
                    Author = new Author { Id = 1, Username = "author1" },
                    CreatedAt = DateTime.Now.AddMinutes(-5),
                    ArticleId = Guid.Parse("3d5d4cd1-b6f4-4ae4-a25a-918e185d6285")
                },
                new Comment
                {
                    Id = 2,
                    Content = "Second sample comment.",
                    Author = new Author { Id = 2, Username = "author2" },
                    CreatedAt = DateTime.Now.AddMinutes(-10),
                    // ArticleId = Guid.Parse("3d5d4cd1-b6f4-4ae4-a25a-918e185d6285")
                    RecipeId = Guid.Parse("06afd62f-33fe-4271-952b-da9a1241c377")
                },
                new Comment
                {
                    Id = 3,
                    Content = "Third sample comment.",
                    Author = new Author { Id = 3, Username = "author3" },
                    CreatedAt = DateTime.Now.AddMinutes(-15),
                    ArticleId = Guid.Parse("34507ff9-6b73-4bae-98c3-af2ce2668188")
                },
                new Comment
                {
                    Id = 4,
                    Content = "Fourth sample comment.",
                    Author = new Author { Id = 4, Username = "author4" },
                    CreatedAt = DateTime.Now.AddMinutes(-20),
                    ArticleId = Guid.Parse("34507ff9-6b73-4bae-98c3-af2ce2668188")
                },
                new Comment
                {
                    Id = 5,
                    Content = "Fifth sample comment.",
                    Author = new Author { Id = 5, Username = "author5" },
                    CreatedAt = DateTime.Now.AddMinutes(-25),
                    // ArticleId = Guid.Parse("34507ff9-6b73-4bae-98c3-af2ce2668188")
                    RecipeId = Guid.Parse("06afd62f-33fe-4271-952b-da9a1241c377")
                }
            };
        }

        /// <inheritdoc />
        public List<Comment> GetAllComments()
        {
            return _comments;
        }

        /// <inheritdoc />
        public List<Comment> GetCommentsByArticleId(Guid articleUuid)
        {
            return _comments.Where(c => c.ArticleId == articleUuid).ToList();
        }
        
        /// <inheritdoc />
        public async Task<List<Comment>> GetCommentsByRecipeUuidAsync(Guid recipeUuid)
        {
            return _comments.FindAll(c => c.RecipeId == recipeUuid).ToList();
        }
    }