using System;
using System.Collections.Generic;
using System.Text;

namespace Euler.Problems
{
	public class CaseSudokuGrid
	{
		public int Row { get; set; }
		public int Column { get; set; }
		public int Region { get; set; }
		public delegate void PropagateEventHanlder(int row, int column, int region, int value);
		public event PropagateEventHanlder OnPropagation;

		public CaseSudokuGrid(int row, int column, int region)
		{
			Row = row;
			Column = column;
			Region = region;
			_Possibilities = new List<int>();
			foreach (int i in Possibility)
			{
				_Possibilities.Add(i);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="method"></param>
		public void AddListener(PropagateEventHanlder method)
		{
			OnPropagation += new PropagateEventHanlder(method);
		}

		private int _Value = 0;
		public int Value
		{
			get { return _Value; }
			set {
				if (value != 0 && _Value == 0)
				{
					_Value = value;
					_Possibilities.Clear();
					if (OnPropagation != null)
					{
						OnPropagation(Row, Column, Region, value);
					}
				}
			}
		}

		public static int[] Possibility = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

		private List<int> _Possibilities;
		public List<int> Possibilities
		{
			get { return _Possibilities; }
		}

		public bool DeletePossibility(int value)
		{
			bool v = _Possibilities.Remove(value);
			if (_Possibilities.Count == 1)
			{
				Value = _Possibilities[0];
			}
			return v;
		}
	}
}
