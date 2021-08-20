using System;

namespace PokemonCatchThemAll
{
    class Program
    {
        static void Main(string[] args)
        {
            //Introduce game
            Console.WriteLine("You want to be the very best... like no one ever was!" +
               "\nTo cath them is your real test... to train them is your cause!! \nYou will travel accross the land... searching far and wide!" +
               "\nEach pokemon to understand... the power that's inside!" +
               "\nPokemon!! You have got to catch 'em all!!" +
               "\n\nInsert you Pokemon trainer path and see how many pokemons you can catch!" +
               "\nPaths:");

            var directionValues = Enum.GetValues(typeof(Directions));
            foreach (var direction in directionValues)
            {
                Console.WriteLine(" - " + direction);
            }

            //Get user path
            string userInput = Console.ReadLine();

            var pokemonGame = new PokemonGame();
            pokemonGame.RunGame(userInput);
            Console.WriteLine("Ash position " + pokemonGame.AshLocation.GetLocation());
        }
    }
}
