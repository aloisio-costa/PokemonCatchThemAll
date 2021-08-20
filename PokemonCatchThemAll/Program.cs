using System;
using System.Linq;
using System.Collections.Generic;

namespace Pokemon_apanha_los_todos
{
    public enum Directions
    {
        North,
        South,
        West,
        East
    }

    class Game
    {
        private int[,] _pokemonWorld;
        private List<Directions> _directionList;
        private Dictionary<Directions, Action> _movement;

        //replace 
        int totalPokemons = 0;
        int ashPositionX = new Random().Next(0, 49); //Change me
        int ashPositionY = new Random().Next(0, 69); //Change me

        public Game(int x, int y)
        {
            _pokemonWorld = new int[x, y];
            //fill pokemon world with pokemons
            for (int i = 0; i < x * y; i++) _pokemonWorld[i % x, i / y] = 1;
        }

        public bool CheckUserInput(string userInput)
        {
            _directionList = new List<Directions>();
            List<string> inputList;

            inputList = userInput.ToLower().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            for (int i = 0; i < inputList.Count; i++)
            {
                try
                {
                    _directionList.Add((Directions)Enum.Parse(typeof(Directions), inputList[i], true));
                }
                catch
                {
                    Console.WriteLine($"\"{userInput[i]}\" Invalid Directions.");
                    return false;
                }
            }

            return true;
        }

        void executeMovement(int positionInput)
        {
            var limite = positionInput % 2 == 0 ? 0 : _pokemonWorld.GetLength(positionInput / 2);

            var position = positionInput < 2 ? ashPositionX : ashPositionY;

            if (position != limite)
            {
                switch (positionInput)
                {
                    case 0:
                        {
                            position -= 1;
                            ashPositionX = position;
                            break;
                        }
                    case 1:
                        {
                            position += 1;
                            ashPositionX = position;
                            break;
                        }
                    case 2:
                        {
                            position -= 1;
                            ashPositionY = position;
                            break;
                        }
                    case 3:
                        {
                            position += 1;
                            ashPositionY = position;
                            break;
                        }

                    default:
                        return;
                }
            }

            if (_pokemonWorld[ashPositionX, ashPositionY] == 1)
            {
                totalPokemons++;
                _pokemonWorld[ashPositionX, ashPositionY] = 0;
            }

        }

        public int MoveAsh()
        {
            _movement = new Dictionary<Directions, Action>()
            {
                {Directions.North, ()=> executeMovement((int)Directions.North) },
                {Directions.South, ()=> executeMovement((int)Directions.South) },
                {Directions.West, ()=> executeMovement((int)Directions.West) },
                {Directions.East, ()=> executeMovement((int)Directions.East) }
            };

            //foreach (var direction in _directionList)
            //{

            //}


            return totalPokemons;
        }

        public void runGame(string userInput)
        {
            if (!CheckUserInput(userInput))
            {
                Console.WriteLine("Invalid Directions!");
                return;
            }

            MoveAsh();
        }

        public void test()
        {
            //for (int i = 0; i < _pokemonWorld.GetLength(0); i++)
            //{
            //    for (int y = 0; y < _pokemonWorld.GetLength(1); y++)
            //        Console.WriteLine(i + " " + _pokemonWorld[i, y]);

            //}
            Console.WriteLine("size " + _pokemonWorld.GetLength(1));
            MoveAsh();

            Console.WriteLine("initial positionX " + ashPositionX);
            Console.WriteLine("initial positionY " + ashPositionY);
            _movement[Directions.East]();
            Console.WriteLine("after movement positionX " + ashPositionX);
            Console.WriteLine("after movement positionY " + ashPositionY);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var pokemon = new Game(50, 70);
            pokemon.test();
        }
    }
}
