using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems
{
	public class Problem15 : Problem
	{
		public override object Launch()
		{
			int max = 1;
			long[] CNm1 = new long[max++];
			CNm1[0] = 1;
			bool isTwiceTime = true;
			int count = 0;
			while (count != 20)
			{
				long[] CN = new long[max++];
				for (int i = 0; i < CN.Length; i++)
				{
					CN[i] = ((i - 1) < 0 ? 0 : CNm1[i - 1]) + ((i >= CNm1.Length) ? 0 : CNm1[i]);
				}
				CNm1 = CN;
				isTwiceTime = !isTwiceTime;
				if (isTwiceTime)
				{
					count++;
				}
			}
			long value = CNm1[CNm1.Length / 2];
			Console.Out.WriteLine("value = {0}", value);
			return value;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
