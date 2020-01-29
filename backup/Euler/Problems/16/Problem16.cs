using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem16 : Problem{
		public override object Launch()
		{
			string result = "";
			string temp = "1";
			bool dizaine = false;
			for (int i = 0; i <= 1000; i++)
			{
				result = temp;
				temp = "";
				for (int j = result.Length - 1; j >= 0; j--)
				{
					int t = int.Parse(result[j].ToString()) * 2;
					if (dizaine)
					{
						t++;
					}
					if (t > 9)
					{
						t -= 10;
						dizaine = true;
					}
					else
					{
						dizaine = false;
					}
					temp = t.ToString() + temp;
				}
				if (dizaine)
				{
					temp = "1" + temp;
					dizaine = false;
				}
			}
			int r = result.Sum(p => int.Parse(p.ToString()));
			Console.Out.WriteLine("r = {0}", r);
			return r;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
