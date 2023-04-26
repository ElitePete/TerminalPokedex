using System;



namespace TerminalPokedex
{
    class Program
    {

        
        
        public static async Task Main(string[]? args)
        {

            TextArt();

            //Program prompt start
            string welcomeMessage = "Welcome to TerminalPokedex. " +
                "\nHere you will find all information about the world of Pokemon. " +
                "\nPick from one of the following options: \n1. Search Pokemon " +
                "\n2. Search Berries " +
                "\n3. Search Item " +
                "\n4. Search Move " +
                "\n0. Settings \n";
            
            //Typing effect for welcome message
            foreach (char c in welcomeMessage)
            {
                Console.Write(c);
                Thread.Sleep(10);
            }

            string mainResponse = Console.ReadLine();

            if (mainResponse == "1")
            {
                await OptionOne();
            } 
            else if(mainResponse == "2") 
            {
                await OptionTwo();
            }
            else if(mainResponse == "3") 
            {
               await OptionThree();
            }else if(mainResponse == "4")
            {
                await OptionFour();
            }
            else if(mainResponse == "0")
            {
                await SettingsOption();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input \n");
                Console.WriteLine("");
                await Main(args);
            }


           
        }

        public static async Task RepeatPokemonSearch()
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
                Console.WriteLine("That was not an option. Please and try again.");
                Thread.Sleep(2500);
                await RepeatPokemonSearch();
            }
        }
        
        public static async Task OptionOne()
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
            else if (pokemonResponse == "3")
            {
                Console.Clear();
                await Program.Main(new string[0]);
            }
            else
            {
                Console.WriteLine("That was not an option. Please wait and try again.");
                Thread.Sleep(1500);
                await OptionOne();
            }
        }

        public static async Task OptionTwo()
        {
            Console.WriteLine("Enter the name of the berry: ");
            Console.WriteLine("(This is not case sensitive)");

            string? berryName = Console.ReadLine();
            Console.Clear();
            await PokemonSearcher.SearchBerries(berryName);
        }

        public static async Task OptionThree()
        {
            Console.WriteLine("Enter the name or id of the item: ");
            Console.WriteLine("(This is not case sensitive)");

            string? itemName = Console.ReadLine();
            Console.Clear();
            await PokemonSearcher.SearchItem(itemName);
        }

        public static async Task OptionFour()
        {
            Console.WriteLine("Enter the name or id of the move: ");
            Console.WriteLine("(This is not case sensitive)");

            string? moveName = Console.ReadLine();
            Console.Clear();
            await PokemonSearcher.SearchMove(moveName);
        }

        public static async Task SettingsOption()
        {
            Console.Clear();
            Console.WriteLine("What would you like to adjust? \n1. Background Color \n2. Text Color");
            string settingsResponse = Console.ReadLine();
            if (settingsResponse == "1")
            {
                Console.WriteLine("Here is a list of possible background colors. Please type the color you want as you see it below or type .");
                Console.WriteLine("Black \nDarkBlue \nDarkGreen \nDarkCyan \nDarkRed \nDarkMagenta \nDarkYellow \nGray \nDarkGray \nBlue \nGreen \nCyan \nRed \nMagenta \nYellow \nWhite");
                Console.WriteLine("Change to:");
                string backgroundResponse = Console.ReadLine();
                ConsoleColor backgroundColor;

                backgroundColor = backgroundResponse.ToLower() switch
                {
                    "black" => ConsoleColor.Black,
                    "darkblue" => ConsoleColor.DarkBlue,
                    "darkgreen" => ConsoleColor.DarkGreen,
                    "darkcyan" => ConsoleColor.DarkCyan,
                    "darkred" => ConsoleColor.DarkRed,
                    "darkmagenta" => ConsoleColor.DarkMagenta,
                    "darkyellow" => ConsoleColor.DarkYellow,
                    "gray" => ConsoleColor.Gray,
                    "darkgray" => ConsoleColor.DarkGray,
                    "blue" => ConsoleColor.Blue,
                    "green" => ConsoleColor.Green,
                    "cyan" => ConsoleColor.Cyan,
                    "red" => ConsoleColor.Red,
                    "magenta" => ConsoleColor.Magenta,
                    "yellow" => ConsoleColor.Yellow,
                    "white" => ConsoleColor.White,
                    _ => ConsoleColor.Black 
                };

                Console.BackgroundColor = backgroundColor;
                Console.Clear();
                await Program.Main(new string[0]);


            }
            else if (settingsResponse == "2")
            {
                Console.WriteLine("Here is a list of possible text colors. Please type the color you want as you see it below.");
                Console.WriteLine("Black \nDarkBlue \nDarkGreen \nDarkCyan \nDarkRed \nDarkMagenta \nDarkYellow \nGray \nDarkGray \nBlue \nGreen \nCyan \nRed \nMagenta \nYellow \nWhite");
                Console.WriteLine("Change to:");
                string textColorResponse = Console.ReadLine();
                ConsoleColor textColor;

                textColor = textColorResponse.ToLower() switch
                {
                    "black" => ConsoleColor.Black,
                    "darkblue" => ConsoleColor.DarkBlue,
                    "darkgreen" => ConsoleColor.DarkGreen,
                    "darkcyan" => ConsoleColor.DarkCyan,
                    "darkred" => ConsoleColor.DarkRed,
                    "darkmagenta" => ConsoleColor.DarkMagenta,
                    "darkyellow" => ConsoleColor.DarkYellow,
                    "darkgray" => ConsoleColor.DarkGray,
                    "blue" => ConsoleColor.Blue,
                    "green" => ConsoleColor.Green,
                    "cyan" => ConsoleColor.Cyan,
                    "red" => ConsoleColor.Red,
                    "magenta" => ConsoleColor.Magenta,
                    "yellow" => ConsoleColor.Yellow,
                    "white" => ConsoleColor.White,
                    _ => ConsoleColor.White
                };


                Console.ForegroundColor = textColor;
                Console.Clear();
                await Program.Main(new string[0]);

            }
            else
            {
                Console.Clear();
                await SettingsOption();
            }
        }

        public static string[] logoText = new string[]
        {
            "████████╗██████╗░░█████╗░██╗░░██╗███████╗██████╗░███████╗██╗░░██╗",
            "╚══██╔══╝██╔══██╗██╔══██╗██║░██╔╝██╔════╝██╔══██╗██╔════╝╚██╗██╔╝",
            "░░░██║░░░██████╔╝██║░░██║█████═╝░█████╗░░██║░░██║█████╗░░░╚███╔╝░",
            "░░░██║░░░██╔═══╝░██║░░██║██╔═██╗░██╔══╝░░██║░░██║██╔══╝░░░██╔██╗░",
            "░░░██║░░░██║░░░░░╚█████╔╝██║░╚██╗███████╗██████╔╝███████╗██╔╝╚██╗",
            "░░░╚═╝░░░╚═╝░░░░░░╚════╝░╚═╝░░╚═╝╚══════╝╚═════╝░╚══════╝╚═╝░░╚═╝"
        };

        public static void TextArt()
        {
            // Center each line of the ASCII text art at top
            int width = Console.WindowWidth;

            for (int i = 0; i < logoText.Length; i++)
            {
                int left = (width - logoText[i].Length) / 2;
                Console.SetCursorPosition(left, i);
                Console.WriteLine(logoText[i]);
            }
        }


       
    }

}