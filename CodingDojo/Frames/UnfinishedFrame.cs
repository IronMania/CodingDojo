using System.Collections.Generic;
using System.Linq;

namespace CodingDojo.Frames
{
    public class ThreeThrowFrame : IUnfinishedFrame
    {

        public ThreeThrowFrame() : this(new List<int>())
        {
        }
        public ThreeThrowFrame(IEnumerable<int> rolls) 
        {
            Rolls = rolls;
        }


        public IEnumerable<int> Rolls { get; }

        public int TotalPoints => Rolls.Sum();


        public IFrame AddRoll(int i)
        {
            return new ThreeThrowFrame(Rolls.Append(i));
        }
    }
}