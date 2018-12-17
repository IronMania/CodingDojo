using System.Collections.Generic;
using System.Linq;
using CodingDojo.Frames;

namespace CodingDojo
{
    public class Game
    {
        private readonly List<IFrame> _frames;

        internal Game(List<IFrame> frames)
        {
            _frames = frames;
        }

        public bool IsOver => Frames.Last() is IFinishedFrame;

        public int TotalScore => Frames.Sum(frame => frame.Score);
        public IReadOnlyList<IFrame> Frames => _frames;

        public static Game CreateStandardGame()
        {
            var frames = new List<IFrame>();
            for (var i = 0; i < 9; i++) frames.Add(new TwoThrowFrame());
            frames.Add(new ThreeThrowFrame());
            return new Game(frames);
        }

        public void AddRoll(int pins)
        {
            var frame = Frames.OfType<IUnfinishedFrame>().First();

            var frames = Frames.Reverse().SkipWhile(frame1 => frame!= frame1).Take(3);
            foreach (var frame1 in frames)
            {
                UpdateFrame(frame1, pins);
            }
        }

        private void UpdateFrame(IFrame frame, int roll)
        {
            var newFrame = frame.AddRoll(roll);
            _frames.Replace(frame, newFrame);
        }

    }
}