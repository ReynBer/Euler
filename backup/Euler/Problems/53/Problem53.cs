using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem53 : Problem
	{
		public override object Launch()
		{
			int max = 1;
			BigInt[] CNm1 = new BigInt[max++];
			CNm1[0] = new BigInt(1);
			int count = 0;
			int nbValuesSupOneMillion = 0;
			while (count != 100)
			{
				BigInt[] CN = new BigInt[max++];
				for (int i = 0; i < CN.Length; i++)
				{
					CN[i] = ((i - 1) < 0 ? new BigInt(0) : CNm1[i - 1]) + ((i >= CNm1.Length) ? new BigInt(0) : CNm1[i]);
					if (CN[i].Value.Length >= 7)
						nbValuesSupOneMillion++;
				}
				CNm1 = CN;
				count++;
			}
			Console.Out.WriteLine("resultat = {0}", nbValuesSupOneMillion);
			return nbValuesSupOneMillion;

		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
