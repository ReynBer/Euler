using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem12 : Problem {
		public override object Launch()
		{
			bool isFound = false;
			Dictionary<long, List<long>> triangle = new Dictionary<long, List<long>>();
			long i = 1;
			long index = i;
			triangle.Add(index, new List<long>());
			triangle[index].Add(i);
			while (!isFound)
			{
				i++;
				index += i;
				triangle.Add(index, new List<long>());
				long max_step = (long)Math.Floor(Math.Sqrt(index));
				for (long j = 1; j <= max_step; j++)
				{
					if (index % j == 0)
					{
						triangle[index].Add(j);
						long complement = index / j;
						if (complement != j)
						{
							triangle[index].Add(complement);
						}
					}
				}
				isFound = triangle[index].Count >= 500;
				//triangle.Clear();
			}
			Console.Out.WriteLine("index = {0}", index);

			return index;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
