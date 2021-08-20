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
        private List<Directions> _pathList;
        private List<Location> _visitedLocations;
        private int _totalPokemons;
        public Location AshLocation { get; private set; }

        public PokemonGame()
        {
            _visitedLocations = new List<Location>();
            _totalPokemons = 0;
            AshLocation = new Location(0, 0);
        }

        public bool CheckUserInput(string userInput)
        {
            _pathList = new List<Directions>();

            //Sort user input
            List<string> userInputToList = userInput.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string userInputToString = String.Join("", userInputToList);

            //Add it to direction list
            foreach (var c in userInputToString.ToUpper())
            {
                try
                {
                    _pathList.Add((Directions)Enum.Parse(typeof(Directions), c.ToString(), true));
                }
                catch
                {
                    Console.WriteLine($"\"{c}\" Invalid Path.");
                    return false;
                }
            }

            return true;
        }

        void MoveAsh(int direction)
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
                _totalPokemons++;
            }
        }

        public void RunGame(string userInput)
        {
            if (CheckUserInput(userInput))
            {
                UpdateGame();

                foreach (var direction in _pathList)
                {
                    MoveAsh((int)direction);
                    UpdateGame();
                }

                Console.WriteLine($"You did catch {_totalPokemons} pokemons!!");
            }
        }
    }
}
