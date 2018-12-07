using NUnit.Framework;

namespace CodingDojo
{
    public class Game
    {
        public bool IsOver {get;}
    }


    public class Tests
    {
        [Test]
        public void Game_should_not_be_over()
        {
            var game = new Game();
            Assert.That(game.IsOver, Is.False);
        }
    }
}