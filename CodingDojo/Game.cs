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

        public int TotalPoints => Frames.Sum(frame => frame.TotalPoints);
        public IReadOnlyList<IFrame> Frames => _frames;

        public static Game CreateStandardGame()
        {
            var frames = new List<IFrame>();
            for (var i = 0; i < 9; i++) frames.Add(new TwoThrowFrame());
            frames.Add(new ThreeThrowFrame());
            return new Game(frames);
        }

        public void AddRoll(int i)
        {
            var frame = Frames.OfType<IUnfinishedFrame>().First();

            foreach (var strike in Frames.OfType<Strike>()) strike.AddRoll(i);
            foreach (var strike in Frames.OfType<Spare>()) strike.AddRoll(i);
            var newFrame = frame.AddRoll(i);
            _frames.Replace(frame, newFrame);
        }
    }
}