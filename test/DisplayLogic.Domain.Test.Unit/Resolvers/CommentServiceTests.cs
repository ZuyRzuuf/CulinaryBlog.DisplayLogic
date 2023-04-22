using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Interfaces;
using DisplayLogic.Domain.Services;
using DisplayLogic.Domain.Test.Unit.DataMocks;

namespace DisplayLogic.Domain.Test.Unit.Resolvers;

public class CommentServiceTests
    {
        private readonly ICommentService _commentService;
        private readonly List<Comment> _testComments;

        public CommentServiceTests()
        {
            _testComments = CommentMocks.TestComments;
            _commentService = new CommentService();
        }

        [Fact]
        public void GetAllComments_ReturnsListOfComments()
        {
            // Act
            var result = _commentService.GetAllComments();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(_testComments.Count, result.Count);
            Assert.All(result, comment => Assert.IsType<Comment>(comment));
        }

        [Fact]
        public void GetCommentsByArticleId_WithExistingId_ReturnsComments()
        {
            // Arrange
            var existingId = _testComments.First().ArticleId;
            var expectedComments = _testComments.Where(c => c.ArticleId == existingId).ToList();
    
            // Act
            var result = _commentService.GetCommentsByArticleId(existingId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedComments.Count, result.Count); // This should now pass, as expectedComments.Count should be 1
            Assert.All(result, comment => Assert.Equal(existingId, comment.ArticleId));
        }


        [Fact]
        public void GetCommentsByArticleId_WithNonExistingId_ReturnsEmptyList()
        {
            // Arrange
            var nonExistingId = Guid.NewGuid();
            
            // Act
            var result = _commentService.GetCommentsByArticleId(nonExistingId);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async void GetCommentsByRecipeUuidAsync_WithExistingUuid_ReturnsComments()
        {
            // Arrange
            var existingUuid = _testComments.First().RecipeId;
            var expectedComments = _testComments.Where(c => c.RecipeId == existingUuid).ToList();
            
            // Act
            var result = await _commentService.GetCommentsByRecipeUuidAsync(existingUuid);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedComments.Count, result.Count);
            Assert.All(result, comment => Assert.Equal(existingUuid, comment.RecipeId));
        }

        [Fact]
        public async void GetCommentsByRecipeUuidAsync_WithNonExistingUuid_ReturnsEmptyList()
        {
            // Arrange
            var nonExistingUuid = Guid.NewGuid();
            
            // Act
            var result = await _commentService.GetCommentsByRecipeUuidAsync(nonExistingUuid);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }