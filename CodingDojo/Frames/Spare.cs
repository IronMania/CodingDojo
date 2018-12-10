using System.Collections.Generic;
using System.Linq;

namespace CodingDojo.Frames
{
    public class Spare : IFinishedFrame
    {
        private readonly List<int> _additionalPoints = new List<int>(1);
        private readonly int _firstRoll;

        public Spare(int firstRoll)
        {
            _firstRoll = firstRoll;
        }

        public IEnumerable<int> Rolls => new[] {_firstRoll, 10 - _firstRoll};
        public int TotalPoints => Rolls.Sum() + _additionalPoints.Sum();

        public IFrame AddRoll(int i)
        {
            if (_additionalPoints.Count < 1) _additionalPoints.Add(i);
            return this;
        }
    }
}