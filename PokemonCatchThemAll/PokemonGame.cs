using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonCatchThemAll
{
    public enum Directions
    {
        N,
        S,
        W,
        E
    }

    public class PokemonGame
    {
        private List<Directions> _directionsList;
        private List<Location> _visitedLocations;
        public int TotalPokemons { get; private set; }
        public Location AshLocation { get; private set; }

        public PokemonGame()
        {
            _visitedLocations = new List<Location>();
            TotalPokemons = 0;
            AshLocation = new Location(0, 0);
        }

        protected bool ValidateUserInput(string userInput)
        {
            if (userInput == "")
            {
                Console.WriteLine("No Path found");
                return false;
            }
            _directionsList = new List<Directions>();

            //Sort user input
            List<string> userInputToList = userInput.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string userInputToString = String.Join("", userInputToList);

            //Add it to direction list
            foreach (var c in userInputToString.ToUpper())
            {
                try
                {
                    _directionsList.Add((Directions)Enum.Parse(typeof(Directions), c.ToString(), true));
                }
                catch
                {
                    Console.WriteLine($"\"{c}\" Invalid Direction.");
                    return false;
                }
            }

            return true;
        }

        protected void MoveAsh(int direction)
        {
            switch (direction)
            {
                case 0:
                    AshLocation.CoordinateX--;
                    break;

                case 1:
                    AshLocation.CoordinateX++;
                    break;

                case 2:
                    AshLocation.CoordinateY--;
                    break;

                case 3:
                    AshLocation.CoordinateY++;
                    break;

                default:
                    return;
            }
        }

        void UpdateGame()
        {
            if (!_visitedLocations.Contains(AshLocation))
            {
                _visitedLocations.Add(new Location(AshLocation.CoordinateX, AshLocation.CoordinateY));
                TotalPokemons++;
            }
        }

        public int RunGame(string userInput)
        {
            if (ValidateUserInput(userInput))
            {
                UpdateGame();

                foreach (var direction in _directionsList)
                {
                    MoveAsh((int)direction);
                    UpdateGame();
                }

                return TotalPokemons;
            }

            return 0;
        }
    }
}
