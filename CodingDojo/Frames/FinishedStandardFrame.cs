using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingDojo.Frames
{
    public class FinishedStandardFrame : IFinishedFrame
    {
        public FinishedStandardFrame(IEnumerable<int> rolls)
        {
            PinsRolled = rolls;
        }

        public IEnumerable<int> PinsRolled { get; }
        public int Score => PinsRolled.Sum();

        public IFrame AddRoll(int i)
        {
            return this;
        }
    }
}