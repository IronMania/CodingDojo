using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingDojo.Frames
{
    public class Strike : IFinishedFrame
    {
        private readonly List<int> _additionalPoints = new List<int>(2);
        public Strike()
        {
        }

        public IEnumerable<int> Rolls => new int[]{10};
        public int TotalPoints => Rolls.Sum() + _additionalPoints.Sum();

        public IFrame AddRoll(int i)
        {
            if (_additionalPoints.Count < 2)
            {
                _additionalPoints.Add(i);
            }
            return this;
        }
    }
}