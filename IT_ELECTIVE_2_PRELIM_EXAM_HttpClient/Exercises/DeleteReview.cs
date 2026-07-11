using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 8: DELETE Remove Review
// JSONPlaceholder API: https://jsonplaceholder.typicode.com/posts/{id}
public static class DeleteReview
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://jsonplaceholder.typicode.com/posts/1";

        // 1. Send a DELETE request to remove post with ID 1
        HttpResponseMessage response = await client.DeleteAsync(url);

        // 2. Assert status code is 200 OK
        if (response.StatusCode != HttpStatusCode.OK) // HttpStatusCode.OK is 200
        {
            throw new Exception($"Assertion Failed: Expected status code 200 OK, but received {response.StatusCode}");
        }

        // Optional: Print confirmation
        Console.WriteLine($"[Exercise 8 Success] Resource at ID 1 deleted successfully. Status: {response.StatusCode}");
    }
}