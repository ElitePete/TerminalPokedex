using System;



namespace TerminalPokedex
{
    class Program
    {

        public static string[] logoText = new string[]
        {
            "████████╗██████╗░░█████╗░██╗░░██╗███████╗██████╗░███████╗██╗░░██╗",
            "╚══██╔══╝██╔══██╗██╔══██╗██║░██╔╝██╔════╝██╔══██╗██╔════╝╚██╗██╔╝",
            "░░░██║░░░██████╔╝██║░░██║█████═╝░█████╗░░██║░░██║█████╗░░░╚███╔╝░",
            "░░░██║░░░██╔═══╝░██║░░██║██╔═██╗░██╔══╝░░██║░░██║██╔══╝░░░██╔██╗░",
            "░░░██║░░░██║░░░░░╚█████╔╝██║░╚██╗███████╗██████╔╝███████╗██╔╝╚██╗",
            "░░░╚═╝░░░╚═╝░░░░░░╚════╝░╚═╝░░╚═╝╚══════╝╚═════╝░╚══════╝╚═╝░░╚═╝"
        };
        
        public static async Task Main(string[]? args)
        {


            // Center each line of the ASCII text art at top
            int width = Console.WindowWidth;

            for (int i = 0; i < logoText.Length; i++)
            {
                int left = (width - logoText[i].Length) / 2;
                Console.SetCursorPosition(left, i);
                Console.WriteLine(logoText[i]);
            }
            //Program prompt start
            string welcomeMessage = "Welcome to TerminalPokedex. \nHere you will find all information about the world of Pokemon. \nPick from one of the following options: \n1. Search Pokemon \n2. Search Berries \n3. Settings \n";
            
            //Typing effect for welcome message
            foreach (char c in welcomeMessage)
            {
                Console.Write(c);
                Thread.Sleep(10);
            }

            string mainResponse = Console.ReadLine();

            if (mainResponse == "1")
            {
                Console.Clear();
                // Center each line of the ASCII text art at top
                int secondWidth = Console.WindowWidth;

                for (int i = 0; i < logoText.Length; i++)
                {
                    int left = (secondWidth - logoText[i].Length) / 2;
                    Console.SetCursorPosition(left, i);
                    Console.WriteLine(logoText[i]);
                }

                Console.WriteLine("Do you want to look up a Pokemon by name or number: \n1.Name \n2.Number \n3.Go Back");
                string pokemonResponse = Console.ReadLine();
                    if (pokemonResponse == "1") 
                    {
                        Console.WriteLine("Enter the name of the Pokemon: ");
                        Console.WriteLine("(This is not case sensitive)");
            
                        string? pokemonName = Console.ReadLine();
                        Console.Clear();
                        await PokemonSearcher.SearchPokemon(pokemonName);

                    } 
                    else if (pokemonResponse == "2")
                    {
                        Console.WriteLine("Enter the Pokemon number: ");
                        string? pokemonNumber = Console.ReadLine();
                        Console.Clear();
                        await PokemonSearcher.SearchPokemon(pokemonNumber);

                    }
                    else if(pokemonResponse == "3")
                    {
                        Console.Clear();
                        await Program.Main(args);
                    }
                    else
                    {
                        Console.WriteLine("That was not an option. Please relaunch and try again.");
                        Thread.Sleep(5000);
                        Environment.Exit(1);
                    }
            } 
            else if(mainResponse == "2") 
            {
                Console.WriteLine("Enter the name of the berry: ");
                Console.WriteLine("(This is not case sensitive)");

                string? berryName = Console.ReadLine();
                Console.Clear();
                await PokemonSearcher.SearchBerries(berryName);
            }
            else if(mainResponse == "3") 
            {
                Console.Clear() ;
                Console.WriteLine("What would you like to adjust? \n1. Background Color \n2. Text Color");
                string settingsResponse = Console.ReadLine();
                    if(settingsResponse == "1")
                    {
                        Console.WriteLine("Here is a list of possible background colors. Please type the color you want as you see it below.");
                        Console.WriteLine("Black \nDarkBlue \nDarkGreen \nDarkCyan \nDarkRed \nDarkMagenta \nDarkYellow \nGray \nDarkGray \nBlue \nGreen \nCyan \nRed \nMagenta \nYellow \nWhite");
                        Console.WriteLine("Change to:");
                        string backgroundResponse = Console.ReadLine();
                        ConsoleColor backgroundColor;

                        switch (backgroundResponse.ToLower())
                        {
                            case "black":
                                backgroundColor = ConsoleColor.Black;
                                break;
                            case "darkblue":
                                backgroundColor = ConsoleColor.DarkBlue;
                                break;
                            case "darkgreen":
                                backgroundColor = ConsoleColor.DarkGreen;
                                break;
                            case "darkcyan":
                                backgroundColor = ConsoleColor.DarkCyan;
                                break;
                            case "darkred":
                                backgroundColor = ConsoleColor.DarkRed;
                                break;
                            case "darkmagenta":
                                backgroundColor = ConsoleColor.DarkMagenta;
                                break;
                            case "darkyellow":
                                backgroundColor = ConsoleColor.DarkYellow;
                                break;
                            case "gray":
                                backgroundColor = ConsoleColor.Gray;
                                break;
                            case "darkgray":
                                backgroundColor = ConsoleColor.DarkGray;
                                break;
                            case "blue":
                                backgroundColor = ConsoleColor.Blue;
                                break;
                            case "green":
                                backgroundColor = ConsoleColor.Green;
                                break;
                            case "cyan":
                                backgroundColor = ConsoleColor.Cyan;
                                break;
                            case "red":
                                backgroundColor = ConsoleColor.Red;
                                break;
                            case "magenta":
                                backgroundColor = ConsoleColor.Magenta;
                                break;
                            case "yellow":
                                backgroundColor = ConsoleColor.Yellow;
                                break;
                            case "white":
                                backgroundColor = ConsoleColor.White;
                                break;
                            default:
                                Console.WriteLine("Invalid color name. Please try again.");
                                return;
                        }

                        Console.BackgroundColor = backgroundColor;
                        Console.Clear();
                        await Program.Main(args);


                    }
                    else if (settingsResponse == "2")
                {
                    Console.WriteLine("Here is a list of possible text colors. Please type the color you want as you see it below.");
                    Console.WriteLine("Black \nDarkBlue \nDarkGreen \nDarkCyan \nDarkRed \nDarkMagenta \nDarkYellow \nGray \nDarkGray \nBlue \nGreen \nCyan \nRed \nMagenta \nYellow \nWhite");
                    Console.WriteLine("Change to:");
                    string textColorResponse = Console.ReadLine();
                    ConsoleColor textColor;

                    switch (textColorResponse.ToLower())
                    {
                        case "black":
                            textColor = ConsoleColor.Black;
                            break;
                        case "darkblue":
                            textColor = ConsoleColor.DarkBlue;
                            break;
                        case "darkgreen":
                            textColor = ConsoleColor.DarkGreen;
                            break;
                        case "darkcyan":
                            textColor = ConsoleColor.DarkCyan;
                            break;
                        case "darkred":
                            textColor = ConsoleColor.DarkRed;
                            break;
                        case "darkmagenta":
                            textColor = ConsoleColor.DarkMagenta;
                            break;
                        case "darkyellow":
                            textColor = ConsoleColor.DarkYellow;
                            break;
                        case "gray":
                            textColor = ConsoleColor.Gray;
                            break;
                        case "darkgray":
                            textColor = ConsoleColor.DarkGray;
                            break;
                        case "blue":
                            textColor = ConsoleColor.Blue;
                            break;
                        case "green":
                            textColor = ConsoleColor.Green;
                            break;
                        case "cyan":
                            textColor = ConsoleColor.Cyan;
                            break;
                        case "red":
                            textColor = ConsoleColor.Red;
                            break;
                        case "magenta":
                            textColor = ConsoleColor.Magenta;
                            break;
                        case "yellow":
                            textColor = ConsoleColor.Yellow;
                            break;
                        case "white":
                            textColor = ConsoleColor.White;
                            break;
                        default:
                            Console.WriteLine("Invalid color name. Please try again.");
                            return;
                    }

                    Console.ForegroundColor = textColor;
                    Console.Clear();
                    await Program.Main(args);

                }
            }


           
        }

        public static async Task SecondaryMain()
        {
            Console.Clear();
            int thirdWidth = Console.WindowWidth;

            for (int i = 0; i < logoText.Length; i++)
            {
                int left = (thirdWidth - logoText[i].Length) / 2;
                Console.SetCursorPosition(left, i);
                Console.WriteLine(logoText[i]);
            }

            Console.WriteLine("Do you want to look up a Pokemon by name or number: \n1.Name \n2.Number \n");
            string response = Console.ReadLine();

            if (response == "1")
            {
                Console.WriteLine("Enter the name of the Pokemon: ");
                Console.WriteLine("(This is not case sensitive)");

                string? pokemonName = Console.ReadLine();
                Console.Clear();
                await PokemonSearcher.SearchPokemon(pokemonName);

            }
            else if (response == "2")
            {
                Console.WriteLine("Enter the Pokemon number: ");
                string? pokemonNumber = Console.ReadLine();
                Console.Clear();
                await PokemonSearcher.SearchPokemon(pokemonNumber);

            }
            else
            {
                Console.WriteLine("That was not an option. Please relaunch and try again.");
                Thread.Sleep(5000);
                Environment.Exit(1);
            }
        }



        


       
    }

}