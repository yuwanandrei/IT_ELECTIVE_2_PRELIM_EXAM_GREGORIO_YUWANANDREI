namespace IT_ELECTIVE_2_PRELIM_EXAM.Models;

// EXERCISE 8: Override vs New
// QuickRecipe inherits from RecipeBase.
public class QuickRecipe : RecipeBase
{
    // The MaxMinutes property representing the ceiling for "quick" recipes
    public int MaxMinutes { get; set; }

    public QuickRecipe() : base()
    {
        MaxMinutes = 30;
    }

    public QuickRecipe(string title, int prepTime, string difficulty, int maxMinutes)
        : base(title, prepTime, difficulty)
    {
        MaxMinutes = maxMinutes;
    }

    // FIXED: Changed 'new' to 'override' to enable runtime polymorphism
    public override string GetRecipeInfo()
    {
        return $"{base.GetRecipeInfo()} | Quick: Under {MaxMinutes} min";
    }
}