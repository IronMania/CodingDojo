using CodingDojo.Frames;
using NUnit.Framework;

namespace CodingDojo
{
    public class GameTests
    {
        [Test]
        public void Game_should_not_be_over()
        {
            var game = new Game();
            Assert.That(game.IsOver, Is.False);
        }

        [Test]
        public void Game_with_One_Roll_Shows_Points()
        {
            var game = new Game();
            game.AddRoll(5);
            Assert.That(game.TotalPoints, Is.EqualTo(5));
        }

        [Test]
        public void Game_with_Two_Roll_Shows_Points()
        {
            var game = new Game();
            game.AddRoll(5);
            game.AddRoll(3);
            Assert.That(game.TotalPoints, Is.EqualTo(8));
        }

        [Test]
        public void Game_One_Roll_Is_Strike()
        {
            var game = new Game();
            game.AddRoll(10);
            Assert.That(game.Frames[0], Is.TypeOf<Strike>());
        }

        [Test]
        public void FrameIsFinishedWithStrike()
        {
            var game = new Game();
            game.AddRoll(10);
            Assert.That(game.Frames[0], Is.TypeOf<Strike>());
        }

        [Test]
        public void AfterStrikeNextFrameIsUsed()
        {
            var game = new Game();
            game.AddRoll(10);
            game.AddRoll(2);
            Assert.That(game.Frames[1].TotalPoints, Is.EqualTo(2));
        }

        [Test]
        public void AfterStrikeInFirstFrameThePointsInSecondFrameForFirstRollAreDoubled()
        {
            var game = new Game();
            game.AddRoll(10);
            game.AddRoll(2);
            Assert.That(game.Frames[0].TotalPoints, Is.EqualTo(12));
        }

        [Test]
        public void TwoRollsAddTopreviousStrike()
        {
            var game = new Game();
            game.AddRoll(10);
            game.AddRoll(2);
            game.AddRoll(2);
            Assert.That(game.Frames[0].TotalPoints, Is.EqualTo(14));
        }

        [Test]
        public void TwoRollsAddTopreviousStrikeOnlyOnce()
        {
            var game = new Game();
            game.AddRoll(10);
            game.AddRoll(2);
            game.AddRoll(2);
            game.AddRoll(2);
            Assert.That(game.Frames[0].TotalPoints, Is.EqualTo(14));
        }

        [Test]
        public void SpareAddsOneTimePoints()
        {
            var game = new Game();
            game.AddRoll(6);
            game.AddRoll(4);
            game.AddRoll(2);
            game.AddRoll(2);
            Assert.That(game.Frames[0].TotalPoints, Is.EqualTo(12));
        }

        [Test]
        public void ThrowingOnlyStrikesGives300Points()
        {
            var game = new Game();
            for (int i = 0; i < 12; i++)
            {
                game.AddRoll(10);
            }
            Assert.That(game.TotalPoints, Is.EqualTo(300));
        }
    }
}