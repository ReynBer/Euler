using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem13 : Problem {
		public override object Launch()
		{
			string[] rows = Resource.problem13.Split(new string[1] { "\r\n" }, StringSplitOptions.None);
			string row1 = null;
			foreach (string row2 in rows)
			{
				if (row1 == null)
				{
					row1 = row2;//.Substring(row2.Length - 10, 10);
				}
				else
				{
					bool accu = false;
					char[] tc1 = row1.ToCharArray();
					row1 = "";
					char[] tc2 = row2.ToCharArray();
					int j = tc2.Length;
					for (int i = tc1.Length - 1; i >= 0; i--)
					{
						j--;
						int sum = int.Parse(tc1[i].ToString()) + (j < 0 ? 0 : int.Parse(tc2[j].ToString()));
						if (accu)
						{
							sum++;
						}
						accu = sum > 9;
						if (accu)
						{
							sum -= 10;
						}
						row1 = sum.ToString() + row1;
					}
					if (accu)
					{
						row1 = "1" + row1;
					}
					//row1 = row1.Substring(row1.Length - 10, 10);
				}
			}
			Console.Out.WriteLine("row1 = {0}", row1);
			Console.Out.WriteLine("10 first row1 = {0}", row1.Substring(0, 10));
			return row1;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
