﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace TerminalPokedex
{
    public static class PokemonSearcher
    {
        
        public static async Task SearchPokemon(string? name)
        {

            if (name is not null)
            {
                try
                {
                    // Set up an HttpClient to make requests to the PokeAPI
                    var httpClient = new HttpClient();
                    httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");

                    // Make a request for information about a specific Pokemon
                    var response = await httpClient.GetAsync($"pokemon/{name?.ToLower()}");
                    response.EnsureSuccessStatusCode(); // Throw an exception if the status code is not in the 2xx range

                    var responseContent = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response into a Pokemon object
                    var pokemon = JsonConvert.DeserializeObject<Pokemon>(responseContent);

                    if (!string.IsNullOrEmpty(pokemon.LocationAreaEncountersUrl))
                    {
                        var locationResponse = await httpClient.GetAsync(pokemon.LocationAreaEncountersUrl);
                        locationResponse.EnsureSuccessStatusCode();

                        var locationResponseContent = await locationResponse.Content.ReadAsStringAsync();
                        var locationAreaEncounters = JsonConvert.DeserializeObject<List<LocationAreaEncounter>>(locationResponseContent);

                        pokemon.LocationAreaEncounters = locationAreaEncounters;
                    }

                    // Display information about the Pokemon in the console
                    Console.WriteLine($"Number: {pokemon.Id}");
                    Console.WriteLine("");
                    Console.WriteLine($"Name: {pokemon.Name}");
                    Console.WriteLine("");
                    Console.WriteLine($"Height: {pokemon.Height} decimeters");
                    Console.WriteLine("");
                    Console.WriteLine($"Weight: {pokemon.Weight}");
                    Console.WriteLine("");
                    Console.WriteLine($"List of location encounters: ");

                    if (pokemon.LocationAreaEncounters != null && pokemon.LocationAreaEncounters.Count > 0)
                    {
                        foreach (var locationAreaEncounter in pokemon.LocationAreaEncounters)
                        {
                            Console.WriteLine($"Location Area: {locationAreaEncounter.LocationArea?.Name}");
                            if (locationAreaEncounter.VersionDetails != null)
                            {
                                Console.WriteLine("Game Versions:");
                                foreach (var versionDetail in locationAreaEncounter.VersionDetails)
                                {
                                    Console.WriteLine($"  - {versionDetail.Version?.Name}: Max chance {versionDetail.MaxChance}%");
                                }
                            }
                            Console.WriteLine("");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No locations found");
                    }


                    Console.WriteLine("");
                    Console.WriteLine("Images of Pokemon \n \n(Hold CTRL and click on the link to automatically open in browser)");
                    Console.WriteLine("");
                    Console.WriteLine($"https://www.google.com/search?q={pokemon.Name.ToLower()}&source=lnms&tbm=isch&sa=X&ved=2ahUKEwiclqKsnsD-AhURmWoFHQljDsYQ0pQJegQIAhAC&biw=1879&bih=931");
                    Console.WriteLine("");
                    Console.WriteLine("Would you like to search another?");
                    Console.WriteLine("");
                    Console.WriteLine("1. Yes \n2. No");
                    string? repeatSearchAnswer = Console.ReadLine();

                    if (repeatSearchAnswer == "1") 
                    {
                        Console.Clear();
                        await Program.SecondaryMain();
                    }
                    else if (repeatSearchAnswer == "2")
                    {
                        Console.WriteLine("Thanks for using T-Pokedex \n");
                        Console.Clear();
                        Thread.Sleep(1000);
                        await Program.Main(new string[0]);
                        
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Thanks for using T-Pokedex \n" );
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                    }


                    
                }
                catch (HttpRequestException)
                {
                    Console.WriteLine($"Error: Pokemon {name} not found in PokeDatabase");

                    Console.WriteLine("Perhaps try again: ");
                    name = Console.ReadLine();
                    Console.Clear();
                    await SearchPokemon(name);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("EXC: Search Another One: ");
                    name = Console.ReadLine();
                    Console.Clear();
                    await SearchPokemon(name);

                }

            }
            else { await Program.Main(new string[0]); }


        }

        public static async Task SearchBerries(string? name)
        {
            if(name is not null)
            {
                try
                {
                    // Set up an HttpClient to make requests to the PokeAPI
                    var httpClient = new HttpClient();
                    httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");

                    // Make a request for information about a specific Pokemon
                    var response = await httpClient.GetAsync($"berry/{name?.ToLower()}");
                    response.EnsureSuccessStatusCode(); // Throw an exception if the status code is not in the 2xx range

                    var responseContent = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response into a berry object
                    var berry = JsonConvert.DeserializeObject<Berry>(responseContent);


                    Console.WriteLine($"Berry Id: {berry.Id}");
                    Console.WriteLine($"Name: {berry.Name} berry");
                    Console.WriteLine($"Growth Time: {berry.Growth_Time}");
                    Console.WriteLine($"Max Harvest: {berry.Max_Harvest}");
                    Console.WriteLine($"Natural Gift Power: {berry.Natural_Gift_Power}");
                    Console.WriteLine($"Size: {berry.Size}");
                    Console.WriteLine($"Smoothness: {berry.Smoothness}");
                    Console.WriteLine($"Soil Dryness: {berry.Soil_Dryness} \n");

                    Console.WriteLine("Would you like to go back to \n1. Main menu \n2. Exit TPokedex \n");
                    string berryMenuResponse = Console.ReadLine();
                    switch (berryMenuResponse)
                    {
                        case "1":
                            Console.Clear();
                            await Program.Main(new string[0]);
                            break;
                        case "2":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.Clear();
                            await Program.Main(new string[0]);
                            break;
                    }


                }
                catch (HttpRequestException)
                {
                    Console.WriteLine($"Error: Berry {name} not found");

                    Console.WriteLine("Try again: ");
                    name = Console.ReadLine();
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("EXC: Search Another One: ");
                    name = Console.ReadLine();
                    Console.Clear();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Berry Does Not Exist");
            }


        }

        class Pokemon
        {
            public int? Id { get; set; }
            public string? Name { get; set; }
            public int Height { get; set; }
            public int Weight { get; set; }

            [JsonProperty("location_area_encounters")]
            public string? LocationAreaEncountersUrl { get; set; }

            public List<LocationAreaEncounter>? LocationAreaEncounters { get; set; }
        }

        class Berry
        {
            public int? Id { get; set; }
            public string? Name { get; set; }
            public int? Growth_Time { get; set; }
            public int? Max_Harvest { get; set; }
            public int? Natural_Gift_Power { get; set; }
            public int? Size { get; set; }
            public int? Smoothness { get; set; }
            public int? Soil_Dryness { get; set; }
        }

        class LocationAreaEncounter
        {
            [JsonProperty("location_area")]
            public LocationArea? LocationArea { get; set; }

            [JsonProperty("version_details")]
            public List<VersionDetail>? VersionDetails { get; set; }    



        }

        class LocationArea
        {
            public string? Name { get; set; }
            public string? Url { get; set; }
        }

        class VersionDetail
        {
            [JsonProperty("version")]
            public GameVersion? Version { get; set; }

            [JsonProperty("max_chance")]
            public int MaxChance { get; set; }
        }

        class GameVersion
        {
            public string? Name { get; set; }
            public string? Url { get; set; }
        }

    }

}





