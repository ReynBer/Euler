using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems
{
	public class Problem36 :Problem 
	{
		public static string String(IEnumerable<char> enumerable)
		{
			string s = "";
			foreach (char c in enumerable)
			{
				s += c;
			}
			return s;
		}

		public static bool IsPalyndrom(string s)
		{
			return s == String(s.Reverse());
		}
		public override object Launch()
		{
			//if (this.IsPalyndrom("NON")) Console.Out.WriteLine("Non est un palyndrome");
			//if (this.IsPalyndrom("OUI")) Console.Out.WriteLine("Oui est un palyndrome");
			//Dictionary<int, Binary> dico = new Dictionary<int, Binary>();
			List<int> palyndromicsValues = new List<int>();
			Binary b = new Binary();
			for (int i = 0; i < 1000000; i++)
			{
				//Console.Out.WriteLine("b = {0}", b);
				if (IsPalyndrom(b.ToString()) && IsPalyndrom(i.ToString()))
				{
					palyndromicsValues.Add(i);
				}
				//dico.Add(i, b++);
				b++;
			}
			int sum = palyndromicsValues.Sum();
			Console.Out.WriteLine("sum = {0}", sum);
			return null;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
