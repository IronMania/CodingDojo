using System.Collections.Generic;

namespace CodingDojo
{
    public interface IFrame
    {
        IEnumerable<int> Rolls { get; }
        int TotalPoints { get; }
        IFrame AddRoll(int number);
    }

    public interface IFinishedFrame : IFrame
    {
    }
    public interface IUnfinishedFrame : IFrame
    {
    }
}