using System;
using System.Collections.Generic;
using System.Text;
using Euler.Problems;

namespace Euler
{
	class Program
	{
		static void Main(string[] args)
		{
			//Euclide e = new Euclide();
			//int[] t = e.PGCD(10, 5);
			using (Problem problem = new Problem45())
			{
				//problem.BenchMark(100);
				problem.Launch();
			}
			Console.Out.WriteLine("Press any key...");
			Console.ReadKey();
		}
	}
}
