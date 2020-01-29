using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem25 : Problem {
		public override object Launch()
		{
			BigInt fnm1 = new BigInt(1);
			BigInt fn = new BigInt(1);
			BigInt fnp1 = fn + fnm1;
			fnm1 = fn;
			fn = fnp1;
			int count = 3;
			while (fnp1.Value.Length != 1000)
			{
				count++;
				fnp1 = fn + fnm1;
				fnm1 = fn;
				fn = fnp1;

			}
			Console.Out.WriteLine("resultat = {0}", count);
			return count;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
