using System;
using System.Collections.Generic;

namespace Euler.Problems
{
	public class Problem96 : Problem
	{
		public override object Launch()
		{
			string[] splitted = new[] {"" };// Resource.sudoku.Split(new string[1] { "\r\n" }, StringSplitOptions.None);
			int i = 0;
			List<SudokuGrid> grids = new List<SudokuGrid>();
			List<SudokuGrid> gridsNoResolved = new List<SudokuGrid>();
			SudokuGrid sudokuGrid = null;
			foreach (string s in splitted)
			{
				if (s.StartsWith("Grid"))
				{
					if (sudokuGrid != null)
					{
						if (!sudokuGrid.IsResolved)
						{
							sudokuGrid.Solve();
							if (!(sudokuGrid.IsResolved && sudokuGrid.RulesAreChecked()))
							{
								gridsNoResolved.Add(sudokuGrid);
							}
						}
					}
					sudokuGrid = new SudokuGrid(s);
					grids.Add(sudokuGrid);
					i = 0;
				}
				else
				{
					sudokuGrid.AddRow(i++, s);
				}
			}

			if (!sudokuGrid.IsResolved)
			{
				sudokuGrid.Solve();
				if (!(sudokuGrid.IsResolved && sudokuGrid.RulesAreChecked()))
				{
					gridsNoResolved.Add(sudokuGrid);
				}
			}
			int sum = 0;
			foreach (SudokuGrid grid in grids)
			{
				sum += grid.Grid[0].Value * 100 + grid.Grid[1].Value * 10 + grid.Grid[2].Value;
			}
			foreach (SudokuGrid sudokuGrid1 in grids)
			{
				sudokuGrid1.PrintIt();
				Console.ReadKey();
			}
			Console.Out.WriteLine("sum = {0}", sum);
			Console.Out.WriteLine("Les non résolus !!!");
			Console.Out.WriteLine("Combien ? {0}", gridsNoResolved.Count);
			foreach (SudokuGrid sudokuGrid1 in gridsNoResolved)
			{
				sudokuGrid1.Solve();
				sudokuGrid1.PrintIt();
			}
			Console.ReadKey();
			return sum;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
