using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem27 : Problem
	{
		public override object Launch()
		{
			int[] squares = new int[1000];
			for (int i = 0; i < squares.Length; i++)
			{
				squares[i] = i * i;
			}
			int maxSuccessif = 40;
			int aSave = 1;
			int bSave = 41;
			PrimaryGenerator pr = new PrimaryGenerator();
			pr.Get(100000);
			for (int a = -999; a < 1000; a++)
			{
				for (int b = -999; b < 1000; b++)
				{
					bool isPrimary = true;
					int cpt = 0;
					for (int n = 0; n < squares.Length && isPrimary; n++)
					{
						int p = squares[n] + a * n + b;
						if (p > 0 && pr.IsPrimary(p))
						{
							cpt++;
						}
						else
						{
							isPrimary = false;
						}
					}
					if (cpt > maxSuccessif)
					{
						maxSuccessif = cpt;
						aSave = a;
						bSave = b;
					}
				}
			}
			int product = aSave * bSave;
			Console.Out.WriteLine("product = {0}", product);
			return product;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
