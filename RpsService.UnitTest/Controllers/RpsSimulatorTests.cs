using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rps = RPSService.Controllers.RpsSimulatorController.RockPaperScissors;

namespace RpsService.UnitTest.Controllers
{
    [TestClass]
    public class RpsSimulatorTests
    {
        [TestMethod]
        public void GetReturnsValidActionResult()
        {
            var simulator = new RPSService.Controllers.RpsSimulatorController();

            var result = simulator.Get();
            Assert.IsTrue((result.Value <= Rps.Scissors), "Invalid result from simulator (too hot)");
            Assert.IsTrue((result.Value >= Rps.Rock), "Invalid result from simulator (too cold)");
        }
        
        [TestMethod]
        public void GetWithSeedReturnsExpectedActionResult()
        {
            var simulator = new RPSService.Controllers.RpsSimulatorController();

            var result = simulator.Get(1);
            Assert.AreEqual(Rps.Rock, result.Value, "Incorrect results based on seed");

            result = simulator.Get(2);
            Assert.AreEqual(Rps.Scissors, result.Value, "Incorrect results based on seed");

            result = simulator.Get(5);
            Assert.AreEqual(Rps.Paper, result.Value, "Incorrect results based on seed");
        }

        [TestMethod]
        public void GetCompeteWithTieReturnsExpectedActionResult()
        {
            var simulator = new RPSService.Controllers.RpsSimulatorController();

            var result = simulator.Get(Rps.Rock, Rps.Rock);
            Assert.AreEqual(0, result.Value, "Tie wasn't correctly calculated");

            result = simulator.Get(Rps.Scissors, Rps.Scissors);
            Assert.AreEqual(0, result.Value, "Tie wasn't correctly calculated");

            result = simulator.Get(Rps.Paper, Rps.Paper);
            Assert.AreEqual(0, result.Value, "Tie wasn't correctly calculated");
        }

        [TestMethod]
        public void GetPlayer1WinsReturnsExpectedActionResult()
        {
            var simulator = new RPSService.Controllers.RpsSimulatorController();

            var result = simulator.Get(Rps.Rock, Rps.Scissors);
            Assert.AreEqual(1, result.Value, "Player 1 was supposed to win");

            result = simulator.Get(Rps.Scissors, Rps.Paper);
            Assert.AreEqual(1, result.Value, "Player 1 was supposed to win");

            result = simulator.Get(Rps.Paper, Rps.Rock);
            Assert.AreEqual(1, result.Value, "Player 1 was supposed to win");
        }

        [TestMethod]
        public void GetPlayer2WinsReturnsExpectedActionResult()
        {
            var simulator = new RPSService.Controllers.RpsSimulatorController();

            var result = simulator.Get(Rps.Rock, Rps.Paper);
            Assert.AreEqual(2, result.Value, "Player 2 was supposed to win");

            result = simulator.Get(Rps.Scissors, Rps.Rock);
            Assert.AreEqual(2, result.Value, "Player 2 was supposed to win");

            result = simulator.Get(Rps.Paper, Rps.Scissors);
            Assert.AreEqual(2, result.Value, "Player 2 was supposed to win");
        }
    }
}
