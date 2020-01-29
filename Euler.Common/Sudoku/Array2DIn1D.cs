using System;
using System.Collections;
using System.Collections.Generic;

namespace Euler.Common.Sudoku
{
    public class Array2DIn1D<T> : IEnumerable<T>
    {
        protected T[] ArrayEncapsuled;
        protected int SizeRows;
        protected int SizeColumns;
        public int Length => ArrayEncapsuled.Length;

        public Array2DIn1D(int size) : this(size, size) { }

        public Array2DIn1D(int sizeRows, int sizeColumns)
        {
            SizeRows = sizeRows;
            SizeColumns = sizeColumns;
            ArrayEncapsuled = new T[SizeRows * SizeColumns];
        }

        public T this[int i]
        {
            get { return ArrayEncapsuled[i]; }
            set { ArrayEncapsuled[i] = value; }
        }

        public T GetValue(int row, int column)
        {
            return ArrayEncapsuled[row * column];
        }

        public T GetValue(int index)
        {
            if (index < 0 || index > SizeColumns * SizeRows) throw new ArgumentException("");
            return ArrayEncapsuled[index];
        }

        public void SetValue(T value, int row, int column)
        {
            ArrayEncapsuled[row * column] = value;
        }

        public void SetValue(T value, int index)
        {
            if (index < 0 || index > SizeColumns * SizeRows) throw new ArgumentException("");
            ArrayEncapsuled[index] = value;
        }

        public void SetRowValues(T[] values, int indexRow)
        {
            if (indexRow < 0 || indexRow >= SizeColumns) throw new ArgumentException("");
            if (values.Length != SizeRows) throw new ArgumentException("");
            var start = indexRow * SizeColumns;
            var end = start + SizeColumns;
            var j = 0;
            for (var i = start; i < end; i++)
                ArrayEncapsuled[i] = values[j++];
        }

        public void SetColumnValues(T[] values, int indexColumn)
        {
            if (indexColumn < 0 || indexColumn >= SizeRows) throw new ArgumentException("");
            if (values.Length != SizeColumns) throw new ArgumentException("");
            var start = indexColumn;
            var end = start + SizeRows * (SizeColumns - 1);
            var j = 0;
            for (var i = start; i < end; i += SizeRows)
                ArrayEncapsuled[i] = values[j++];
        }

        public void SetAllValues(T[] values)
        {
            if (values.Length != SizeColumns * SizeRows) throw new ArgumentException("");
            var end = SizeColumns * SizeRows;
            for (var i = 0; i < end; i++)
                ArrayEncapsuled[i] = values[i];
        }

        public IEnumerable<T> GetRow(int indexRow)
        {
            if (indexRow < 0 || indexRow >= SizeColumns) throw new ArgumentException("");
            var start = indexRow * SizeColumns;
            var end = start + SizeColumns;
            for (var i = start; i < end; i++)
                yield return ArrayEncapsuled[i];
        }

        public IEnumerable<T> GetColumn(int indexColumn)
        {
            if (indexColumn < 0 || indexColumn >= SizeRows) throw new ArgumentException("");
            var start = indexColumn;
            var end = start + SizeRows * SizeColumns;
            for (var i = start; i < end; i += SizeRows)
                yield return ArrayEncapsuled[i];
        }

        public IEnumerable<T> Values => ArrayEncapsuled;

        public IEnumerator<T> GetEnumerator()
        {
            return (ArrayEncapsuled as IEnumerable<T>).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ArrayEncapsuled.GetEnumerator();
        }
    }
}
