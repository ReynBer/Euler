using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems
{
	public class Problem3 : Problem
	{
		public override object Launch()
		{
			List<long> diviseurs = new List<long>();
			long max = 600851475143;
			for (long i = 3; i < max; i+=2)
			{
				if (max % i == 0)
				{
					diviseurs.Add(i);
					diviseurs.Add(max / i);
					max = diviseurs[diviseurs.Count - 1];
				}
			}
			diviseurs.Sort();
			PrimeLong p = new PrimeLong();
			List<long> primaries = new List<long>();
			foreach (long l in diviseurs)
			{
				if (p.IsPrime(l))
				{
					primaries.Add(l);
				}
			}
			long result = primaries.Max();
			Console.Out.WriteLine("result = {0}", result);
			return result;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
