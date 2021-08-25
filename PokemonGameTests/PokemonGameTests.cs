using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonCatchThemAll;

namespace PokemonTests
{
    [TestClass]
    public class PokemonTests : PokemonGame
    {
        [TestMethod]
        public void CheckUserInput_InputsExistsInDirection_ReturnTrue()
        {
            var pokemonGame = new PokemonTests();

            var result = pokemonGame.ValidateUserInput("NESW");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckUserInput_InputsDoesNotExistsInDirection_ReturnFalse()
        {
            var pokemonGame = new PokemonTests();

            var result = pokemonGame.ValidateUserInput("SWRE");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckUserInput_EmptyInput_ReturnFalse()
        {
            var pokemonGame = new PokemonTests();

            var result = pokemonGame.ValidateUserInput("");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RunGame_TotalPokemonsReturned_Return4()
        {

            var pokemonGame = new PokemonGame();

            var actualTotalPokemons = pokemonGame.RunGame("NESW");

            int expectedTotalPokemons = 4;
            Assert.AreEqual(expectedTotalPokemons, actualTotalPokemons);
        }

        [TestMethod]
        public void RunGame_TotalPokemonsReturned_Return2()
        {
            var pokemonGame = new PokemonGame();

            var actualTotalPokemons = pokemonGame.RunGame("NSNSNSNSNS");

            int expectedTotalPokemons = 2;
            Assert.AreEqual(expectedTotalPokemons, actualTotalPokemons);
        }

        [TestMethod]
        public void RunGame_TotalPokemonsReturned_Return0()
        {
            var pokemonGame = new PokemonGame();

            var actualTotalPokemons = pokemonGame.RunGame("");

            int expectedTotalPokemons = 0;
            Assert.AreEqual(expectedTotalPokemons, actualTotalPokemons);
        }

        [TestMethod]
        public void MoveAsh_InputSouthMovement_Return1_0()
        {
            var pokemonGame = new PokemonTests();
            var actualLocation = pokemonGame.AshLocation;
            var expectLocation = new Location(1,0);
            pokemonGame.MoveAsh(1);

            Assert.AreEqual(expectLocation.GetLocation(), actualLocation.GetLocation());
        }
    }
}