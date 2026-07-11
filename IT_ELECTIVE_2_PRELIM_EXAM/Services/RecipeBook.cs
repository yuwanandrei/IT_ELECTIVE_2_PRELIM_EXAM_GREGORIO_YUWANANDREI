using System;
using System.Collections.Generic;
using System.Linq;
using IT_ELECTIVE_2_PRELIM_EXAM.Models;

namespace IT_ELECTIVE_2_PRELIM_EXAM.Services;

// EXERCISE 5: Constructor Chaining
// RecipeBook has one constructor. Your task:
// - Add a second constructor that accepts only (string name)
// - That constructor should chain to the existing 2-parameter constructor
//   using ': this(name, 10)' as the default capacity
//
// EXERCISE 6: Method Overloads
// The Search(string term) method searches by name only.
// Your task:
// - Add an overload: Search(string term, string category)
//   that filters by both name AND category
// - Add an overload: Search(int maxPrepTime)
//   that returns all meals with PrepTimeMinutes <= maxPrepTime

public class RecipeBook
{
    public string Name { get; set; }
    public int Capacity { get; set; }
    private List<Meal> meals;

    // Master Constructor (2 parameters)
    public RecipeBook(string name, int capacity)
    {
        Name = name;
        Capacity = capacity;
        meals = new List<Meal>();
    }

   
    // EXERCISE 5: Constructor Chaining
    // Chains to the master constructor using ': this(...)' with a default capacity of 10
    
    public RecipeBook(string name) : this(name, 10)
    {
        // Body stays empty because the master constructor handles initialization!
    }

    public void AddMeal(Meal meal)
    {
        if (meals.Count < Capacity)
        {
            meals.Add(meal);
        }
    }

    // Original Search (by name only)
    public List<Meal> Search(string term)
    {
        return meals.Where(m =>
            m.Name.Contains(term, StringComparison.OrdinalIgnoreCase)).ToList();
    }


    // EXERCISE 6: Overload 1 - Search by Name AND Category
    // Filters items matching both criteria
  
    public List<Meal> Search(string term, string category)
    {
        return meals.Where(m =>
            m.Name.Contains(term, StringComparison.OrdinalIgnoreCase) &&
            m.Category.Equals(category, StringComparison.OrdinalIgnoreCase)
        ).ToList();
    }


    // EXERCISE 6: Overload 2 - Search by Max Prep Time
    // Note: If 'PrepTimeMinutes' doesn't exist on 'Meal', check your Model's property name

    public List<Meal> Search(int maxPrepTime)
    {
        return meals.Where(m => m.CookingTime <= maxPrepTime).ToList();
    }

    public int GetMealCount()
    {
        return meals.Count;
    }

    public List<Meal> GetAllMeals()
    {
        return new List<Meal>(meals);
    }
}
