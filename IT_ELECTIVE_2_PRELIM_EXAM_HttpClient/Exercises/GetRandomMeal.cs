using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 1: GET Random Meal
// TheMealDB API: https://themealdb.com/api/json/v1/1/random.php
public static class GetRandomMeal
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/random.php";

        // 1. Use the HttpClient to send a GET request to the URL above
        HttpResponseMessage response = await client.GetAsync(url);

        // 2. Read the response as a string
        string responseBody = await response.Content.ReadAsStringAsync();

        // 3. Assert that the status code is 200 OK
        // (If using a specific test framework like xUnit, this would be Assert.Equal(HttpStatusCode.OK, response.StatusCode);)
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Assertion Failed: Expected status code 200 OK, but received {response.StatusCode}");
        }

        // Alternatively, you can use: response.EnsureSuccessStatusCode();

        // 4. Assert that the response body is not null or empty
        if (string.IsNullOrEmpty(responseBody))
        {
            throw new Exception("Assertion Failed: Response body is null or empty.");
        }

        // Optional: Print out the success result to the console for visibility during testing
        Console.WriteLine($"[Exercise 1 Success] Status: {response.StatusCode}. Content Length: {responseBody.Length}");
    }
}