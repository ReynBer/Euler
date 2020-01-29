using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Euler.Common.Sudoku
{
    public class Grid : Array2DIn1D<Case>
    {
        public void ResetValues()
        {
            EnabledPropagation = false;
            for (int i = 0; i < AllValues.Length; i++)
                this[i].ResetValue(SudokuHelper.DefaultPossibilities(Size));
        }

        public int[] AllValues
        {
            get
            {
                var result = new int[Length];
                for (int i = 0; i < Length; i++)
                {
                    result[i] = this[i].Value;
                }
                return result;
            }
            set
            {
                ResetValues();
                EnabledPropagation = true;
                for (int i = 0; i < value.Length; i++)
                {
                    this[i].Value = value[i];
                }
            }
        }

        public bool IsOver
        {
            get { return Values.Count(c => c.HasValue) == Length; }
        }

        public bool IsOverAndOk => IsOver && IsOk;

        public bool AreThereChanges { get; set; }

        public bool IsOk
        {
            get
            {
                foreach (var regionType in SudokuHelper.GetRegionsType)
                {
                    for (int i = 0; i < Size; i++)
                    {
                        var values = new bool[Size];
                        foreach (var index in GetRegion(regionType, i).Select(v => v.Value))
                        {
                            if (index == 0)
                                continue;//pas une erreur juste une grille incomplete
                            int j = index - 1;
                            if (values[j])
                                return false;//doublon
                            values[j] = true;
                        }
                    }
                }
                return true;
            }
        }

        //public void PrintWhereIsNotOk()
        //{
        //    var sb = ToPrintWhereIsNotOk();
        //    Console.Write(sb);
        //}

        //public string ToPrintWhereIsNotOk()
        //{
        //    var sb = new StringBuilder();
        //    foreach (var regionType in SudokuHelper.GetRegionsType)
        //    {
        //        for (int i = 0; i < Size; i++)
        //        {
        //            var values = new bool[Size];
        //            foreach (var index in GetRegion(regionType, i).Select(v => v.Value))
        //            {
        //                int j = index - 1;
        //                if (j < 0) continue;

        //                if (values[j])
        //                {
        //                    sb.AppendFormat("{0}({1}) -> {2}", regionType, i, index);
        //                    sb.AppendLine();
        //                }
        //                values[j] = true;
        //            }
        //        }
        //    }
        //    return sb.ToString();
        //}

        /// <summary>
        /// Gets or sets a value indicating whether [enabled propagation].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enabled propagation]; otherwise, <c>false</c>.
        /// </value>
        public bool EnabledPropagation { get; set; }

        /// <summary>
        /// Gets the size.
        /// </summary>
        public int Size => SizeRows;

        /// <summary>
        /// Gets the size root square.
        /// </summary>
        public int SizeRootSquare { get; }

        /// <summary>
        /// Gets the default possibilities.
        /// </summary>
        public List<int> DefaultPossibilities { get; }

        /// <summary>
        /// Prevents a default instance of the <see cref="Grid"/> class from being created.
        /// </summary>
        /// <param name="size">The size.</param>
        private Grid(int size)
            : base(size)
        {
            SizeRootSquare = (int)Math.Sqrt(size);
            DefaultPossibilities = SudokuHelper.DefaultPossibilities(size).ToList();
        }

        /// <summary>
        /// Creates the specified size.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static Grid Create(int size)
        {
            return new Grid(size);
        }

        /// <summary>
        /// Gets the index square.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="col">The col.</param>
        /// <returns></returns>
        public int GetIndexSquare(int row, int col)
        {
            var rowBis = row / SizeRootSquare;
            var colBis = col / SizeRootSquare;
            return rowBis * SizeRootSquare + colBis;
        }

        /// <summary>
        /// Sets the row.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="indexRow">The index row.</param>
        public void SetRow(string row, int indexRow)
        {
            var rowConverted = new Case[row.Length];
            for (var i = 0; i < row.Length; i++)
            {
                rowConverted[i] = new Case(SudokuHelper.DefaultPossibilities(row.Length), indexRow * SizeColumns + i)
                {
                    Regions =
                    {
                        [(int)RegionType.Column] = i,
                        [(int)RegionType.Row] = indexRow,
                        [(int)RegionType.Square] = GetIndexSquare(indexRow, i)
                    },
                    Value = int.Parse("" + row[i], NumberStyles.Any, null)
                };
                rowConverted[i].PropagateOnRegions += Propagate;
            }
            SetRowValues(rowConverted, indexRow);
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="index">The index.</param>
        public void SetValue(int value, int index)
        {
            if (index < 0 || index > SizeColumns * SizeRows) 
                throw new Exception("");
            ArrayEncapsuled[index].Value = value;
        }

        /// <summary>
        /// Propagates the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void Propagate(object sender, EventArgs args)
        {
            if (!EnabledPropagation) 
                return;
            var caseSudoku = sender as Case;
            if (caseSudoku == null)
                return;
            //ValuesFound++;
            if (!AreThereChanges) 
                AreThereChanges = true;
            foreach (var region in SudokuHelper.GetRegionsType)
            {
                foreach (var c in GetRegion(region, caseSudoku.Regions[(int)region]))
                {
                    c.Remove(caseSudoku.Value);
                }
            }
        }

        /// <summary>
        /// Gets the region.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public IEnumerable<Case> GetRegion(RegionType region, int index)
        {
            switch (region)
            {
                case RegionType.Row:
                    return GetRow(index);
                case RegionType.Column:
                    return GetColumn(index);
                default:
                    return GetSquare(index);
            }
        }

        /// <summary>
        /// Gets the possibilities from region.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public Dictionary<int, List<Case>> GetPossibilitiesFromRegion(RegionType region, int index)
        {
            var possibilities = new Dictionary<int, List<Case>>();
            foreach (var c in GetRegion(region, index))
            {
                foreach (var i in c)
                {
                    if (!possibilities.ContainsKey(i)) 
                        possibilities[i] = new List<Case>(Size);
                    possibilities[i].Add(c);
                }
            }
            return possibilities;
        }

        /// <summary>
        /// Gets the square.
        /// </summary>
        /// <param name="indexSquare">The index square.</param>
        /// <returns></returns>
        public IEnumerable<Case> GetSquare(int indexSquare)
        {
            int mod;
            var d = Math.DivRem(indexSquare, SizeRootSquare, out mod);
            var start = SizeRootSquare * (d * SizeRows + mod);
            for (var i = 0; i < SizeRootSquare; i++)
            {
                var indexRow = i * SizeRows;
                for (var j = 0; j < SizeRootSquare; j++)
                    yield return ArrayEncapsuled[start + j + indexRow];
            }
        }

        /// <summary>
        /// Prints this instance.
        /// </summary>
        public void Print()
        {
            var sb = ToPrint();
            Console.WriteLine(sb);
        }

        public string ToPrint()
        {
            var sb = new StringBuilder();
            var j = 0;
            foreach (var i in this)
            {
                sb.Append(i);
                if (++j != SizeRows) 
                    continue;
                sb.AppendLine();
                j = 0;
            }
            sb.AppendLine();
            sb.AppendLine();
            return sb.ToString();
        }

        ///// <summary>
        ///// Prints the possibilities.
        ///// </summary>
        //public void PrintPossibilities()
        //{
        //    var sb = ToPrintPossibilities();
        //    Console.WriteLine(sb);
        //}

        //public string ToPrintPossibilities()
        //{
        //    var sb = new StringBuilder();
        //    for (int indexRow = 0; indexRow < SizeRows; indexRow++)
        //    {
        //        var rows = new string[SizeRootSquare];
        //        foreach (var c in GetRow(indexRow))
        //        {
        //            int l = 0;
        //            for (int k = 0; k < DefaultPossibilities.Count; k++)
        //            {
        //                if (k != 0 && k % SizeRootSquare == 0)
        //                {
        //                    rows[l++] += "|";
        //                }
        //                int t = k + 1;
        //                if (c.Contains(t))
        //                {
        //                    rows[l] += t.ToString();
        //                    continue;
        //                }
        //                rows[l] += " ";
        //            }
        //            rows[l] += "|";
        //        }
        //        for (var i = 0; i < SizeRootSquare; i++)
        //        {
        //            rows[i] = "|" + rows[i];
        //            sb.AppendLine(rows[i]);
        //        }
        //        foreach (var row in rows[0])
        //        {
        //            sb.Append("*");
        //        }
        //        sb.AppendLine();
        //    }
        //    return sb.ToString();
        //}

        ///// <summary>
        ///// Deletes the possibilities.
        ///// </summary>
        ///// <param name="value">The value.</param>
        ///// <param name="regionType">Type of the region.</param>
        ///// <param name="regionIndex">Index of the region.</param>
        ///// <param name="regionTypeException">The region type exception.</param>
        ///// <param name="regionIndexException">The region index exception.</param>
        //public void DeletePossibilities(int value, RegionType regionType, int regionIndex, RegionType regionTypeException, int regionIndexException)
        //{
        //    foreach (var c in GetRegion(regionType, regionIndex))
        //    {
        //        if (c.Regions[(int)regionTypeException] == regionIndexException) continue;
        //        c.Remove(value);
        //    }
        //}
    }
}
