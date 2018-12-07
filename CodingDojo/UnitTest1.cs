using NUnit.Framework;

namespace CodingDojo
{
    public class Game
    {
        public bool IsOver {get;}
        public int TotalPoints { get; private set; }

        public void AddRoll(int i)
        {
            TotalPoints = i;
        }
    }


    public class Tests
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


    }
}