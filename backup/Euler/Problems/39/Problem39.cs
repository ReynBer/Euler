using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem39 : Problem{
		public class Triplet
		{
			public int A { get; set; }
			public int B { get; set; }
			public int C { get; set; }
			public Triplet(int a, int b, int c)
			{
				A = a;
				B = b;
				C = c;
			}
		}

		public override object Launch()
		{
			Dictionary<int, List<Triplet>> dictionary = new Dictionary<int, List<Triplet>>();
			int[] squares = new int[1000];
			squares[0] = 1;
			for (int i = 1; i < squares.Length; i++)
			{
				squares[i] = i * i;
			}
			int pMax = 0;
			int numberPMax = 0;
			for (int a = 1;a < 1000; a++)
			{
				for (int b = a;b < 1000; b++)
				{
					bool isStopC = false;
					for (int c = b + 1;c < 1000 && !isStopC; c++)
					{
						int p = a + b + c;
						if (p <= 1000)
						{
							if (squares[a] + squares[b] == squares[c])
							{
								if (!dictionary.ContainsKey(p))
								{
									dictionary.Add(p, new List<Triplet>());
								}
								dictionary[p].Add(new Triplet(a, b, c));
								if (numberPMax < dictionary[p].Count)
								{
									numberPMax = dictionary[p].Count;
									pMax = p;
								}
							}
							if (squares[a] + squares[b] < squares[c])
							{
								isStopC = true;
							}
						}
						else
						{
							isStopC = true;
						}
					}
				}
			}
			Console.Out.WriteLine("pMax = {0}", pMax);
			return pMax;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
