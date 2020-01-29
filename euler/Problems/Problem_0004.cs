using Euler.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Problems
{
    public class Problem_0004 : CommandBase<int>
    {
        //private readonly int _digitsCount;
		private readonly int _min;
		private readonly int _max;
		public Problem_0004(int digitsCount)
        {
			_min = (int)Math.Pow(10, digitsCount - 1);
			_max = (int)Math.Pow(10, digitsCount) - 1;
		}

		public override ICommand<int> Run()
        {
			for (int i = _min; i <= _max; i++)
			{
				for (int j = _min; j <= _max; j++)
				{
					int r = i * j;
					if (r.ToString().IsPalyndrom())
						Result = r > Result ? r : Result;
				}
			}
			return this;
        }
    }
}
