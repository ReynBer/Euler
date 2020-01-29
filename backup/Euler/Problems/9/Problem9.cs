using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem9 : Problem{
		public override object Launch()
		{
			int result = 0;
			for (int a = 1; a < 1000 & result == 0; a++)
			{
				double a_carre = Math.Pow(a, 2);
				for (int b = a + 1; b < 1000 - a && result == 0; b++)
				{
					double b_carre = Math.Pow(b, 2);
					int c = 1000 - a - b;
					double c_carre = Math.Pow(c, 2);
					if (c_carre == a_carre + b_carre)
					{
						result = a * b * c;
					}
				}
			}
			Console.Out.WriteLine("result = {0}", result);
			return result;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
