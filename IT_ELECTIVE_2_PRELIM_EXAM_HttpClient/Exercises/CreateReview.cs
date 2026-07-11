using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 6: POST Create Review
// JSONPlaceholder API: https://jsonplaceholder.typicode.com/posts
public static class CreateReview
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://jsonplaceholder.typicode.com/posts";

        // 1. Create a JSON body string: { "title": "Great Pasta!", "body": "Loved this recipe", "userId": 1 }
        string jsonBody = "{\"title\": \"Great Pasta!\", \"body\": \"Loved this recipe\", \"userId\": 1}";

        // 2. Wrap it in StringContent with media type "application/json"
        using HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // 3. Send a POST request to the URL
        HttpResponseMessage response = await client.PostAsync(url, content);

        // 4. Assert status code is 201 Created
        if (response.StatusCode != HttpStatusCode.Created) // HttpStatusCode.Created is 201
        {
            throw new Exception($"Assertion Failed: Expected status code 201 Created, but received {response.StatusCode}");
        }

        // Read the response content as a string
        string responseBody = await response.Content.ReadAsStringAsync();

        // 5. Parse the response JSON and assert it contains an "id" field
        using (JsonDocument doc = JsonDocument.Parse(responseBody))
        {
            JsonElement root = doc.RootElement;

            // Assert the response has an "id" field with a value
            if (!root.TryGetProperty("id", out JsonElement idElement) || idElement.ValueKind == JsonValueKind.Null)
            {
                throw new Exception("Assertion Failed: The response does not contain a valid 'id' field.");
            }

            // Optional: Print out success details and the newly created Mock ID (JSONPlaceholder typically returns 101)
            Console.WriteLine($"[Exercise 6 Success] Resource Created. Assigned ID: {idElement}");
        }
    }
}