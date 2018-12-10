using System.Collections.Generic;
using System.Linq;

namespace CodingDojo.Frames
{
    public class Spare : IFinishedFrame
    {
        private readonly List<int> _additionalPoints;
        private readonly int _firstRoll;

        public Spare(int firstRoll) : this(firstRoll, new List<int>())
        {
        }

        private Spare(int firstRoll, List<int> additionalPoints)
        {
            _firstRoll = firstRoll;
            _additionalPoints = additionalPoints;
        }

        public IEnumerable<int> PinsRolled => new[] {_firstRoll, 10 - _firstRoll};
        public int Score => PinsRolled.Sum() + _additionalPoints.Sum();

        public IFrame AddRoll(int i)
        {
            if (_additionalPoints.Count < 1) return new Spare(_firstRoll, _additionalPoints.Append(i).ToList());
            return this;
        }
    }
}