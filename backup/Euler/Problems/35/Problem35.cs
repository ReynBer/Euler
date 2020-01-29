using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem35 : Problem {

		public string Rotate(string s)
		{
			string result = "";
			char? cFirst = null;
			foreach (char c in s)
			{
				if (cFirst == null)
				{
					cFirst = c;
				}
				else
				{
					result += c;
				}
			}
			return result + cFirst;
		}

		public override object Launch()
		{
			PrimeInt p = new PrimeInt();
			p.GetPrime(1000000);
			List<int> primes = p.Primes;
			List<int> okNumbers = new List<int>();
			for (int i = 0; i < primes.Count; i++)
			{
				if (!okNumbers.Contains(primes[i]))
				{
					string s1 = primes[i].ToString();
					if (!(s1.Contains("0") || s1.Contains("2") || s1.Contains("4") || s1.Contains("6") || s1.Contains("8")))
					{
						List<string> listRotate = new List<string>();
						listRotate.Add(s1);
						string s1Rotate = s1;
						for (int j = 1; j < s1.Length; j++)
						{
							s1Rotate = Rotate(s1Rotate);
							if (!listRotate.Contains(s1Rotate))
							{
								listRotate.Add(s1Rotate);
							}
						}
						listRotate.Remove(s1);
						List<int> toDelete = new List<int>();
						toDelete.Add(primes[i]);
						bool isStop = listRotate.Count == 0;
						for (int j = i + 1; j < primes.Count && !isStop; j++)
						{
							if (!okNumbers.Contains(primes[j]))
							{
								string s2 = primes[j].ToString();
								isStop = s1.Length != s2.Length;
								if (!isStop)
								{
									if (listRotate.Contains(s2))
									{
										listRotate.Remove(s2);
										toDelete.Add(primes[j]);
										isStop = listRotate.Count == 0;
									}
								}
							}
						}
						if (listRotate.Count == 0)
						{
							foreach (int k in toDelete)
							{
								okNumbers.Add(k);
							}
						}
					}
				}
			}
			int result = okNumbers.Count + 1;//the 2 is forgotten
			Console.Out.WriteLine("result = {0}", result);
            return result;
		}

		public override void Dispose()
		{
			
		}
	}
}
