using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem28 : Problem {

		public void PrintSquare(int[] square, int size)
		{
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					Console.Out.Write("{0} ", square[i * size + j].ToString("00"));
				}
				Console.Out.WriteLine("");
			}
		}

		public override object Launch()
		{
			int x = 1001;
			int[] indexDirections = new int[4];
			indexDirections[0] = 1;
			indexDirections[1] = x;
			indexDirections[2] = -1;
			indexDirections[3] = -x;
			int[] square = new int[x * x];
			int deb = square.Length / 2;
			int i = 1;
			square[deb] = i++;
			int sum = square[deb];
			int indexCurrentDirection = 0;
			int max = 1;
			int cptInDirection = max;
			int twoTimes = 0;
			for (int d = 1; d < square.Length; d++)
			{
				deb += indexDirections[indexCurrentDirection];
				square[deb] = i++;
				if (--cptInDirection == 0)
				{
					indexCurrentDirection++;
					if (indexCurrentDirection == indexDirections.Length)
						indexCurrentDirection = 0;
					cptInDirection = max;
					if (++twoTimes == 2)
					{
						twoTimes = 0;
						max++;
						cptInDirection++;
					}
				}
			}
			/*Console.Out.WriteLine("");
			PrintSquare(square, x);
			Console.Out.WriteLine("");*/
			max = x / 2;
			for (int l = 0; l < indexDirections.Length; l++)
			{
				deb = square.Length / 2;
				for (int k = 0; k < max; k++)
				{
					deb += indexDirections[l] + indexDirections[(l + 1) % 4];
					sum += square[deb];
				}
			}
			Console.Out.WriteLine("sum = {0}", sum);
			return null;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
