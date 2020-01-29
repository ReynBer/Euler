using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem48 : Problem
	{
		public override object Launch()
		{
			/*BigInt n = new BigInt(1);
			for (int i = 2; i < 100; i++)
			{
				BigInt n2 = new BigInt(i);
				n = n.Multiply(n2);
			}

			BigInt f1 = new BigInt(1);
			BigInt f2 = new BigInt(1);
			BigInt ftemp = new BigInt(0);
			long k = 2;
			while (ftemp.Value.Length < 1000)
			{
				ftemp = f1.Add(f2);
				f1.SetValue(f2);
				f2.SetValue(ftemp);
				k++;
			}*/
			BigInt fin = new BigInt(0);
			for (int i = 1; i <= 1000; i++)
			{
				BigInt p = new BigInt(i);
				BigInt t = new BigInt(i);
				for (int j = 1; j < i; j++)
				{
					t = t.Multiply(p);
					if (t.Value.Length > 10)
					{
						t.SetValue(new BigInt(t.Value.Substring(t.Value.Length - 10)));
						if (t.Value == "0000000000")
						{
							j = i;
						}
					}
				}
				fin = fin.Add(t);
			}
			Console.Out.WriteLine("fin = {0}", fin.Value.Substring(fin.Value.Length - 10));
			return null;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
