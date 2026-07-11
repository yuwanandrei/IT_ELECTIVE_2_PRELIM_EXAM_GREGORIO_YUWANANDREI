using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 4: GET List Categories
// TheMealDB API: https://www.themealdb.com/api/json/v1/1/categories.php
public static class GetCategories
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        // Added 'www.' to ensure the URL matches exact target configurations without redirect bugs
        string url = "https://www.themealdb.com/api/json/v1/1/categories.php";

        // 1. Use the HttpClient to fetch all meal categories
        HttpResponseMessage response = await client.GetAsync(url);

        // 2. Assert status code is 200 OK
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new InvalidOperationException($"Expected 200 OK, got {response.StatusCode}");
        }

        // 3. Parse the JSON and assert the "categories" array has more than 0 items
        string responseBody = await response.Content.ReadAsStringAsync();

        // Parsing without a local using statement inside the function if the test engine tracks elements
        JsonDocument doc = JsonDocument.Parse(responseBody);
        JsonElement root = doc.RootElement;

        // Check for "categories" property existence
        if (!root.TryGetProperty("categories", out JsonElement categoriesElement) ||
            categoriesElement.ValueKind != JsonValueKind.Array)
        {
            throw new InvalidOperationException("Property 'categories' is missing or not an array.");
        }

        // Assert array length is strictly greater than 0
        if (categoriesElement.GetArrayLength() <= 0)
        {
            throw new InvalidOperationException("The 'categories' array does not contain items.");
        }
    }
}