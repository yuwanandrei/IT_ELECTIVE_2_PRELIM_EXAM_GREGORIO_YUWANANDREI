using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 2: GET Search by Name
// TheMealDB API: https://themealdb.com/api/json/v1/1/search.php?s={name}
public static class SearchMealByName
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/search.php?s=Arrabiata";

        // 1. Use the HttpClient to search for meals with name "Arrabiata"
        HttpResponseMessage response = await client.GetAsync(url);

        // 2. Assert status code is 200 OK
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Assertion Failed: Expected status code 200 OK, but received {response.StatusCode}");
        }

        // Read the response content as a string to prepare for parsing
        string responseBody = await response.Content.ReadAsStringAsync();

        // 3. Parse the JSON and assert the "meals" array has at least 1 result
        using (JsonDocument doc = JsonDocument.Parse(responseBody))
        {
            JsonElement root = doc.RootElement;

            // Check if the "meals" property exists and is not null/empty
            if (!root.TryGetProperty("meals", out JsonElement mealsElement) || mealsElement.ValueKind == JsonValueKind.Null)
            {
                throw new Exception("Assertion Failed: The 'meals' property is missing or null.");
            }

            // Verify that the "meals" element is an array and contains at least 1 element
            if (mealsElement.ValueKind != JsonValueKind.Array || mealsElement.GetArrayLength() == 0)
            {
                throw new Exception("Assertion Failed: The 'meals' array does not contain any results.");
            }

            // Optional: Print out success details for verification
            Console.WriteLine($"[Exercise 2 Success] Found {mealsElement.GetArrayLength()} meal(s) matching 'Arrabiata'.");
        }
    }
}