using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler {
	public class Binary
	{
		bool[] binary = new bool[32];
		public bool[] Value
		{
			get { return binary; }
			//set { binary = value; }
		}

		public Binary()
		{
		}

		public Binary(bool[] binary)
		{
			this.binary = binary;
		}

		public Binary(Binary binary)
		{
			this.binary = binary.Value;
		}

		public static Binary operator ++(Binary t)
		{
			bool[] b = t.Value;
			bool isStop = false;
			for (int i = b.Length - 1; i >= 0 && !isStop; i--)
			{
				isStop = !b[i];
				b[i] = !b[i];
			}
			return new Binary(t);
		}

		public override string ToString()
		{
			string s = null;
			for (int i = 0; i < binary.Length; i++)
			{
				if (!(s == null && !binary[i]))
				{
					if (s == null)
					{
						s = "1";
					}
					else
					{
						s += (binary[i] ? "1" : "0");
					}
				}
			}
			if (s == null)
				s = "0";
			return s;
		}
	}
}
