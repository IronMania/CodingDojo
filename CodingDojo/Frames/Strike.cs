using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingDojo.Frames
{
    public class Strike : IFinishedFrame
    {
        private readonly List<int> _additionalPoints ;
        public Strike()
        {
            _additionalPoints = new List<int>();
        }

        private Strike(List<int> additionalPoints)
        {
            _additionalPoints = additionalPoints.ToList();
        }
        public IEnumerable<int> PinsRolled => new int[]{10};
        public int Score => PinsRolled.Sum() + _additionalPoints.Sum();

        public IFrame AddRoll(int i)
        {
            if (_additionalPoints.Count < 2)
            {
                return new Strike(_additionalPoints.Append(i).ToList());
            }
                
            return this;
        }
    }
}