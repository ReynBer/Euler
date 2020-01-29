using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem14 : Problem{
		public override object Launch()
		{
			DateTime debut = DateTime.Now;
			List<long> l = new List<long>();
			long max = 0;
			long n = 0;
			for (long i = 3; i < 1000000; i++)
			{
				long j = i;

				while (j != 1)
				{
					l.Add(j);
					if (j % 2 == 1)
					{//impair
						j = 3 * j + 1;
					}
					else//pair
					{
						j /= 2;
					}
				}
				if (l.Count > max)
				{
					max = l.Count;
					n = i;
				}
				l.Clear();
			}
			DateTime fin = DateTime.Now;
			Console.Out.WriteLine("max = {0}", max);
			Console.Out.WriteLine("result = {0}", n);
			Console.Out.WriteLine("tps execution = {0}", fin - debut);
			return n;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
