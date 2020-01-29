using System;
using System.Collections.Generic;
using System.Text;

namespace Euler
{
	public abstract class Problem : IDisposable
	{
		public abstract object Launch();
		public abstract void Dispose();
		public void BenchMark(int nbTimes)
		{
			Console.WriteLine(DateTime.Now);
			for (int i = 0; i < nbTimes; i++)
			{
				var j = Launch();
			}
			Console.WriteLine(DateTime.Now);
		}
	}
}
