using System.Collections.Generic;
using System.Linq;

namespace CodingDojo.Frames
{
    public class OneThrowFrame : IUnfinishedFrame
    {
        private readonly int _roll;

        public OneThrowFrame(int roll)
        {
            _roll = roll;
        }

        public IEnumerable<int> PinsRolled => new[] {_roll};

        public int Score => PinsRolled.Sum();

        public IFrame AddRoll(int i)
        {
            if (i + _roll == 10)
            {
                return new Spare(_roll);
            }
            return new FinishedStandardFrame(new []{_roll, i});
        }
    }
}