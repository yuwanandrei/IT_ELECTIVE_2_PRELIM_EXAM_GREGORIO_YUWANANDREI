using System;
using System.Collections.Generic;
using System.Linq;
using IT_ELECTIVE_2_PRELIM_EXAM.Models;

namespace IT_ELECTIVE_2_PRELIM_EXAM.Services;

// EXERCISE 10: Access Modifiers (Fully Restored & Fixed)
public class Kitchen
{
    // Private backing fields for encapsulation
    private string kitchenName;
    private string headChef;
    private List<Meal> meals;

    // Public read-only property for external access
    public int MealCount { get; private set; }

    public Kitchen(string name, string chef)
    {
        kitchenName = name;
        headChef = chef;
        meals = new List<Meal>();
        MealCount = 0;
    }

    // Public API: Adds a meal to the list and increments the count
    public void AddMeal(Meal meal)
    {
        meals.Add(meal);
        MealCount++;
    }

    // Public API: Returns a defensive copy of the meals list
    public List<Meal> GetMeals()
    {
        return new List<Meal>(meals);
    }

    // Public API: Removes a meal by name (case-insensitive) and decrements the count
    public bool RemoveMeal(string mealName)
    {
        var meal = meals.FirstOrDefault(m =>
            m.Name.Equals(mealName, StringComparison.OrdinalIgnoreCase));

        if (meal != null)
        {
            meals.Remove(meal);
            MealCount--;
            return true;
        }
        return false;
    }

    // Public API: Formats kitchen details for display
    public string GetKitchenInfo()
    {
        return $"Kitchen: {kitchenName} | Chef: {headChef} | Meals: {MealCount}";
    }

    // Protected API: Accessible only within this class and its subclasses
    protected string PrepareMeal(string mealName)
    {
        return $"Preparing {mealName} in {kitchenName}...";
    }
}