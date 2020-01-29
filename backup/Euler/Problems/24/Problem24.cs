using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems
{

	public class Problem24 : Problem
	{
		public static int Factoriel(int n)
		{
			int j = n;
			int fact = 1;
			while (j != 0)
			{
				fact *= j;
				j--;
			}
			return fact;
		}

		public override object Launch()
		{
			List<char> lettreRestante = new List<char>(new char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
			int init = 1000000;
			int n = 9;
			int fact = Factoriel(n--);
			string result = "";
			while (init != 0)
			{
				for (int i = 0; i < lettreRestante.Count; i++)
				{
					init -= fact;
					if (init <= 0)
					{
						init += fact;
						char s = lettreRestante.ElementAt(i);
						result += s.ToString();
						lettreRestante.Remove(s);
						i = -1;
						if (lettreRestante.Count > 0)
						{
							fact = Factoriel(n--);
						}
						else
						{
							init = 0;
						}
					}
				}
			}
			Console.Out.WriteLine("result = {0}", result);
			return null;
			//throw new NotImplementedException();
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
