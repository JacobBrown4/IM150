using IntroToAPI.Models;

namespace IntroToAPI
{
    public class SwapiService
    {
        private readonly HttpClient _httpEx = new HttpClient();

        /*
        even though we are returning a "person" object, "return type" has to be 
        specified as a "Task<>" since the custom method is async 
        */
        public async Task<Person> GetPersonAsync(string url)
        {
            HttpResponseMessage res = await _httpEx.GetAsync(url);
                        
            if (res.IsSuccessStatusCode)
            {
                // ".ReadAsAsync<T>()" is used to specify a data type for info coming back from HTTP response
                Person person = await res.Content.ReadAsAsync<Person>();

                return person;
            }

            return null;
        }

        public async Task<Vehicle> GetVehicleAsync(string url)
        {
            HttpResponseMessage res = await _httpEx.GetAsync(url);
                        
            if (res.IsSuccessStatusCode)
            {
                // ".ReadAsAsync<T>()" is used to specify a data type for info coming back from HTTP response
                Vehicle vehicle = await res.Content.ReadAsAsync<Vehicle>();

                return vehicle;
            }

            return null;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            HttpResponseMessage res = await _httpEx.GetAsync(url);
                        
            if (res.IsSuccessStatusCode)
            {
                // ".ReadAsAsync<T>()" is used to specify a data type for info coming back from HTTP response
                return await res.Content.ReadAsAsync<T>();
            }

            return default;
        }
        public async Task<SearchResult<T>> GetSearchAsync<T>(string category, string query)
        {
            HttpResponseMessage res = await _httpEx.GetAsync($"https://swapi.dev/api/{category}/?search={query}");
                        
            if (res.IsSuccessStatusCode)
            {
                // ".ReadAsAsync<T>()" is used to specify a data type for info coming back from HTTP response
                return await res.Content.ReadAsAsync<SearchResult<T>>();
            }

            return default;
        }
    }
}