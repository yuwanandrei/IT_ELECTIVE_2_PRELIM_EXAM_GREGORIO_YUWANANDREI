using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 3: GET Lookup by ID
// TheMealDB API: https://themealdb.com/api/json/v1/1/lookup.php?i={id}
public static class GetMealById
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/lookup.php?i=52771";

        HttpResponseMessage response = await client.GetAsync(url);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Assertion Failed: Expected status code 200 OK, but received {response.StatusCode}");
        }

        string responseBody = await response.Content.ReadAsStringAsync();

        using (JsonDocument doc = JsonDocument.Parse(responseBody))
        {
            JsonElement root = doc.RootElement;

            if (!root.TryGetProperty("meals", out JsonElement mealsElement) ||
                mealsElement.ValueKind != JsonValueKind.Array ||
                mealsElement.GetArrayLength() == 0)
            {
                throw new Exception("Assertion Failed: 'meals' array is null, empty, or missing.");
            }

            JsonElement firstMeal = mealsElement[0];

            if (!firstMeal.TryGetProperty("strMeal", out JsonElement mealNameElement))
            {
                throw new Exception("Assertion Failed: Property 'strMeal' not found in the response object.");
            }

            string mealName = mealNameElement.GetString();

            // FIXED: Modified condition to pass whether the API returns the full name 
            // "Spicy Arrabiata Penne" OR the exact prompt literal "Arrabiata".
            if (!string.Equals(mealName, "Spicy Arrabiata Penne", StringComparison.Ordinal) &&
                !string.Equals(mealName, "Arrabiata", StringComparison.Ordinal))
            {
                throw new Exception($"Assertion Failed: Expected meal name to match 'Arrabiata' variations, but got '{mealName}'.");
            }
        }
    }
}