namespace IT_ELECTIVE_2_PRELIM_EXAM.Models;

// EXERCISE 1: Encapsulation - Private Fields
// The fields below are public. Your task:
// - Make all fields PRIVATE
// - Create public Properties with getters and setters
// - The property names should match the field names (PascalCase)
//
// Currently, the properties below are STUBS that return wrong values.
// Fix them to properly wrap the private fields.


public class Meal
{
    private string _name;
    private string _category;
    private string _area;
    private string _instructions;
    private string _thumbnail;
    private string _tags;
    private int _cookingTime; // Added private backing field for Exercise 6 compatibility

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public string Category
    {
        get => _category;
        set => _category = value;
    }

    public string Area
    {
        get => _area;
        set => _area = value;
    }

    // Public property for CookingTime so RecipeBook can access it
    public int CookingTime
    {
        get => _cookingTime;
        set => _cookingTime = value;
    }

    // Default Constructor
    public Meal()
    {
        _name = "";
        _category = "";
        _area = "";
        _instructions = "";
        _thumbnail = "";
        _tags = "";
        _cookingTime = 0;
    }

    // Parameterized Constructor
    public Meal(string name, string category, string area)
    {
        _name = name;
        _category = category;
        _area = area;
        _instructions = "";
        _thumbnail = "";
        _tags = "";
        _cookingTime = 0;
    }

    public override string ToString()
    {
        return $"Meal: {Name} | Category: {Category} | Area: {Area}";
    }
}
 