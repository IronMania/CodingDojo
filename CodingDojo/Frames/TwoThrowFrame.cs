using System.Collections.Generic;
using System.Linq;

namespace CodingDojo.Frames
{
    public class TwoThrowFrame : IUnfinishedFrame
    {
        public IEnumerable<int> Rolls => new int[2];
        public int TotalPoints => Rolls.Sum();


        public IFrame AddRoll(int i)
        {
            if (i == 10)
            {
                return new Strike();
            }
            return new OneThrowFrame(i);
        }
    }
}