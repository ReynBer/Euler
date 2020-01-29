using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem62 : Problem
	{
		public override object Launch()
		{
			Console.WriteLine(DateTime.Now);
			NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
			numberFormatInfo.NumberDecimalDigits = 0;
			double min = 5;
			int nbDigits = 0;
			int nbDigitsCurrent = 0;
			int nbPermutations = 5;
			
			List<string> powers3 = new List<string>();
			bool isFound = false;
			while (!isFound)
			{
				bool isFirst = true;
				for (double i = min; nbDigitsCurrent == nbDigits; i++)
				{
					string power3 = Math.Pow(i, 3).ToString(numberFormatInfo);
					if (isFirst)
					{
						nbDigits = power3.Count();
						isFirst = false;
					}
					nbDigitsCurrent = power3.Count();
					if (nbDigitsCurrent > nbDigits)
					{
						min = i;
					}
					else
					{
						powers3.Add(power3);
					}
				}
				//Console.Out.WriteLine("nbDigits = {0}", nbDigits);
				for (int i = 0; i < powers3.Count && !isFound; i++)
				{
					string power3 = powers3[i];
					List<string> indexexesIntersect = new List<string>();
					indexexesIntersect.Add(power3);
					IEnumerable<char> power3Sorted = power3.OrderBy(c => c);
					for (int j = i + 1; j < powers3.Count; j++)
					{
						IEnumerable<char> power3jSorted = powers3[j].OrderBy(c => c);
						bool isMatched = true;
						for (int k = 0; k < nbDigits&& isMatched; k++)
						{
							isMatched = (power3Sorted.ElementAt(k) == power3jSorted.ElementAt(k));
						}
						if (isMatched)
						{
							indexexesIntersect.Add(powers3[j]);
						}
					}
					if (indexexesIntersect.Count == nbPermutations)
					{
						Console.Out.WriteLine("Result = {0}", indexexesIntersect[0]);
						Console.WriteLine(DateTime.Now);
						return indexexesIntersect[0];
					}
					foreach (string intersect in indexexesIntersect)
					{
						powers3.Remove(intersect);
					}
					i = -1;
				}
				nbDigits = nbDigitsCurrent;
				powers3.Clear();
			}
			Console.WriteLine(DateTime.Now);
			return "";
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
