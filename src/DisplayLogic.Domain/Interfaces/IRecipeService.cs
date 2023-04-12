using DisplayLogic.Domain.Entities;

namespace DisplayLogic.Domain.Interfaces;

public interface IRecipeService
{
    List<Recipe> GetAllRecipes();
    Recipe GetRecipeById(Guid id);
}