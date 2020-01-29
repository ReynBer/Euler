using Euler.Common;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Problems
{
    public class Problem_0003 : CommandBase<long>
    {
        private readonly long _max;
        public Problem_0003(long max)
        {
            _max = max;
        }

        public override ICommand<long> Run()
        {
			var divisors = new List<long>();
			long max = _max;
			for (long i = 3; i < max; i += 2)
			{
				if (max % i == 0)
				{
					divisors.Add(i);
					divisors.Add(max / i);
					max = divisors[divisors.Count - 1];
				}
			}
			divisors.Sort();
			PrimeLong p = new PrimeLong();
			var primaries = new List<long>();
			foreach (long l in divisors)
			{
				if (p.IsPrime(l))
				{
					primaries.Add(l);
				}
			}
			Result = primaries.Max();
			return this;
        }
    }
}
