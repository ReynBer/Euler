using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems
{
	public class Problem61 : Problem
	{
		public Dictionary<int, List<Digit>> poly4Digits;

		public List<Digit> FindSixCyclics(Digit toFind, IEnumerable<Digit> spaceToSearch, string first2Digits)
		{
			List<Digit> result = null;
			foreach (Digit digit in spaceToSearch.Where(p => p.First2Digits == toFind.Last2Digits))
			{
				IEnumerable<Digit> spaceToSearch2 = spaceToSearch.Except(digit.ListDigitPolygon.Union(digit.ListDigitStepN));
				if (spaceToSearch2.Count() == 0)
				{
					if (digit.Last2Digits == first2Digits)
					{
						result = new List<Digit>();
						result.Add(digit);
						return result;
					}
				}
				else
				{
					result = FindSixCyclics(digit, spaceToSearch2, first2Digits);
					if (result != null)
					{
						result.Add(digit);
						return result;
					}
				}
			}
			return result;
		}

		public override object Launch()
		{
			int nbDigitsMax = 4;
			int nbDigits = 0;
			poly4Digits = new Dictionary<int, List<Digit>>();
			Dictionary<int, List<int>> poly = new Dictionary<int, List<int>>();
			for (int i = 3; i < 9; i++)
			{
				poly4Digits.Add(i, new List<Digit>());
				poly.Add(i, new List<int>());
				poly[i].Add(1);
			}
			List<List<Digit>> listDigitsByStep = new List<List<Digit>>();
			for (int i = 2; nbDigits <= nbDigitsMax; i++)
			{
				List<Digit> listDigit = null;
				int cpt = poly[3][i - 2];
				for (int j = 3; j < 9; j++)
				{
					if (j == 3)
					{
						poly[j].Add(cpt + i);
					}
					else
					{
						poly[j].Add(cpt + poly[j - 1][i - 1]);
					}
					nbDigits = poly[j][i-1].ToString().Count();
					if (nbDigits == nbDigitsMax)
					{
						Digit digit = new Digit(poly[j][i - 1]);
						if (listDigit == null)
							listDigit = new List<Digit>();
						listDigit.Add(digit);
						digit.ListDigitStepN = listDigit;
						poly4Digits[j].Add(digit);
						digit.ListDigitPolygon = poly4Digits[j];
					}
					else
					{
						if (nbDigits > nbDigitsMax)
						{
							j = 9;
							nbDigits = poly[3][i - 1].ToString().Count();
						}
					}
				}
				if (listDigit != null)
				{
					listDigitsByStep.Add(listDigit);
				}
			}

			IEnumerable<Digit> allPoly4Digits = poly4Digits[3];
			for (int j = 4; j < 8; j++)
			{
				allPoly4Digits = allPoly4Digits.Union(poly4Digits[j]);
			}

			foreach (Digit digit in poly4Digits[8])
			{
				List<Digit> results = FindSixCyclics(digit, allPoly4Digits.Except(digit.ListDigitStepN), digit.First2Digits);
				if (results != null && results.Count == 5)
				{
					results.Add(digit);
					int sum = results.Sum(p => p.Value);
					return sum;
				}
			}
			return null;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
