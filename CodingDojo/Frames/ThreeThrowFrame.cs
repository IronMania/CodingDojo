using System.Collections.Generic;
using System.Linq;

namespace CodingDojo.Frames
{
    public class ThreeThrowFrame : IUnfinishedFrame
    {
        private readonly List<int> _rolls;

        public ThreeThrowFrame() : this(new List<int>())
        {
        }

        public ThreeThrowFrame(IEnumerable<int> rolls)
        {
            _rolls = rolls.ToList();
        }


        public IEnumerable<int> PinsRolled => _rolls;

        public int Score => PinsRolled.Sum();


        public IFrame AddRoll(int i)
        {
            var sumOfRolls = PinsRolled.Append(i);
            if (_rolls.Count == 1 && _rolls.Sum() + i < 10) return new FinishedThreeThrowFrame(sumOfRolls);
            if (_rolls.Count == 2) return new FinishedStandardFrame(sumOfRolls);
            return new ThreeThrowFrame(sumOfRolls);
        }
    }
}