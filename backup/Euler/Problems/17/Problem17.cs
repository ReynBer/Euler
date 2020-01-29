using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Euler.Problems
{
	public class Problem17 : Problem
	{
		public override object Launch()
		{
			long sum = 0;
			for (int i = 1; i < 1000; i++)
			{
				string t = i.ToString();
				IEnumerable<char> reverse = t;//.Reverse();
				int nb_char = t.Length;
				string step_n = "";
				string step_nm1 = "";
				string res = "";
				int j = 0;
				bool isDone = false;
				string chiffre = "";
				//bool isThereAnd = false;
				foreach (char ct in reverse)
				{
					switch (ct)
					{
						case '1':
							chiffre = "One";
							if ((j == 0 && nb_char == 2) || (j == 1 && nb_char == 3))
								chiffre = "Ten";
							break;
						case '2':
							chiffre = "Two";
							if ((j == 0 && nb_char == 2) || (j == 1 && nb_char == 3))
								chiffre = "Twen";
							break;
						case '3':
							chiffre = "Three";
							if ((j == 0 && nb_char == 2) || (j == 1 && nb_char == 3))
								chiffre = "Thir";
							break;
						case '4':
							chiffre = "Four";
							if ((j == 0 && nb_char == 2) || (j == 1 && nb_char == 3))
								chiffre = "For";
							break;
						case '5':
							chiffre = "Five";
							if ((j == 0 && nb_char == 2) || (j == 1 && nb_char == 3))
								chiffre = "Fif";
							break;
						case '6':
							chiffre = "Six";
							break;
						case '7':
							chiffre = "Seven";
							break;
						case '8':
							chiffre = "Eight";
							if ((j == 0 && nb_char == 2) || (j == 1 && nb_char == 3))
								chiffre = "Eigh";
							break;
						case '9':
							chiffre = "Nine";
							break;
						default:
							chiffre = "";
							break;
					}
					if (j == 0 && nb_char == 3)
					{
						step_n = chiffre + "Hundred";
					}
					if ((j == 2 || j == 1) && nb_char == 3 && chiffre != "")
					{
						if (!isDone)
						{
							step_n += "And";
							isDone = true;
						}
					}

					if (((j == 0 && nb_char == 2) || (j == 1 && nb_char == 3)) && (chiffre != ""))
						step_n += chiffre + "ty";

					if ((j == 1 && nb_char == 2) || (j == 2 && nb_char == 3))
					{
						if (step_nm1 == "Tenty")
						{
							switch (ct)
							{
								case '1':
									step_n += "Eleven";
									break;
								case '2':
									step_n += "Twelve";
									break;
								case '3':
									step_n += "Thirteen";
									break;
								case '5':
									step_n += "Fifteen";
									break;
								case '8':
									step_n += "Eighteen";
									break;
								case '4':
								case '6':
								case '7':
								case '9':
									step_n += chiffre + "teen";
									break;
								default :
									step_n += "Ten";
									break;
							}
						}
					}
					if (step_n == "" || step_n.EndsWith("And"))
						step_n += chiffre;
					if (step_n == "Tenty" || step_n == "AndTenty")
					{
						step_nm1 = "Tenty";
						if (step_n == "AndTenty")
							res += "And";
					}
					else
					{
						res += step_n;
					}
					step_n = "";
					j++;
				}
				sum += res.LongCount();
				//Console.Out.WriteLine("res = {0}", res);
				//Console.ReadKey();
			}
			string onethousand = "onethousand";
			sum += onethousand.LongCount();
			Console.Out.WriteLine("sum = {0}", sum);
			return null;
			//throw new NotImplementedException();
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
