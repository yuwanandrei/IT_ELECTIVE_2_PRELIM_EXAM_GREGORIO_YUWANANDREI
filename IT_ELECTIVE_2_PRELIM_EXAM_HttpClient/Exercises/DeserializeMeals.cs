using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 10: GET Deserialize Multiple Meals
// TheMealDB API: https://themealdb.com/api/json/v1/1/search.php?f=a
public static class DeserializeMeals
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/search.php?f=a";

        // 1. Use the HttpClient to fetch meals starting with letter "a"
        HttpResponseMessage response = await client.GetAsync(url);

        // 2. Assert status code is 200 OK
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Assertion Failed: Expected status code 200 OK, but received {response.StatusCode}");
        }

        // Read the response content as a string
        string responseBody = await response.Content.ReadAsStringAsync();

        // 3. Parse the JSON and get the "meals" array
        using (JsonDocument doc = JsonDocument.Parse(responseBody))
        {
            JsonElement root = doc.RootElement;

            // Check if the "meals" property exists and is an array
            if (!root.TryGetProperty("meals", out JsonElement mealsElement) || mealsElement.ValueKind != JsonValueKind.Array)
            {
                throw new Exception("Assertion Failed: The 'meals' property is missing, null, or not an array.");
            }

            // 4. Assert the array has more than 0 items
            int mealCount = mealsElement.GetArrayLength();
            if (mealCount == 0)
            {
                throw new Exception("Assertion Failed: The 'meals' array contains 0 items.");
            }

            Console.WriteLine($"[Exercise 10 Success] Found {mealCount} meals starting with 'a':\n---");

            // 5. Loop through each meal and print its name (strMeal)
            foreach (JsonElement meal in mealsElement.EnumerateArray())
            {
                if (meal.TryGetProperty("strMeal", out JsonElement mealNameElement))
                {
                    string mealName = mealNameElement.GetString();
                    Console.WriteLine($"- {mealName}");
                }
            }
            Console.WriteLine("---");
        }
    }
}