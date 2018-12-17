using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingDojo.Frames
{
    public class FinishedThreeThrowFrame : IFinishedFrame
    {
        public FinishedThreeThrowFrame(IEnumerable<int> rolls)
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