// using System.Net.Http;
using IntroToAPI.Models;
using IntroToAPI;

SwapiService swService = new SwapiService();

// using custom "generic" method for API interaction
Person lando = swService.GetAsync<Person>("https://swapi.dev/api/people/8").Result;
Person leia =  swService.GetPersonAsync("https://swapi.dev/api/people/5").Result;

if (leia != null)
{
    System.Console.WriteLine(leia.name);
}

foreach (string vehicleUrl in leia.vehicles)
{
// using custom "generic" method for API interaction
    Vehicle personVehicle = swService.GetAsync<Vehicle>(vehicleUrl).Result;
    System.Console.WriteLine($"\nThis dude has a {personVehicle.name} from {personVehicle.created}!!!\n");
}

System.Console.WriteLine("\n--------------------\n");

SearchResult<Person> skywalkers = swService.GetSearchAsync<Person>("people", "skywalker").Result;

System.Console.WriteLine("\nSearch results:\n");
foreach (Person skywalker in skywalkers.results)
{
    System.Console.WriteLine(skywalker.name);
}

System.Console.WriteLine("\n--------------------\n");

// ! HttpClient C# default HTTP request example
HttpClient httpEx = new HttpClient();

// async methods return a "Task<>" meaning the task of making the request hasn't explicitly been resolved yet
// ".Result" is used to get the result of the task
HttpResponseMessage res = httpEx.GetAsync("https://swapi.dev/api/people/1").Result;

if (res.IsSuccessStatusCode)
{
    // ".Content" is used after getting a successful ".Result"
    var data = res.Content;

    // ".ReadAsStringAsync()" used when unaware of JSON data structure and still need to create Models
    string dataString = data.ReadAsStringAsync().Result;
    System.Console.WriteLine(dataString);

    // ".ReadAsAsync<T>()" is used to specify a data type for info coming back from HTTP response
    Person swPerson = data.ReadAsAsync<Person>().Result;

    System.Console.WriteLine($"\nThis is {swPerson.name} and they have pretty {swPerson.hair_color} hair ;-)\n");

    foreach (string vehicleUrl in swPerson.vehicles)
    {
        HttpResponseMessage vehicleRes = httpEx.GetAsync(vehicleUrl).Result;

        var vData = vehicleRes.Content;
        Vehicle personVehicle = vData.ReadAsAsync<Vehicle>().Result;
        System.Console.WriteLine($"\nThis dude has a {personVehicle.name} from {personVehicle.created}!!!\n");
    }
}