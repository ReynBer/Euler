using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem40 : Problem {
		public override object Launch()
		{
			bool isFinished = false;
			int nbDigits = 1;
			int bornDigitMax = 10;
			int cptDigits = 0;
			int[] b = new int[7];
			b[0] = 1;
			for (int i = 1; i < b.Length; i++)
			{
				b[i] = b[i - 1] * 10;
			}
			int[] d = new int[7];
			int index = 0;
			for (int i = 1;!isFinished;i++)
			{
				if (i == bornDigitMax)
				{
					bornDigitMax *= 10;
					nbDigits++;
				}
				if (cptDigits < b[index] && cptDigits + nbDigits >= b[index])
				{
					bool isFound = false;
					int k = 0;
					for (int j = cptDigits + 1; j <= cptDigits + nbDigits && !isFound; j++)
					{
						if (b[index] == j)
						{
							isFound = true;
							d[index++] = int.Parse(i.ToString().Substring(k, 1));
							isFinished = (index == d.Length);
						}
						else
						{
							k++;
						}
					}
				}
				cptDigits += nbDigits;
			}
			int resultat = 1;
			foreach (int i in d)
			{
				resultat *= i;
			}
			Console.Out.WriteLine("resultat = {0}", resultat);
			return resultat;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
