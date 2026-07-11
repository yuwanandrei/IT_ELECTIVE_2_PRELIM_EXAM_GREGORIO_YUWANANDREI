using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 9: GET Handle 404 Not Found
// TheMealDB API: https://themealdb.com/api/json/v1/1/lookup.php?i={id}
public static class HandleNotFound
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/lookup.php?i=999999";

        // 1. Use the HttpClient to look up a meal with an ID that doesn't exist (ID 999999)
        HttpResponseMessage response = await client.GetAsync(url);

        // 2. Assert the HTTP status code is 200 OK (TheMealDB always returns 200)
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Assertion Failed: Expected status code 200 OK, but received {response.StatusCode}");
        }

        // Read the response content as a string
        string responseBody = await response.Content.ReadAsStringAsync();

        // 3. Parse the JSON and assert that the "meals" field is null
        using (JsonDocument doc = JsonDocument.Parse(responseBody))
        {
            JsonElement root = doc.RootElement;

            // Check if the "meals" property exists
            if (!root.TryGetProperty("meals", out JsonElement mealsElement))
            {
                throw new Exception("Assertion Failed: The 'meals' property is completely missing from the JSON payload.");
            }

            // Assert that the value of the "meals" property is explicitly null
            if (mealsElement.ValueKind != JsonValueKind.Null)
            {
                throw new Exception($"Assertion Failed: Expected 'meals' field to be null, but it was type '{mealsElement.ValueKind}'.");
            }

            // Optional: Print confirmation
            Console.WriteLine($"[Exercise 9 Success] Confirmed: Network status is {response.StatusCode}, but 'meals' content is correctly null.");
        }
    }
}