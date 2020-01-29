using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem42 : Problem {
		public List<int> Tn = new List<int>();
		public int N {get;set;}
		public int MaxTn { get; set; }
		public void ComputeTn(int n)
		{
			for (int i = N; i <= n; i++)
			{
				Tn.Add(i * (i + 1) / 2);
				if (i == n)
				{
					MaxTn = Tn[i - 1];
				}
			}
			N = n;
		}

		public bool IsTriangleWord(string word)
		{
			int sum = 0;
			foreach (char c in word)
			{
				sum += c - 'A' + 1;
			}
			return IsTriangle(sum);
		}

		public bool IsTriangle(int n)
		{
			//if (n % 2 == 0) return false;
			if (n <= MaxTn) return Tn.Contains(n);
			while (MaxTn < n)
			{
				ComputeTn(N+1);
			}
			return Tn.Contains(n);
		}


		public override object Launch()
		{
			N = 1;
			ComputeTn(100);
			int sum = 0;
			string[] words = Resource.Problem42.Split(new char[1] { ',' });
			foreach (string s in words)
			{
				if (IsTriangleWord(s))
				{
					sum++;
				}
			}
			Console.Out.WriteLine("sum = {0}", sum);
			return sum;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
