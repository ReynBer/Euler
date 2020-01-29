using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems
{
	public class SudokuGrid
	{
		private CaseSudokuGrid[] grid;
		public CaseSudokuGrid[] Grid { get { return grid; } }

		public const int RowCount = 9;
		public const int ColumnCount = 9;
		public const int Count = 81;
		public const int RegionCount = 9;
		private Dictionary<int, int[]> regions;

		private string name;
		public string Name { get { return name; } }

		public int NbFound { get; set; }
		public bool IsResolved { get { return NbFound == Count; } }

		public SudokuGrid(string name)
		{
			this.name = name;
			grid = new CaseSudokuGrid[Count];
			regions = new Dictionary<int, int[]>();
			for (int i = 0; i < RegionCount; i++)
			{
				regions.Add(i, new int[RegionCount]);
			}
			for (int i = 0; i < Count; i++)
			{
				int column = i % ColumnCount;
				int row = (i - column) / ColumnCount;
				grid[i] = new CaseSudokuGrid(
					row,
					column,
					(row / 3) * 3 + (column / 3)
				);
				regions[grid[i].Region][row % 3 * 3 + column % 3] = i;
				grid[i].AddListener(this.Propagate);
			}
		}

		public SudokuGrid Clone()
		{
			SudokuGrid sudokuGrid = new SudokuGrid(this.Name);
			for (int i = 0; i < Grid.Length; i++)
			{
				if (Grid[i].Value != 0)
				{
					sudokuGrid.Grid[i].Value = Grid[i].Value;
				}
			}
			return sudokuGrid;
		}

		public void AddRow(int row, string value)
		{
			int max = (row + 1) * ColumnCount;
			int j = 0;
			for (int i = max - ColumnCount; i < max; i++)
			{
				int iValue = int.Parse(value.Substring(j++, 1));
				if (iValue != 0)
				{
					grid[i].Value = iValue;
				}
			}
		}

		public void PrintIt()
		{
			Console.Out.WriteLine("{0}", name);
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = 0; j < ColumnCount; j++)
				{
					Console.Out.Write("{0} ", grid[i * ColumnCount + j].Value);
				}
				Console.Out.WriteLine();
			}
			Console.Out.WriteLine();
			Console.Out.WriteLine();
		}

		public IEnumerable<int> GetPossibilitiesByRegion(int region)
		{
			List<int> possibilities = new List<int>();
			foreach (int index in regions[region])
			{
				foreach (int possibility in grid[index].Possibilities)
				{
					if (!possibilities.Contains(possibility))
					{
						possibilities.Add(possibility);
					}
				}
			}
			return possibilities;
		}

		public IEnumerable<int> GetPossibilitiesByRow(int row)
		{
			List<int> possibilities = new List<int>();
			int max = (row + 1) * ColumnCount;
			for (int j = max - ColumnCount; j < max; j++)
			{
				foreach (int possibility in grid[j].Possibilities)
				{
					if (!possibilities.Contains(possibility))
					{
						possibilities.Add(possibility);
					}
				}
			}
			return possibilities;
		}

		public IEnumerable<int> GetPossibilitiesByColumn(int column)
		{
			List<int> possibilities = new List<int>();
			int max = (column + 1) * ColumnCount;
			for (int j = column; j < Count; j += ColumnCount)
			{
				foreach (int possibility in grid[j].Possibilities)
				{
					if (!possibilities.Contains(possibility))
					{
						possibilities.Add(possibility);
					}
				}
			}
			return possibilities;
		}

		public IEnumerable<int> GetIndexesColumn(int column)
		{
			int[] columns = new int[RowCount];
			int j = 0;
			for (int i = column; i < Count; i += ColumnCount)
			{
				columns[j++] = i;
			}
			return columns;
		}

		public IEnumerable<int> GetIndexesRow(int row)
		{
			int[] rows = new int[ColumnCount];
			int j = 0;
			int max = (row + 1) * ColumnCount;
			for (int i = max - ColumnCount; i < max; i++)
			{
				rows[j++] = i;
			}
			return rows;
		}

		public IEnumerable<int> GetIndexesRegionsThroughColumn(int column)
		{
			int size = (int)Math.Sqrt(RowCount);
			int[] regions = new int[size];
			int begin = column / regions.Length;
			int step = regions.Length;
			for (int i = 0; i < regions.Length; i++)
			{
				regions[i] = begin + step * i;
			}
			return regions;
		}

		public IEnumerable<int> GetIndexesRegionsThroughRow(int row)
		{
			int size = (int)Math.Sqrt(RowCount);
			int[] regions = new int[size];
			int begin = row / regions.Length;
			begin *= regions.Length;
			for (int i = 0; i < regions.Length; i++)
			{
				regions[i] = begin + i;
			}
			return regions;
		}

		public IEnumerable<int> GetIndexesInRegionAndColumn(int region, int column)
		{
			IEnumerable<int> indexesColumn = GetIndexesColumn(column);
			IEnumerable<int> indexesRegion = regions[region];
			return indexesRegion.Intersect(indexesColumn).Distinct();
		}

		public IEnumerable<int> GetIndexesInRegionAndRow(int region, int row)
		{
			IEnumerable<int> indexesRow = GetIndexesRow(row);
			IEnumerable<int> indexesRegion = regions[region];
			return indexesRegion.Intersect(indexesRow).Distinct();
		}

		public IEnumerable<int> CheckColumn(int row, int column, IEnumerable<int> possiblities)
		{
			//Pour chaque colonne
			for (int i = 0; i < ColumnCount; i++)
			{
				int[] indexes = GetIndexesColumn(i).ToArray();
				for (int j = 0; j < RowCount; j++)
				{
					List<int> possibilities = grid[indexes[j]].Possibilities;
					if (possibilities.Count > 1 && possibilities.Count < 9)
					{
						int[] indexesProtected = new int[possibilities.Count];
						int nbToFind = possibilities.Count - 1;
						indexesProtected[nbToFind] = j * ColumnCount + i;
						for (int k = 0; k < RowCount; k++)
						{
							if (k == j) continue;
							List<int> possibilities2 = grid[indexes[k]].Possibilities;
							if (possibilities2.Count > 0)
							{
								if (possibilities2.Count <= possibilities.Count)
								{
									if (possibilities.Intersect(possibilities2).Distinct().Count() == possibilities2.Count)
									{
										nbToFind--;
										indexesProtected[nbToFind] = k * ColumnCount + i;
									}
									else
									{
									}
								}
							}
						}
						//Si < 0, on a gros probleme -> on ne le traite pas
						//Si == 0, C'est de la bombe
						if (nbToFind == 0)
						{
							for (int k = 0; k < possibilities.Count; k++)
							{
								PropagateOnColumn(i, possibilities[k], indexesProtected);
							}
						}
					}
				}
			}
			return null;
		}

		public void FixPossibilities()
		{
			//Pour chaque case du sudoku, si une seule possibilité on la fixe
			for (int i = 0; i < Count; i++)
			{
				if (grid[i].Possibilities.Count == 1)
				{
					grid[i].Value = grid[i].Possibilities[0];
				}
			}
		}

		private void MethodCToSolve()
		{
			/* Regardez si dans une ligne de la grille de résolution
			 * un chiffre n'apparaît que deux fois dans la ligne. Si
			 * les cases qui contiennent ce chiffre correspondent avec
			 * un autre chiffre qui satisfait ce critère, alors ces
			 * cases doivent contenir cette paire de chiffres
			 * vous pouvez donc éliminer les autres options de ces cases.
			 * A nouveau, cette règle est répétée pour les colonnes et les blocs.
			 * Cette méthode est également répétée pour les triplets et plus.*/
			for (int i = 0; i < RowCount; i++)
			{
				int[] indexes = GetIndexesRow(i).ToArray();
				for (int j = 0; j < ColumnCount; j++)
				{
					List<int> possibilities = grid[indexes[j]].Possibilities;
					if (possibilities.Count > 1 && possibilities.Count < 9)
					{
						List<int> indexesProtected = new List<int>();
						indexesProtected.Add(indexes[j]);
						IEnumerable<int> unionIntersection = null;
						for (int k = j + 1; k < ColumnCount; k++)
						{
							List<int> possibilities2 = grid[indexes[k]].Possibilities;
							if (possibilities2.Count > 0)
							{
								if (possibilities2.Count <= possibilities.Count)
								{
									IEnumerable<int> possIntersection = possibilities.Intersect(possibilities2).Distinct();
									int countIntersection = possIntersection.Count();
									if (countIntersection > 0)
									{

									}



									if (countIntersection > 0 && countIntersection <= possibilities2.Count &&
									    possibilities2.Except(possibilities).Count() <= possibilities.Count)
									{
										indexesProtected.Add(indexes[k]);
										if (unionIntersection == null)
										{
											unionIntersection = possIntersection;
										}
										else
										{
											unionIntersection = possIntersection.Union(unionIntersection);
										}
									}
								}
							}
						}
						//Si < 0, on a gros probleme -> on ne le traite pas
						//Si == 0, C'est de la bombe
						if (unionIntersection != null && unionIntersection.Count() == indexesProtected.Count)
						{
							for (int k = 0; k < possibilities.Count; k++)
							{
								PropagateOnRow(i, possibilities[k], indexesProtected);
							}
						}
					}
				}
			}

			//Pour chaque colonne
			for (int i = 0; i < ColumnCount; i++)
			{
				int[] indexes = GetIndexesColumn(i).ToArray();
				for (int j = 0; j < RowCount; j++)
				{
					List<int> possibilities = grid[indexes[j]].Possibilities;
					if (possibilities.Count > 1 && possibilities.Count < 9)
					{
						List<int> indexesProtected = new List<int>();
						indexesProtected.Add(indexes[j]);
						IEnumerable<int> unionIntersection = null;
						for (int k = j; k < RowCount; k++)
						{
							List<int> possibilities2 = grid[indexes[k]].Possibilities;
							if (possibilities2.Count > 0)
							{
								IEnumerable<int> possIntersection = possibilities.Intersect(possibilities2).Distinct();
								int countIntersection = possIntersection.Count();
								if (countIntersection > 0)
								{

								}
								/*if (countIntersection > 0 &&
										countIntersection <= possibilities2.Count &&
										possibilities2.Union(unionIntersection).Count() <= possibilities.Count)
									{
										nbToFindMax--;
										indexesProtected.Add(indexes[k]);
										unionIntersection = possibilities2.Union(unionIntersection);
									}*/
								if (countIntersection == possibilities2.Count &&
								    possibilities2.Except(possibilities).Count() <= possibilities.Count)
								{
									indexesProtected.Add(indexes[k]);
									if (unionIntersection == null)
									{
										unionIntersection = possIntersection;
									}
									else
									{
										unionIntersection = possIntersection.Union(unionIntersection);
									}
								}
							}
						}
						if (unionIntersection != null && unionIntersection.Count() == indexesProtected.Count)
						{
							for (int k = 0; k < possibilities.Count; k++)
							{
								PropagateOnColumn(i, possibilities[k], indexesProtected);
							}
						}
					}
				}
			}
		}

		public void Solve()
		{
			PrintIt();
			int foundPrecedingStep = 0;
			while (NbFound != Count && foundPrecedingStep < NbFound)
			{
				foundPrecedingStep = NbFound;

				MethodAToSolve();
				//Si on en a résolu ainsi, on reboucle dessus
				if (NbFound > foundPrecedingStep)
					continue;

				MethodBToSolve();
				//Si on en a résolu ainsi, on reboucle dessus
				if (NbFound > foundPrecedingStep)
					continue;

				MethodCToSolve();
				//Si on en a résolu ainsi, on reboucle dessus
				if (NbFound > foundPrecedingStep)
					continue;
			}
			PrintIt();
		}

		private void MethodAToSolve()
		{
			MethodAToSolveOnRegion();
			MethodAToSolveOnRow();
			MethodAToSolveOnColumn();
		}

		private void MethodAToSolveOnRow()
		{
			/*
			 * Regardez si dans une ligne de la grille de résolution certains
			 * chiffres n'apparaissent qu'une seule fois dans cette ligne. Si
			 * tel est le cas, la case contenant ce chiffre doit être la solution.
			*/
			for (int i = 0; i < RowCount; i++)
			{
				IEnumerable<int> possibilities = GetPossibilitiesByRow(i);
				int max = (i + 1) * ColumnCount;
				foreach (int possibility in possibilities)
				{
					int count = 0;
					int index = -1;
					for (int j = max - ColumnCount; j < max; j++)
					{
						if (grid[j].Possibilities.Contains(possibility))
						{
							count++;
							index = j;
						}
					}
					if (count == 1)
					{
						grid[index].Value = possibility;
					}
				}
			}
		}

		private void MethodAToSolveOnColumn()
		{
			/*
			 * Regardez si dans une colonne de la grille de résolution certains
			 * chiffres n'apparaissent qu'une seule fois dans cette colonne. Si
			 * tel est le cas, la case contenant ce chiffre doit être la solution.
			*/
			for (int i = 0; i < ColumnCount; i++)
			{
				IEnumerable<int> possibilities = GetPossibilitiesByColumn(i);
				foreach (int possibility in possibilities)
				{
					int count = 0;
					int index = -1;
					for (int j = i; j < Count; j += ColumnCount)
					{
						if (grid[j].Possibilities.Contains(possibility))
						{
							count++;
							index = j;
						}
					}
					if (count == 1)
					{
						grid[index].Value = possibility;
					}
				}
			}
		}

		private void MethodAToSolveOnRegion()
		{
			/*
			 * Regardez si dans une région de la grille de résolution certains
			 * chiffres n'apparaissent qu'une seule fois dans cette région. Si
			 * tel est le cas, la case contenant ce chiffre doit être la solution.
			*/
			for (int i = 0; i < RegionCount; i++)
			{
				IEnumerable<int> possibilities = GetPossibilitiesByRegion(i);
				foreach (int possibility in possibilities)
				{
					int count = 0;
					int index = -1;
					for (int j = 0; j < regions[i].Length && count <= 1; j++)
					{
						if (grid[regions[i][j]].Possibilities.Contains(possibility))
						{
							count++;
							index = regions[i][j];
						}
					}
					if (count == 1)
					{
						grid[index].Value = possibility;
					}
				}
			}
		}

		private void MethodBToSolve()
		{
			MethodBToSolveOnRow();
			MethodBToSolveOnColumn();
			MethodBToSolveOnRegion();
		}

		private void MethodBToSolveOnRow()
		{
			/* 
			 * Regardez si dans une ligne de la grille de résolution
			 * certains chiffres n'apparaissent que dans un bloc spécifique.
			 * Ce chiffre doit être dans cette ligne, vous pouvez donc éliminer
			 * ce chiffre des autres cases de ce bloc.
			 */
			for (int i = 0; i < RowCount; i++)
			{
				IEnumerable<int> possibilities = GetPossibilitiesByRow(i);
				foreach (int possibility in possibilities)
				{
					bool[] isContainedInRegion = new bool[3] { false, false, false };
					int[] regionsThroughRow = GetIndexesRegionsThroughRow(i).ToArray();
					for (int j = 0; j < isContainedInRegion.Length; j++)
					{
						int[] indexes = GetIndexesInRegionAndRow(regionsThroughRow[j], i).ToArray();
						for (int k = 0; k < indexes.Length && !isContainedInRegion[j]; k++)
						{
							isContainedInRegion[j] = isContainedInRegion[j] | grid[indexes[k]].Possibilities.Contains(possibility);
						}
					}
					int region = -1;
					int count = 0;
					for (int j = 0; j < isContainedInRegion.Length; j++)
					{
						if (isContainedInRegion[j])
						{
							count++;
							region = regionsThroughRow[j];
						}
					}
					if (count == 1)
					{
						PropagateOnRegion(region, possibility, GetIndexesInRegionAndRow(region, i));
					}
				}
			}
		}

		private void MethodBToSolveOnColumn()
		{
			/* 
			 * Regardez si dans une colonne de la grille de résolution
			 * certains chiffres n'apparaissent que dans un bloc spécifique.
			 * Ce chiffre doit être dans cette colonne, vous pouvez donc éliminer
			 * ce chiffre des autres cases de ce bloc. 
			 */
			for (int i = 0; i < ColumnCount; i++)
			{
				IEnumerable<int> possibilities = GetPossibilitiesByColumn(i);
				foreach (int possibility in possibilities)
				{
					bool[] isContainedInRegion = new bool[3] { false, false, false };
					int[] regionsThroughColumn = GetIndexesRegionsThroughColumn(i).ToArray();
					for (int j = 0; j < isContainedInRegion.Length; j++)
					{
						int[] indexes = GetIndexesInRegionAndColumn(regionsThroughColumn[j], i).ToArray();
						for (int k = 0; k < indexes.Length && !isContainedInRegion[j]; k++)
						{
							isContainedInRegion[j] = isContainedInRegion[j] | grid[indexes[k]].Possibilities.Contains(possibility);
						}
					}
					int region = -1;
					int count = 0;
					for (int j = 0; j < isContainedInRegion.Length; j++)
					{
						if (isContainedInRegion[j])
						{
							count++;
							region = regionsThroughColumn[j];
						}
					}
					if (count == 1)
					{
						PropagateOnRegion(region, possibility, GetIndexesInRegionAndColumn(region, i));
					}
				}
			}
		}

		private void MethodBToSolveOnRegion()
		{
			/* 
			 * La même règle s'applique pour les blocs - regardez si dans un bloc
			 * de la grille de résolution certains chiffres n'apparaissent que dans
			 * une ligne ou colonne spécifique. Ce chiffre doit être dans ce bloc,
			 * vous pouvez donc éliminer ce chiffre dans les cases de la ligne ou de
			 * la colonne en-dehors de ce bloc.
			 */
			for (int i = 0; i < RegionCount; i++)
			{
				IEnumerable<int> possibilities = GetPossibilitiesByRegion(i);
				foreach (int possibility in possibilities)
				{
					//Check alignement en ligne dans la région
					bool[] isContained = new bool[3] { false, false, false };
					for (int j = 0; j < isContained.Length; j++)
					{
						int max = (j + 1) * isContained.Length;
						for (int k = max - isContained.Length; k < max && !isContained[j]; k++)
						{
							isContained[j] = isContained[j] | grid[regions[i][k]].Possibilities.Contains(possibility);
						}
					}
					int row = -1;
					int count = 0;
					for (int j = 0; j < isContained.Length; j++)
					{
						if (isContained[j])
						{
							count++;
							row = grid[regions[i][j * isContained.Length]].Row;
							//int index = j * isContained.Length;
						}
					}
					if (count == 1)
					{
						PropagateOnRow(row, possibility, regions[i]);
					}
					else
					{
						//Check alignement en colonne dans la région
						for (int j = 0; j < isContained.Length; j++)
						{
							isContained[j] = false;
						}
						for (int j = 0; j < isContained.Length; j++)
						{
							for (int k = j; k < RegionCount; k += isContained.Length)
							{
								isContained[j] = isContained[j] | grid[regions[i][k]].Possibilities.Contains(possibility);
							}
						}
						int column = -1;
						count = 0;
						for (int j = 0; j < isContained.Length; j++)
						{
							if (isContained[j])
							{
								count++;
								column = grid[regions[i][j]].Column;
							}
						}
						if (count == 1)
						{
							PropagateOnColumn(column, possibility, regions[i]);
						}
					}
				}
			}
		}

		public bool RuleRegionIsChecked()
		{
			Dictionary<int, int> dico = new Dictionary<int, int>();
			foreach (int i in CaseSudokuGrid.Possibility)
			{
				dico.Add(i, 0);
			}
			for (int i = 0; i < RegionCount; i++)
			{
				foreach (int j in regions[i])
				{
					if (grid[j].Value != 0)
					{
						dico[grid[j].Value]++;
						if (dico[grid[j].Value] > 1)
						{
							return false;
						}
					}
				}
				foreach (int j in CaseSudokuGrid.Possibility)
				{
					dico[j] = 0;
				}
			}
			return true;
		}

		public bool RuleColumnIsChecked()
		{
			Dictionary<int, int> dico = new Dictionary<int, int>();
			foreach (int i in CaseSudokuGrid.Possibility)
			{
				dico.Add(i, 0);
			}
			for (int i = 0; i < ColumnCount; i++)
			{
				for (int j = i; j < Count; j += ColumnCount)
				{
					if (grid[j].Value != 0)
					{
						dico[grid[j].Value]++;
						if (dico[grid[j].Value] > 1)
						{
							return false;
						}
					}
				}
				foreach (int k in CaseSudokuGrid.Possibility)
				{
					dico[k] = 0;
				}
			}
			return true;
		}

		public bool RuleRowIsChecked()
		{
			Dictionary<int, int> dico = new Dictionary<int, int>();
			foreach (int i in CaseSudokuGrid.Possibility)
			{
				dico.Add(i, 0);
			}
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = 0; j < ColumnCount; j++)
				{
					int val = grid[i * ColumnCount + j].Value;
					if (val != 0)
					{
						dico[val]++;
						if (dico[val] > 1)
						{
							return false;
						}
					}
				}
				//int sum = 0;
				foreach (int k in CaseSudokuGrid.Possibility)
				{
					//sum += dico[k];
					dico[k] = 0;
				}
			}
			return true;
		}

		public bool RulesAreChecked()
		{
			return RuleRowIsChecked() && RuleColumnIsChecked() && RuleRegionIsChecked();
		}


		/// <summary>
		/// Supprime des possibilités de la ligne row la valeur
		/// value sauf s'il s'agit de "cases protégées" indexesProtected
		/// </summary>
		/// <param name="row"></param>
		/// <param name="value"></param>
		/// <param name="indexesProtected"></param>
		public int PropagateOnRow(int row, int value, IEnumerable<int> indexesProtected)
		{
			int countDeletedPossibilities = 0;
			int max = (row + 1) * ColumnCount;
			for (int i = max - ColumnCount; i < max; i++)
			{
				if (indexesProtected == null)
				{
					if (grid[i].DeletePossibility(value))
					{
						countDeletedPossibilities++;
					}
				}
				else
				{
					if (!indexesProtected.Contains(i))
					{
						if (grid[i].DeletePossibility(value))
						{
							countDeletedPossibilities++;
						}
					}
				}
			}
			return countDeletedPossibilities;
		}

		/// <summary>
		/// Supprime des possibilités de la colonne column la valeur
		/// value sauf s'il s'agit de "cases protégées" indexesProtected
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <param name="indexesProtected"></param>
		public int PropagateOnColumn(int column, int value, IEnumerable<int> indexesProtected)
		{
			int countDeletedPossibilities = 0;
			for (int i = column; i < Count; i += ColumnCount)
			{
				if (indexesProtected == null)
				{
					if (grid[i].DeletePossibility(value))
					{
						countDeletedPossibilities++;
					}
				}
				else
				{
					if (!indexesProtected.Contains(i))
					{
						if (grid[i].DeletePossibility(value))
						{
							countDeletedPossibilities++;
						}
					}
				}
			}
			return countDeletedPossibilities;
		}

		/// <summary>
		/// Supprime des possibilités de la region region la valeur
		/// value sauf s'il s'agit de "cases protégées" indexesProtected
		/// </summary>
		/// <param name="region"></param>
		/// <param name="value"></param>
		/// <param name="indexesProtected"></param>
		public int PropagateOnRegion(int region, int value, IEnumerable<int> indexesProtected)
		{
			int countDeletedPossibilities = 0;
			foreach (int i in regions[region])
			{
				if (indexesProtected == null)
				{
					if (grid[i].DeletePossibility(value))
					{
						countDeletedPossibilities++;
					}
				}
				else
				{
					if (!indexesProtected.Contains(i))
					{
						if (grid[i].DeletePossibility(value))
						{
							countDeletedPossibilities++;
						}
					}
				}
			}
			return countDeletedPossibilities;
		}

		public void Propagate(int row, int column, int region, int value)
		{
			PropagateOnRow(row, value, null);
			PropagateOnColumn(column, value, null);
			PropagateOnRegion(region, value, null);
			NbFound++;
		}
	}
}