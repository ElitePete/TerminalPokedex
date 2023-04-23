using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TerminalPokedex
{
    class Program
    {
       
        static async Task Main(string[] args)
        {
            Console.WriteLine("Search a Pokemon by name or number:");
           
            string pokemonName = Console.ReadLine();
            await SearchPokemon(pokemonName);


        }



        static async Task SearchPokemon(string name)
        {
            try
            {
                // Set up an HttpClient to make requests to the PokeAPI
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");

                // Make a request for information about a specific Pokemon
                var response = await httpClient.GetAsync($"pokemon/{name.ToLower()}");
                response.EnsureSuccessStatusCode(); // Throw an exception if the status code is not in the 2xx range

                var responseContent = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON response into a Pokemon object
                var pokemon = JsonConvert.DeserializeObject<Pokemon>(responseContent);

                // Display information about the Pokemon in the console
                Console.WriteLine($"Number: {pokemon.Id}");
                Console.WriteLine($"Name: {pokemon.Name}");
                Console.WriteLine($"Height: {pokemon.Height} decimeters");
                Console.WriteLine($"Weight: {pokemon.Weight}");
                Console.WriteLine($"Link to list of location area: {pokemon.Location_area_encounters}");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: Pokemon {name} not found");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        // Define a class to represent a Pokemon
        class Pokemon
        {
            public int Id {  get; set; }
            public string Name { get; set; }
            public int Height { get; set; }
            public int Weight { get; set; }

            public string Location_area_encounters { get; set; }
        }
    }

}