using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems
{
	public class Problem33 :Problem
	{
		private class Fraction
		{
			public int Numerator {get; set;}
			public int Denominator { get; set; }

			public Fraction(int numerator, int denominator)
			{
				Numerator = numerator;
				Denominator = denominator;
			}
		}

		public override object Launch()
		{
			List<Fraction> list = new List<Fraction>();
			for (int n = 1; n < 10; n++)
			{
				for (int d = n+1; d < 10; d++)
				{
					for (int i = 1; i < 10; i++)
					{
						int n1 = int.Parse(n.ToString() + i.ToString());
						int d2 = int.Parse(i.ToString() + d.ToString());
						if (n * d2 == d * n1)
						{
							list.Add(new Fraction(n, d));
						}
					}
				}
			}
			int productDenominator = 1;
			int productNumerator = 1;
			foreach (Fraction fraction in list)
			{
				if (fraction.Denominator % fraction.Numerator == 0)
				{
					fraction.Denominator /= fraction.Numerator;
					fraction.Numerator = 1;
				}
				productDenominator *= fraction.Denominator;
				productNumerator *= fraction.Numerator;
			}
			if (productDenominator % productNumerator == 0)
			{
				productDenominator /= productNumerator;
				productNumerator = 1;
			}
			Console.Out.WriteLine("productDenominator = {0}", productDenominator);
			return productDenominator;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
