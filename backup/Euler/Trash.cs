using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler {
	public class Trash
	{
		public static long[,] Multiply(long[,] mA, long[,] mB)
		{
			if (mA.GetLength(1) == mB.GetLength(0) && mA.GetLength(0) == mB.GetLength(1))
			{
				long[,] m = new long[mA.GetLength(0), mB.GetLength(1)];
				for (int i = 0; i < mA.GetLength(0); i++)
				{
					for (int j = 0; j < mA.GetLength(1); j++)
					{
						long sum = 0;
						for (int k = 0; k < mA.GetLength(1); k++)
						{
							sum += mA[i, k] * mB[k, j];
						}
						m[i, j] = sum;
					}
				}
				return m;
			}
			return null;
		}

		public void toto()
		{
			/*
			*/
			/*long[,] Id = new long[2, 2];
			Id[0,0] = 1;
			Id[1,1] = 1;
			long[,] result = Multiply(Id, Id);*/
			/*int dec = 2;
			int size = dec * dec;
			long[,] matrice_adj = new long[size, size];
			for (int j = 0; j < size; j++)
			{
				int indice = j + 1;
				if (indice < size)
				{
					matrice_adj[indice, indice] = 1;

					if (indice + dec < size)
					{
						matrice_adj[indice + dec, indice] = 1;
					}
				}
			}*/
			/*for (int i = 0; i < 20; i++)
			{
				matrice_adj = Multiply(matrice_adj, matrice_adj);
			}*/

		}
	}
}
