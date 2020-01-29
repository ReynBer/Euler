using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NUnit.Framework;

namespace Euler.Tests
{
	[TestFixture]
	public class Test
	{
		[Test]
		public void ConversionDateTime()
		{
			string toto = "12/11/2000 11:00:00";
			DateTimeFormatInfo dateTimeFormatInfo = new DateTimeFormatInfo();
			dateTimeFormatInfo.ShortDatePattern = "dd/MM/yyyy hh:mm:ss";
			DateTime totoConvert = DateTime.Parse(toto, dateTimeFormatInfo);
			Assert.IsTrue(totoConvert.Equals(new DateTime(2000, 11, 12, 11, 00, 00)));
		}

		[Test]
		public void ConversionNumeric()
		{
			string toto = "3";
			NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
			numberFormatInfo.NumberDecimalSeparator = ".";
			int totoConvert = int.Parse(toto, numberFormatInfo);
			Assert.IsTrue(totoConvert == 3);
		}

		public void GeneratePandigital(int nmin, int nmax, int n, bool[] choosen, List<string> pandigitals)
		{
			for (int i = nmin; i <= nmax; i++)
			{
				if (!choosen[i])
				{
					choosen[i] = true;
					if (n == nmin)
					{
						pandigitals.Add(i.ToString());
					}
					int r = pandigitals.Count;
					GeneratePandigital(nmin, nmax, n-1, choosen, pandigitals);
					for (int j = r; j < pandigitals.Count; j++)
					{
						pandigitals[j] = pandigitals[j] + i.ToString();
					}
					choosen[i] = false;
				}
			}
		}

		[Test]
		public void GeneratePandigital()
		{
			List<string> pandigitals = new List<string>();
			int nmax = 2;
			int nmin = 1;
			GeneratePandigital(nmin, nmax, nmax, new bool[nmax+1], pandigitals);
			IEnumerable<string> t = new string[2]{"12", "21"};
			Assert.AreEqual(t.Intersect(pandigitals).Count(), pandigitals.Count); 
			nmax++;
			pandigitals = new List<string>();
			GeneratePandigital(nmin, nmax, nmax, new bool[nmax+1], pandigitals);
			t = new string[6]{ "123", "132", "213", "231", "312", "321" };
			Assert.AreEqual(t.Intersect(pandigitals).Count(), pandigitals.Count); 
		}
	}
}
