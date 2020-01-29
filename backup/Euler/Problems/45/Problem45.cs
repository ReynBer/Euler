using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem45 : Problem{
		public override object Launch()
		{
			Dictionary<int, List<int>> poly = new Dictionary<int, List<int>>();
			int maxPoly = 6;
			int maxPolyP1 = maxPoly + 1;
			int nTn = 0;
			for (int i = 3; i < maxPolyP1; i++)
			{
				poly.Add(i, new List<int>());
				poly[i].Add(1);
			}
			int resultat = 0;
			bool isFound = false;
			for (int i = 2; !isFound; i++)
			{
				int cpt = poly[3][i - 2];
				for (int j = 3; j < maxPolyP1; j++)
				{
					if (j == 3)
					{
						poly[j].Add(cpt + i);
					}
					else
					{
						poly[j].Add(cpt + poly[j - 1][i - 1]);
						if (j == maxPoly && poly[3][i - 1] > 40755)
						{
							if (poly[5].Contains(poly[3][i - 1]) && poly[6].Contains(poly[3][i - 1]))
							{
								isFound = true;
								resultat = poly[3][i - 1];
								nTn = i;
							}
						}
					}
				}
			}
			Console.Out.WriteLine("resultat = {0}", resultat);
			Console.Out.WriteLine("nTn = {0}", nTn);
			return resultat;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
