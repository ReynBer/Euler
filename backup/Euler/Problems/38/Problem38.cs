using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem38 : Problem {
		private char[] through = new char[9];

		public bool IsPandigital(IEnumerable<char> through, int sizeThrough, string s)
		{
			return (s.Intersect(through).Count() == sizeThrough);
		}

		private int[] maxArrayPandigital = new int[9];
		private int maxPandigital = 0;
		public int MaxPandigital
		{
			get { return maxPandigital; }
			set
			{
				maxPandigital = value;
				int j = 0;
				foreach (char t in maxPandigital.ToString())
				{
					maxArrayPandigital[j++] = int.Parse(t.ToString());
				}
			}
		}

		public int String2Int(string s)
		{
			int n = 1;
			int p = 0;
			foreach (char c in s.Reverse())
			{
				p += int.Parse(c.ToString()) * n;
				n *= 10;
			}
			return p;
		}

		public bool IsConcatenatingPandigital(int i)
		{
			int nbDigits = i.ToString().Length;
			string pandigital = i.ToString();
			bool isPotentialPandigital = IsPandigital(through, nbDigits, pandigital);
			for (int j = 2; nbDigits < 9 && isPotentialPandigital; j++)
			{
				pandigital += (j * i).ToString();
				nbDigits = pandigital.Length;
				isPotentialPandigital = IsPandigital(through, nbDigits, pandigital);
			}
			if (isPotentialPandigital && IsPandigital(through, through.Length, pandigital))
			{
				int p = String2Int(pandigital);
				if (p > maxPandigital)
				{
					MaxPandigital = p;
				}
				return true;
			}
			return false;
		}

		public override object Launch()
		{
			//int[] puissances = new int[10];
			//puissances[0] = 1;
			for (int i = 1; i < 10; i++)
			{
				through[i - 1] = i.ToString()[0];
				//puissances[i] = 10 * puissances[i-1]; 
			}
			int[] valueLevel = new int[4];
			List<int> list = new List<int>(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9});
			int level = 0;
			valueLevel[level] = 0;
			for (int i = 9; i > 0 && maxArrayPandigital[level] < i; i--)
			{
				list.Remove(i);
				int t = i;
				IsConcatenatingPandigital(t);
				level++;
				valueLevel[level] = t * 10;
				for (int j = 9; j > 0; j--)
				{
					t = valueLevel[level];
					if (list.Contains(j))
					{
						list.Remove(j);
						t += j;
						IsConcatenatingPandigital(t);
						level++;
						valueLevel[level] = t * 10;
						for (int k = 9; k > 0; k--)
						{
							t = valueLevel[level];
							if (list.Contains(k))
							{
								list.Remove(k);
								t += k;
								IsConcatenatingPandigital(t);
								level++;
								valueLevel[level] = t * 10;
								for (int l = 9; l > 0; l--)
								{
									t = valueLevel[level];
									if (list.Contains(l))
									{
										t += l;
										IsConcatenatingPandigital(t);
									}
								}
								level--;
								list.Add(k);
							}
						}
						level--;
						list.Add(j);
					}
				}
				level--;
				list.Add(i);
			}
			Console.Out.WriteLine("maxPandigital = {0}", maxPandigital);
			return maxPandigital;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
