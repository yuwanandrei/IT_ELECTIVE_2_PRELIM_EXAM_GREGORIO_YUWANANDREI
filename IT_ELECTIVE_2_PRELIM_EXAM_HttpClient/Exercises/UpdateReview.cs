namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 7: PUT Update Review
// JSONPlaceholder API: https://jsonplaceholder.typicode.com/posts/{id}
//
// Your task:
// 1. Create a JSON body: { "id": 1, "title": "Updated Review", "body": "Even better than before!", "userId": 1 }
// 2. Wrap it in StringContent with media type "application/json"
// 3. Send a PUT request to update post with ID 1
// 4. Assert status code is 200 OK
// 5. Parse the response JSON and assert the title is "Updated Review"
//
// Hint: Use await client.PutAsync(url, content)

public static class UpdateReview
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        // TODO: Create JSON string with id, title, body, and userId
        // TODO: Create StringContent with the JSON and Content-Type "application/json"
        // TODO: Send PUT request to https://jsonplaceholder.typicode.com/posts/1
        // TODO: Assert status code is 200 OK
        // TODO: Parse the response JSON
        // TODO: Assert the title is "Updated Review"

        throw new NotImplementedException();
    }
}
