using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
	public class PrimaryGenerator
	{
		private List<bool> isPrimary = new List<bool>();
		public IEnumerable<int> Get(int n)
		{
			if (isPrimary.Count < n)
			{
				isPrimary = new List<bool>();
				isPrimary.Add(false);
				isPrimary.Add(false);
				int max = n - 2;
				for (int i = 0; i < max; i++)
				{
					isPrimary.Add(true);
				}
				int step = 1;
				while (step < isPrimary.Count)
				{
					step++;
					if (step < isPrimary.Count && isPrimary[step])
					{
						for (int i = step + step; i < n; i += step)
						{
							isPrimary[i] = false;
						}
					}
				}
			}
			List<int> result = new List<int>();
			for (int i = 0; i < isPrimary.Count; i++)
			{
				if (isPrimary[i])
				{
					result.Add(i);
				}
			}
			return result;
		}

		public bool IsPrimary(int n)
		{
			if (isPrimary.Count < n)
			{
				Get(n+1);
			}
			return isPrimary.ElementAt(n);
		}

	}
}
