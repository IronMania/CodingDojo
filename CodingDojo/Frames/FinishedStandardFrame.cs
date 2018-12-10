using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingDojo.Frames
{
    public class FinishedStandardFrame : IFinishedFrame
    {
        public FinishedStandardFrame(IEnumerable<int> rolls)
        {
            Rolls = rolls;
        }

        public IEnumerable<int> Rolls { get; }
        public int TotalPoints => Rolls.Sum();

        public IFrame AddRoll(int i)
        {
            throw new InvalidOperationException();
        }
    }
}