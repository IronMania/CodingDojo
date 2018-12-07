using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CodingDojo
{
    public class Game
    {
        public bool IsOver {get;}
        public int TotalPoints { get; private set; }
        public List<Frame> Frames {get;} = new List<Frame>();

        public void AddRoll(int i)
        {
            Frame frame = Frames.LastOrDefault();
            if (frame == null)
            {
                frame = new Frame(0);
                Frames.Add(frame);
            }
            

            frame.AddRoll(i);

            TotalPoints += i;

        }

        public void AddFrame(int i) {
            Frames.Add(new Frame(i));
        }
    }

    public class Frame {
        public int TotalPoints {get; private set;}
        public bool IsStrike {get {
            return TotalPoints == 10;
        }}

        public Frame(int i)
        {
            TotalPoints = i;
        }

        public void AddRoll(int i) {
            TotalPoints += i;
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
            Assert.That(game.Frames[0].IsStrike, Is.True);
        }
    }
}