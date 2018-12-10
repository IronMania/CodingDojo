using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace CodingDojo.Frames
{
    public class ThreeThrowFrame : IUnfinishedFrame
    {
        private List<int> _rolls;

        public ThreeThrowFrame() : this(new List<int>())
        {
        }
        public ThreeThrowFrame(IEnumerable<int> rolls) 
        {
            _rolls = rolls.ToList();
        }


        public IEnumerable<int> Rolls => _rolls;

        public int TotalPoints => Rolls.Sum();


        public IFrame AddRoll(int i)
        {
            var sumOfRolls = Rolls.Append(i);
            if (_rolls.Count == 2)
            {
                return new FinishedStandardFrame(sumOfRolls);
            }
            return new ThreeThrowFrame(sumOfRolls);
        }
    }
}