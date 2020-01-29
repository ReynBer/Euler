using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Common.Sudoku
{
    public class Case : List<int>
    {
        public int Index { get; }
        public int[] Regions { get; set; }
        private int? _value;
        public event EventHandler PropagateOnRegions;

        public Case(IEnumerable<int> possibilities, int index)
        {
            Index = index;
            Regions = new int[SudokuHelper.GetRegionsType.Count()];
            ResetValue(possibilities);
        }

        public void ResetValue(IEnumerable<int> possibilities)
        {
            Clear();
            AddRange(possibilities);
            _value = null;
        }

        public bool HasValue => _value.HasValue;

        public int Value
        {
            get { return _value ?? 0; }
            set
            {
                if (value == 0) return;
                if (_value == value) return;
                _value = value;
                Clear();
                if (PropagateOnRegions == null)
                    return;
                PropagateOnRegions(this, null);
            }
        }

        public new bool Remove(int item)
        {
            if (!base.Remove(item)) return false;
            if (Count == 1)
                Value = this[0];
            return true;
        }

        public override string ToString()
        {
            return _value?.ToString() ?? "0";
        }

        public bool IsOnSameRow(Case c)
        {
            return IsOnSameRegion(c, RegionType.Row);
        }

        public bool IsOnSameColumn(Case c)
        {
            return IsOnSameRegion(c, RegionType.Column);
        }

        public bool IsOnSameSquare(Case c)
        {
            return IsOnSameRegion(c, RegionType.Square);
        }

        private bool IsOnSameRegion(Case c, RegionType regionType)
            => Regions[(int)regionType] == c.Regions[(int)regionType];

        public bool HasSamePossibilities(Case c)
        {
            if (c.Count != Count)
                return false;
            var cptFound = c.Count;
            // ReSharper disable once UnusedVariable
            foreach (var p1 in this.Where(p1 => c.Any(p2 => p1 == p2)))
                cptFound--;
            return cptFound == 0;
        }
    }
}
