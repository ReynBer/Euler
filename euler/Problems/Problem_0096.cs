using Euler.Common;
using Euler.Common.Sudoku;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Euler.Problems
{
    public class Problem_0096 : CommandBase<int>
    {
        //private readonly int _digitsCount;
        private readonly List<Grid> sudokus = new List<Grid>(50);
        public Problem_0096(string filePath)
        {
            using (var sr = new StreamReader(filePath))
            {
                Grid sudoku = null;
                var indexRow = 0;
                while (!sr.EndOfStream)
                {

                    var row = sr.ReadLine();
                    if (row.StartsWith("Grid"))
                    {
                        sudoku = null;
                        indexRow = 0;
                        continue;
                    }
                    if (sudoku == null && indexRow == 0)
                    {
                        sudoku = Grid.Create(row.Length);
                        sudokus.Add(sudoku);
                    }
                    // ReSharper disable once UseNullPropagation
                    if (sudoku == null)
                        continue;
                    sudoku.SetRow(row, indexRow++);
                }
            }
        }

        public override ICommand<int> Run()
        {
            Result = 0;
            var solver = new Solver();
            foreach (var s in sudokus)
            {
                solver.Run(s);
                Result += s.Take(3).Select((c, index) => c.Value * (int)Math.Pow(10, 2 - index)).Sum();
            }

            return this;
        }
    }
}
