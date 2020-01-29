using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Common.Sudoku
{
    public static class SudokuHelper
    {
        public static IEnumerable<RegionType> GetRegionsType
            => Enum.GetValues(typeof(RegionType)).Cast<RegionType>();

        public static IEnumerable<int> DefaultPossibilities(int size)
        {
            for (var i = 1; i <= size; i++)
                yield return i;
        }
    }
}
