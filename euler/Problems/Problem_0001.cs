using Euler.Common;
using System.Linq;

namespace Euler.Problems
{
    public class Problem_0001 : CommandBase<int>
    {
        private readonly int _max;
        public Problem_0001(int max)
        {
            _max = max;
        }

        public override ICommand<int> Run()
        {
            Result = Enumerable.Range(1, _max).Where(v => v % 3 == 0 || v % 5 == 0).Sum();
            return this;
        }
    }
}
