using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
	public class BigInt
	{
		private string value;
		List<int> listV = null;
		public string Value
		{
			get { return value; }
		}
		private string SValue { set { this.value = value; parseValue(value);} }
		public IEnumerable<int> ListValue { get { return listV; } }

		private void parseValue(string v)
		{
			listV = new List<int>();
			foreach (char c in v)
			{
				listV.Add(int.Parse(c.ToString()));
			}
		}

		public void SetValue(BigInt n)
		{
			SValue = n.Value;
		}

		public BigInt()
		{
			value = null;
		}

		public BigInt(BigInt n)
		{
			SValue = n.Value;
		}

		public BigInt(int n)
		{
			SValue = n.ToString();
		}

		public BigInt(long n)
		{
			SValue = n.ToString();
		}

		public BigInt(string n)
		{
			SValue = n;
		}

		public static BigInt operator +(BigInt n1, BigInt n2)
		{
			return n1.Add(n2);
		}

		public static BigInt operator -(BigInt n1, BigInt n2)
		{
			return n1.Moins(n2);
		}

		public static BigInt operator /(BigInt n1, BigInt n2)
		{
			return n1.Divide(n2);
		}

		public static BigInt operator *(BigInt n1, BigInt n2)
		{
			return n1.Multiply(n2);
		}

		public bool Equals(BigInt n1)
		{
			return n1.Value == value;
		}


		public BigInt Add(BigInt n)
		{
			IEnumerable<int> n2 = n.ListValue;
			IEnumerable<int> n1 = ListValue;
			string result = "";
			bool dizaine = false;
			if (n2.Count() > n1.Count())
			{
				IEnumerable<int> temp = n1;
				n1 = n2;
				n2 = temp;
			}
			int count = n1.Count();
			int decalage = count - n2.Count();

			for (int i = count - 1; i >= 0; i--)
			{
				int t = n1.ElementAt(i) + (i >= decalage ? n2.ElementAt(i - decalage) : 0);
				if (dizaine)
				{
					t++;
				}
				if (t > 9)
				{
					t -= 10;
					dizaine = true;
				}
				else
				{
					dizaine = false;
				}
				result = t.ToString() + result;
			}
			if (dizaine)
			{
				dizaine = false;
				result = "1" + result;
			}
			return new BigInt(result);
		}

		public BigInt Moins(BigInt n)
		{
			IEnumerable<int> n2 = n.ListValue;
			IEnumerable<int> n1 = ListValue;
			string result = "";
			bool dizaine = false;
			if (n2.Count() > n1.Count())
			{
				IEnumerable<int> temp = n1;
				n1 = n2;
				n2 = temp;
			}
			int count = n1.Count();
			int decalage = count - n2.Count();

			for (int i = count - 1; i >= 0; i--)
			{
				int t = n1.ElementAt(i) - (i >= decalage ? n2.ElementAt(i - decalage) : 0);
				if (dizaine)
				{
					t--;
				}
				if (t < 0)
				{
					t += 10;
					dizaine = true;
				}
				else
				{
					dizaine = false;
				}
				result = t.ToString() + result;
			}
			return new BigInt(result);
		}

		public BigInt Divide(BigInt n)
		{
			IEnumerable<int> n2 = n.ListValue;
			IEnumerable<int> n1 = ListValue;
			string result = "";
			BigInt finalResult = null;
			string complement = "";
			int dizaine = 0;
			for (int i = n1.Count() - 1; i >= 0; i--)
			{
				for (int j = n2.Count() - 1; j >= 0; j--)
				{
					int t = n1.ElementAt(i) * n2.ElementAt(j);
					t += dizaine;
					int reste = t % 10;
					dizaine = (t - reste) / 10;
					t = reste;
					result = t.ToString() + result;
				}
				if (dizaine > 0)
				{
					result = dizaine.ToString() + result;
					dizaine = 0;
				}
				if (finalResult == null)
				{
					finalResult = new BigInt(result);
				}
				else
				{
					finalResult = finalResult.Add(new BigInt(result));
				}
				complement += "0";
				result = complement;
			}
			return finalResult;
		}

		public BigInt Multiply(BigInt n)
		{
			IEnumerable<int> n2 = n.ListValue;
			IEnumerable<int> n1 = ListValue;
			string result = "";
			BigInt finalResult = null;
			string complement = "";
			int dizaine = 0;
			for (int i = n1.Count() - 1; i >= 0; i--)
			{
				for (int j = n2.Count()- 1; j >= 0; j--)
				{
					int t = n1.ElementAt(i) * n2.ElementAt(j);
					t += dizaine;
					int reste = t % 10;
					dizaine = (t - reste) / 10;
					t = reste;
					result = t.ToString() + result;
				}
				if (dizaine > 0)
				{
					result = dizaine.ToString() + result;
					dizaine = 0;
				}
				if (finalResult == null)
				{
					finalResult = new BigInt(result);
				}
				else
				{
					finalResult = finalResult.Add(new BigInt(result));
				}
				complement += "0";
				result = complement;
			}
			return finalResult;
		}

		public BigInt Puissance(int n)
		{
			BigInt t = new BigInt(this);
			for (int i = 0; i < n; i++)
			{
				t = t.Multiply(this);
			}
			return t;
		}

		public override string ToString()
		{
			return value;
		}
	}
}
