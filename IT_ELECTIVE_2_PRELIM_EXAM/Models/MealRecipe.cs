using System;
using IT_ELECTIVE_2_PRELIM_EXAM.Interfaces;

namespace IT_ELECTIVE_2_PRELIM_EXAM.Models;

// EXERCISE 7: Inheritance - Derived Class
// EXERCISE 9: Interfaces
public class MealRecipe : RecipeBase, IRecipeSearchable
{
    // EXERCISE 7: Standard auto-implemented properties (properly store values now)
    public string Category { get; set; } = "";
    public string Area { get; set; } = "";

    // Parameterless constructor chaining to the base parameterless constructor
    public MealRecipe() : base()
    {
    }

    // 3-parameter constructor chaining to the base constructor
    public MealRecipe(string title, int prepTime, string difficulty)
        : base(title, prepTime, difficulty)
    {
    }

    // EXERCISE 7: 5-parameter constructor that chains to the base constructor
    // and initializes the derived class properties (Category and Area)
    public MealRecipe(string title, int prepTime, string difficulty, string category, string area)
        : base(title, prepTime, difficulty)
    {
        Category = category;
        Area = area;
    }

    // EXERCISE 7: Override GetRecipeInfo() to include Category and Area
    public override string GetRecipeInfo()
    {
        // Appends the base info with the new MealRecipe-specific properties
        return $"{base.GetRecipeInfo()} | Category: {Category} | Area: {Area}";
    }

    // EXERCISE 9: Implement IRecipeSearchable interface members

    // Returns the Title (inherited from RecipeBase) as the search criteria
    public string SearchCriteria => Title;

    // Checks if the searchTerm is found inside the Title, case-insensitive
    public bool MatchesSearch(string searchTerm)
    {
        if (string.IsNullOrEmpty(searchTerm))
            return false;

        return Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
    }
}