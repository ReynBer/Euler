using System.Collections.Generic;
using System.Linq;

namespace Euler.Common.Sudoku
{
    public class Solver
    {
        public void Run(Grid sudoku)
        {
            sudoku.AllValues = sudoku.AllValues;

            if (sudoku.IsOver)
                return;
            var tries = new Stack<Try>();
            do
            {
                do
                {
                    if (sudoku.IsOverAndOk)
                        return;
                    if (sudoku.IsOver)
                        continue;
                    var @case = sudoku.Values.First(c => !c.HasValue);
                    tries.Push(new Try(@case, @case[0], sudoku.AllValues));
                    @case.Value = @case[0];
                } while (sudoku.IsOk);
                if (tries.Count == 0)
                    continue;
                var thisTry = tries.Pop();
                sudoku.AllValues = thisTry.Grid;
                while (thisTry.Case.Count > 0 && thisTry.Case[0] <= thisTry.Value)
                    thisTry.Case.Remove(thisTry.Case[0]);
            } while (!sudoku.IsOverAndOk);
        }
    }
}
