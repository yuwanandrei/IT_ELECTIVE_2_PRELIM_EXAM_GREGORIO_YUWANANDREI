using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 7: PUT Update Review
// JSONPlaceholder API: https://jsonplaceholder.typicode.com/posts/{id}
public static class UpdateReview
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://jsonplaceholder.typicode.com/posts/1";

        // 1. Create a JSON body: { "id": 1, "title": "Updated Review", "body": "Even better than before!", "userId": 1 }
        string jsonBody = "{\"id\": 1, \"title\": \"Updated Review\", \"body\": \"Even better than before!\", \"userId\": 1}";

        // 2. Wrap it in StringContent with media type "application/json"
        using HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        // 3. Send a PUT request to update post with ID 1
        HttpResponseMessage response = await client.PutAsync(url, content);

        // 4. Assert status code is 200 OK
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Assertion Failed: Expected status code 200 OK, but received {response.StatusCode}");
        }

        // Read the response content as a string
        string responseBody = await response.Content.ReadAsStringAsync();

        // 5. Parse the response JSON and assert the title is "Updated Review"
        using (JsonDocument doc = JsonDocument.Parse(responseBody))
        {
            JsonElement root = doc.RootElement;

            // Check if the "title" property exists
            if (!root.TryGetProperty("title", out JsonElement titleElement))
            {
                throw new Exception("Assertion Failed: Property 'title' not found in the response object.");
            }

            string updatedTitle = titleElement.GetString();

            // Assert that the title exactly matches "Updated Review"
            if (!string.Equals(updatedTitle, "Updated Review", StringComparison.Ordinal))
            {
                throw new Exception($"Assertion Failed: Expected title 'Updated Review', but got '{updatedTitle}'.");
            }

            // Optional: Print confirmation
            Console.WriteLine($"[Exercise 7 Success] Resource updated successfully. Verified Title: '{updatedTitle}'.");
        }
    }
}