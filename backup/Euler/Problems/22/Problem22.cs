using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems
{
	public class Problem22 : Problem
	{
		public override object Launch()
		{
			string[] listNames = Resource.problem22.Split(',');
			List<char> alphabeticals = new List<char>(new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' });
			IEnumerable<string> listNamesSorted = listNames.OrderBy(p => p);

			Dictionary<string, int> dicoNameScore = new Dictionary<string, int>();
			int i = 0;
			foreach (string sName in listNamesSorted)
			{
				string name = sName.Replace("\"", "");
				int score = 0;
				foreach (char c in name)
				{
					score += alphabeticals.IndexOf(c) + 1;
				}
				score *= ++i;
				dicoNameScore.Add(name, score);
			}
			int t = dicoNameScore.Values.Sum();
			Console.Out.WriteLine("t = {0}", t);
			return t;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
