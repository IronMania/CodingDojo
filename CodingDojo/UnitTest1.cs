using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CodingDojo
{
    public class Game
    {
        private Frame _lastFrame;
        public bool IsOver {get;}
        public int TotalPoints { get; private set; }
        public List<Frame> Frames {get;}

        public Game()
        {
            Frames = new List<Frame>();
            for (int i = 0; i < 10; i++)
            {
                Frames.Add(new Frame(0));
            }
        }
        public void AddRoll(int i)
        {
            Frame frame = Frames.First(frame1 => !frame1.IsFinished);

            frame.AddRoll(i);
            if (_lastFrame?.IsStrike == true)
            {
                _lastFrame.AddRoll(i);
            }

            TotalPoints += i;
            _lastFrame = frame;
        }
    }

    public class Frame {
        public int TotalPoints {get; private set;}
        private int _rollCount = 0;
        public bool IsStrike {get {
            return TotalPoints == 10;
        }}

        public bool IsFinished
        {
            get { return _rollCount == 2 || IsStrike; }
        }

        public Frame(int i)
        {
            TotalPoints = i;
        }

        public void AddRoll(int i) {
            TotalPoints += i;

            _rollCount++;
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

        [Test]
        public void FrameIsFinished()
        {
            var game = new Game();
            game.AddRoll(5);
            game.AddRoll(3);
            Assert.That(game.Frames[0].IsFinished, Is.True);
        }

        [Test]
        public void FrameIsFinishedWithStrike()
        {
            var game = new Game();
            game.AddRoll(10);
            Assert.That(game.Frames[0].IsFinished, Is.True);
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

    }
}