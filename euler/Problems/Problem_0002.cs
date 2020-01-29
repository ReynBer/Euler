using Euler.Common;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Problems
{
    public class Problem_0002 : CommandBase<long>
    {
        private readonly long _max;
        public Problem_0002(long max)
        {
            _max = max;
        }

        public IEnumerable<long> Fib(long fn_2, long fn_1, long max)
        {
            yield return fn_2;
            foreach (var f in Fib(fn_1, fn_2 + fn_1, max))
            {
                if (f >= max)
                    break;
                else
                    yield return f;
            }
        }

        public override ICommand<long> Run()
        {
            Result = Fib(1L, 2L, _max).Where(v => v % 2L == 0L).Sum();
            //var Fib = new List<long>();
            //Fib.Add(1L);
            //Fib.Add(2L);
            //int index = 1;
            //while (Fib[index] < _max)
            //{
            //    Fib.Add(Fib[index] + Fib[index - 1]);
            //    index++;
            //}
            //Result = Fib.Where(p => p % 2 == 0).Sum();
            return this;
        }
    }
}
