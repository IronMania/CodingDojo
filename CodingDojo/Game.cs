using System.Collections.Generic;
using System.Linq;
using CodingDojo.Frames;

namespace CodingDojo
{
    public class Game
    {
        public Game()
        {
            Frames = new List<IFrame>();
            for (var i = 0; i < 9; i++) Frames.Add(new TwoThrowFrame());
            Frames.Add(new ThreeThrowFrame());
        }

        public bool IsOver { get; }
        public int TotalPoints => Frames.Sum(frame => frame.TotalPoints);
        public List<IFrame> Frames { get; }

        public void AddRoll(int i)
        {
            var frame = Frames.OfType<IUnfinishedFrame>().First();

            foreach (var strike in Frames.OfType<Strike>())
            {
                strike.AddRoll(i);
            }
            foreach (var strike in Frames.OfType<Spare>())
            {
                strike.AddRoll(i);
            }
            var newFrame = frame.AddRoll(i);
            Frames.Replace(frame, newFrame);
        }
    }
}