using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem100 : Problem {
		public override object Launch()
		{
			long aNm1 = 1;
			long bNm1 = 1;
			long aN=0;
			long bN;
			long result = 0;
			bool impair = true;
			while ((aN + 1) < 2000000000000 || !impair)
			{
				impair = !impair;
				bN = aNm1 + bNm1;
				aN = bN + bNm1;
				aNm1 = aN;
				bNm1 = bN;
				if (impair)
				{
					result = (bN + 1) / 2;
				}
			}
			Console.Out.WriteLine("resultat = {0}", result);
			return result;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
