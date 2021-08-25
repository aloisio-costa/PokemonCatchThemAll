using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonCatchThemAll;

namespace LocationTests
{
    [TestClass]
    public class LocationTests 
    {
        [TestMethod]
        public void GetLocation_LocationInputSSSS_ReturnLocation4_0()
        {
            var pokemonGame = new PokemonGame();
            pokemonGame.RunGame("SSSS");

            var actualLocation = pokemonGame.AshLocation;

            var expectLocation = new Location(4, 0);

            Assert.AreEqual(expectLocation.GetLocation(), actualLocation.GetLocation());
        }

        [TestMethod]
        public void Equals_LocationsInputE_ReturnLocation0_1()
        {
            var pokemonGame = new PokemonGame();
            pokemonGame.RunGame("E");

            var actualLocation = pokemonGame.AshLocation;

            var expectLocation = new Location(0, 1);

            Assert.AreEqual(expectLocation.GetLocation(), actualLocation.GetLocation());
        }
    }
}
