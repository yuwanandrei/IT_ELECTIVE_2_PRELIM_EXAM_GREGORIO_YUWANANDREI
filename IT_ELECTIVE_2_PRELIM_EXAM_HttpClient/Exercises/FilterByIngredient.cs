using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 5: GET Filter by Ingredient
// TheMealDB API: https://themealdb.com/api/json/v1/1/filter.php?i={ingredient}
public static class FilterByIngredient
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/filter.php?i=chicken_breast";

        // 1. Use the HttpClient to filter meals by ingredient "chicken_breast"
        HttpResponseMessage response = await client.GetAsync(url);

        // 2. Assert status code is 200 OK
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Assertion Failed: Expected status code 200 OK, but received {response.StatusCode}");
        }

        // Read the response content as a string
        string responseBody = await response.Content.ReadAsStringAsync();

        // 3. Parse the JSON and assert the "meals" array has at least 1 item
        using (JsonDocument doc = JsonDocument.Parse(responseBody))
        {
            JsonElement root = doc.RootElement;

            // Check if the "meals" property exists and is not null
            if (!root.TryGetProperty("meals", out JsonElement mealsElement) || mealsElement.ValueKind == JsonValueKind.Null)
            {
                throw new Exception("Assertion Failed: The 'meals' property is missing or null.");
            }

            // Verify that the "meals" element is a populated array
            if (mealsElement.ValueKind != JsonValueKind.Array || mealsElement.GetArrayLength() == 0)
            {
                throw new Exception("Assertion Failed: The 'meals' array is empty or not structurally valid.");
            }

            // Optional: Print out success details for verification
            Console.WriteLine($"[Exercise 5 Success] Found {mealsElement.GetArrayLength()} meal recipe(s) using 'chicken_breast'.");
        }
    }
}