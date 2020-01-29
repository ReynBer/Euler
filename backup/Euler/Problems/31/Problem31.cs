using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem31 :Problem {
		public override object Launch()
		{
			int[] levels = new int[8]{200, 100, 50, 20, 10, 5, 2, 1};
			int[] maxLevels = new int[8];
			for (int i = 0; i < levels.Length; i++)
			{
				maxLevels[i] = (200 / levels[i]) + 1;
			}
			int[] sumLevels = new int[8];
			int count = 0;
			int sum = 0;

			for (int i = 0; i < maxLevels[0] && sum < 200; i++)
			{
				sum += (i == 0) ? 0 : levels[0];
				if (sum == 200)
				{
					count++;
				}
				else
				{
					sumLevels[0] = sum;
					for (int j = 0; j < maxLevels[1] && sum < 200; j++)
					{
						sum += (j == 0) ? 0 : levels[1];
						if (sum == 200)
						{
							count++;
						}
						else
						{
							sumLevels[1] = sum;
							for (int k = 0; k < maxLevels[2] && sum < 200; k++)
							{
								sum += (k == 0) ? 0 : levels[2];
								if (sum == 200)
								{
									count++;
								}
								else
								{
									sumLevels[2] = sum;
									for (int l = 0; l < maxLevels[3] && sum < 200; l++)
									{
										sum += (l == 0) ? 0 : levels[3];
										if (sum == 200)
										{
											count++;
										}
										else
										{
											sumLevels[3] = sum;
											for (int m = 0; m < maxLevels[4] && sum < 200; m++)
											{
												sum += (m == 0) ? 0 : levels[4];
												if (sum == 200)
												{
													count++;
												}
												else
												{
													sumLevels[4] = sum;
													for (int n = 0; n < maxLevels[5] && sum < 200; n++)
													{
														sum += (n == 0) ? 0 : levels[5];
														if (sum == 200)
														{
															count++;
														}
														else
														{
															sumLevels[5] = sum;
															for (int o = 0; o < maxLevels[6] && sum < 200; o++)
															{
																sum += (o == 0) ? 0 : levels[6];
																if (sum == 200)
																{
																	count++;
																}
																else
																{
																	sumLevels[6] = sum;
																	for (int q = 0; q < maxLevels[7] && sum < 200; q++)
																	{
																		sum += (q == 0) ? 0 : levels[7];
																		if (sum == 200)
																		{
																			count++;
																		}
																	}
																	sum = sumLevels[6];
																}
															}
															sum = sumLevels[5];
														}
													}
													sum = sumLevels[4];
												}
											}
											sum = sumLevels[3];
										}
									}
									sum = sumLevels[2];
								}
							}
							sum = sumLevels[1];
						}
					}
					sum = sumLevels[0];
				}
			}
			Console.Out.WriteLine("count = {0}", count);
			return count;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
