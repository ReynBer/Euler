using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems{
	public class Problem20 :Problem {
		public override object Launch()
		{
			BigInt j = new BigInt(1);
			for (int i = 100; i >= 2; i--)
			{
				j *= new BigInt(i);
			}
			int result = j.ListValue.Sum();
			Console.Out.WriteLine("result = {0}", result);
			return result;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
