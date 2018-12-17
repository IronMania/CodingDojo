using System.Linq;
using CodingDojo.Frames;
using NUnit.Framework;

namespace CodingDojo
{
    public class GameTests
    {
        private Game _game;

        [SetUp]
        public void Setup()
        {
            _game = Game.CreateStandardGame();
        }

        [Test]
        public void Game_should_not_be_over()
        {
            Assert.That(_game.IsOver, Is.False);
        }

        [Test]
        public void Game_with_One_Roll_Shows_Points()
        {
            _game.AddRoll(5);
            Assert.That(_game.TotalScore, Is.EqualTo(5));
        }

        [Test]
        public void Game_with_Two_Roll_Shows_Points()
        {
            _game.AddRoll(5);
            _game.AddRoll(3);
            Assert.That(_game.TotalScore, Is.EqualTo(8));
        }

        [Test]
        public void Game_One_Roll_Is_Strike()
        {
            _game.AddRoll(10);
            Assert.That(_game.Frames[0], Is.TypeOf<Strike>());
        }

        [Test]
        public void FrameIsFinishedWithStrike()
        {
            _game.AddRoll(10);
            Assert.That(_game.Frames[0], Is.TypeOf<Strike>());
        }

        [Test]
        public void AfterStrikeNextFrameIsUsed()
        {
            _game.AddRoll(10);
            _game.AddRoll(2);
            Assert.That(_game.Frames[1].Score, Is.EqualTo(2));
        }

        [Test]
        public void AfterStrikeInFirstFrameThePointsInSecondFrameForFirstRollAreDoubled()
        {
            _game.AddRoll(10);
            _game.AddRoll(2);
            Assert.That(_game.Frames[0].Score, Is.EqualTo(12));
        }

        [Test]
        public void TwoRollsAddTopreviousStrike()
        {
            _game.AddRoll(10);
            _game.AddRoll(2);
            _game.AddRoll(2);
            Assert.That(_game.Frames[0].Score, Is.EqualTo(14));
        }

        [Test]
        public void TwoRollsAddToPreviousStrikeOnlyOnce()
        {
            _game.AddRoll(10);
            _game.AddRoll(2);
            _game.AddRoll(2);
            _game.AddRoll(2);
            Assert.That(_game.Frames[0].Score, Is.EqualTo(14));
        }

        [Test]
        public void SpareAddsOneTimePoints()
        {
            _game.AddRoll(6);
            _game.AddRoll(4);
            _game.AddRoll(2);
            _game.AddRoll(2);
            Assert.That(_game.Frames[0].Score, Is.EqualTo(12));
        }

        [Test]
        public void ThrowingOnlyStrikesGives300Points()
        {
            for (var i = 0; i < 12; i++) _game.AddRoll(10);
            Assert.That(_game.TotalScore, Is.EqualTo(300));
            Assert.That(_game.IsOver, Is.True);
            Assert.That(_game.Frames.Last().PinsRolled.Count(), Is.EqualTo(3));
        }

        [Test]
        public void LastFrameWithNone10FinishesGame()
        {
            for (var i = 0; i < 9; i++) _game.AddRoll(10);
             _game.AddRoll(2);
             _game.AddRoll(2);
            Assert.That(_game.IsOver, Is.True);
            Assert.That(_game.Frames.Last().PinsRolled.Count(), Is.EqualTo(2));
        }
    }
}