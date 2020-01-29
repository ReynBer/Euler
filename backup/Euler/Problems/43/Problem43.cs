using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem43 : Problem {
		public Dictionary<int, bool[]> IsDicoDivisible = new Dictionary<int, bool[]>();
		private char[] through = new char[10];
			

		public void AddDivisible(int key)
		{
			IsDicoDivisible.Add(key, new bool[1000]);
			for (int i = key; i < IsDicoDivisible[key].Length; i+=key)
			{
				IsDicoDivisible[key][i] = true;
			}
		}

		public List<string> GeneratePandigital(int nMax, int n, IEnumerable<char> list, List<string> pandigitals)
		{
			IEnumerable<char> enumerable = list;
			foreach (char i in enumerable)
			{
				if (n == 1)
				{
					pandigitals.Add(i.ToString());
					return pandigitals;
				}
				int r = pandigitals.Count;
				GeneratePandigital(nMax, n - 1, list.Except(new char[1] { i }), pandigitals);
				for (int j = r; j < pandigitals.Count; j++)
				{
					pandigitals[j] = i + pandigitals[j];
					switch (pandigitals[j].Length)
					{
						case 4:
							if (!IsDicoDivisible[17][int.Parse(pandigitals[j].Substring(1, 3))])
							{
								pandigitals.RemoveAt(j--);
							}
							break;
						case 5:
							if (!IsDicoDivisible[13][int.Parse(pandigitals[j].Substring(2, 3))])
							{
								pandigitals.RemoveAt(j--);
							}
							break;
						case 6:
							if (!IsDicoDivisible[11][int.Parse(pandigitals[j].Substring(3, 3))])
							{
								pandigitals.RemoveAt(j--);
							}
							break;
						case 7:
							if (!IsDicoDivisible[7][int.Parse(pandigitals[j].Substring(4, 3))])
							{
								pandigitals.RemoveAt(j--);
							}
							break;
						case 8:
							if (!IsDicoDivisible[5][int.Parse(pandigitals[j].Substring(5, 3))])
							{
								pandigitals.RemoveAt(j--);
							}
							break;
						case 9:
							if (!IsDicoDivisible[3][int.Parse(pandigitals[j].Substring(6, 3))])
							{
								pandigitals.RemoveAt(j--);
							}
							break;
						case 10:
							if (!IsDicoDivisible[2][int.Parse(pandigitals[j].Substring(7, 3))])
							{
								pandigitals.RemoveAt(j--);
							}
							break;
					}
				}
			}
			return pandigitals;
		}


		public override object Launch()
		{
			for (int i = 0; i < 10; i++)
			{
				through[i] = i.ToString()[0];
			}
			AddDivisible(2);
			AddDivisible(3);
			AddDivisible(5);
			AddDivisible(7);
			AddDivisible(11);
			AddDivisible(13);
			AddDivisible(17);
			List<string> pandigitals = new List<string>();
			//GeneratePandigital(10, 10, through, pandigitals);

			bool[] choosen = new bool[10];
			for (int i = 0; i < 10; i++)
			{
				choosen[i] = true;
				for (int j = 0; j < 10; j++)
				{
					if (!choosen[j])
					{
						choosen[j] = true;
						for (int k = 0; k < 10; k++)
						{
							if (!choosen[k])
							{
								choosen[k] = true;
								if (IsDicoDivisible[17][int.Parse(through[k].ToString() + through[j].ToString() + through[i].ToString())])
								{
									for (int l = 0; l < 10; l++)
									{
										if (!choosen[l])
										{
											choosen[l] = true;
											if (IsDicoDivisible[13][int.Parse(through[l].ToString() + through[k].ToString() + through[j].ToString())])
											{
												for (int m = 0; m < 10; m++)
												{
													if (!choosen[m])
													{
														choosen[m] = true;
														if (IsDicoDivisible[11][int.Parse(through[m].ToString() + through[l].ToString() + through[k].ToString())])
														{
															for (int n = 0; n < 10; n++)
															{
																if (!choosen[n])
																{
																	choosen[n] = true;
																	if (
																		IsDicoDivisible[7][int.Parse(through[n].ToString() + through[m].ToString() + through[l].ToString())])
																	{
																		for (int o = 0; o < 10; o++)
																		{
																			if (!choosen[o])
																			{
																				choosen[o] = true;
																				if (
																					IsDicoDivisible[5][int.Parse(through[o].ToString() + through[n].ToString() + through[m].ToString())
																						])
																				{
																					for (int p = 0; p < 10; p++)
																					{
																						if (!choosen[p])
																						{
																							choosen[p] = true;
																							if (
																								IsDicoDivisible[3][
																									int.Parse(through[p].ToString() + through[o].ToString() + through[n].ToString())])
																							{
																								for (int q = 0; q < 10; q++)
																								{
																									if (!choosen[q])
																									{
																										choosen[q] = true;
																										if (
																											IsDicoDivisible[2][
																												int.Parse(through[q].ToString() + through[p].ToString() + through[o].ToString())])
																										{
																											for (int r = 0; r < 10; r++)
																											{
																												if (!choosen[r])
																												{
																													pandigitals.Add(r.ToString() +
																													                q.ToString() +
																													                p.ToString() +
																													                o.ToString() +
																													                n.ToString() +
																													                m.ToString() +
																													                l.ToString() +
																													                k.ToString() +
																													                j.ToString() +
																													                i.ToString()
																													);
																												}
																											}
																										}
																										choosen[q] = false;
																									}
																								}
																							}
																							choosen[p] = false;
																						}
																					}
																				}
																				choosen[o] = false;
																			}
																		}
																	}
																	choosen[n] = false;
																}
															}
														}
														choosen[m] = false;
													}
												}
											}
											choosen[l] = false;
										}
									}
								}
								choosen[k] = false;
							}
						}
						choosen[j] = false;
					}
				}
				choosen[i] = false;
			}
			BigInt resultat = new BigInt(0);
			foreach (string s in pandigitals)
			{
				resultat = resultat + new BigInt(s);
			}
			Console.Out.WriteLine("resultat = {0}", resultat.Value);
			return resultat;
            /*
			* d_(2)d_(3)d_(4)=406 is divisible by 2
			* d_(3)d_(4)d_(5)=063 is divisible by 3
			* d_(4)d_(5)d_(6)=635 is divisible by 5
			* d_(5)d_(6)d_(7)=357 is divisible by 7
			* d_(6)d_(7)d_(8)=572 is divisible by 11
			* d_(7)d_(8)d_(9)=728 is divisible by 13
			* d_(8)d_(9)d_(10)=289 is divisible by 17
			*/

		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
