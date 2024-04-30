// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using System.Text;
using System.Text.Json;
Names names = new Names();
var random = new Random();
HttpClient client = new HttpClient();
string apiUrl = "https://localhost:7272/Patient";
DateTime start = new DateTime(1995, 1, 1);
int range = (DateTime.Today - start).Days;
for (int i = 0; i < names.namesArr.Length; i++)
{
    var name = names.GetName(i);
    var patient =
        new Patient()
        {
            Id = Guid.NewGuid(),
            Active = random.Next(2) == 1,
            Birthdate = start.AddDays(random.Next(range)),
            Gender = names.gender.GetValueOrDefault(random.Next(3)),
            Name = new Name()
            {
                Id = Guid.NewGuid(),
                Family = name[0],
                Given = new string[] { name[1], name[2] },
                Use = "official",
            }
        };
    string response = await SendApiPostRequest(apiUrl, JsonSerializer.Serialize(patient));

    Console.WriteLine($"Ответ API (итерация {i + 1}): {response}");
}

async Task<string> SendApiPostRequest(string url, string jsonContent)
{
    try
    {
        HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = content
        };

        HttpResponseMessage response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();

        return responseBody;
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine("\nException Caught!");
        Console.WriteLine("Message :{0} ", e.Message);
        return null;
    }
}