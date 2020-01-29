using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler {
	public class Euclide
	{
		public static int[] PGCD(int a, int b)
		{
			int[] result = new int[3];
			int r_n = a;
			result[0] = b;
			int u_n = 1;
			int v_n = 0;
			result[1] = 0;
			result[2] = 1;
			while (result[0] != 0)
			{
				int q = r_n / result[0];
				int rs = r_n;
				int us = u_n;
				int vs = v_n;
				r_n = result[0];
				result[0] = rs - q * result[0];
				result[1] = us - q * result[1];
				result[2] = vs - q * result[2];
			}
			return result;
		}
	}
}
