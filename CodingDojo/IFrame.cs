using System.Collections.Generic;

namespace CodingDojo
{
    public interface IFrame
    {
        IEnumerable<int> PinsRolled { get; }
        int Score { get; }
        IFrame AddRoll(int number);
    }
}