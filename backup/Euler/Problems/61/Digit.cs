using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems
{
	public class Digit
	{
		private int _Value;
		private string _First2Digits;
		private string _Last2Digits;

		public int Value { get { return _Value; } }
		public string First2Digits { get { return _First2Digits; } }
		public string Last2Digits { get { return _Last2Digits; } }
        public List<Digit> ListDigitStepN { get; set; }
		public List<Digit> ListDigitPolygon { get; set; }

		public Digit(int value)
		{
			_Value = value;
			string temp = value.ToString();
			_First2Digits = temp.Substring(0, 2);
			_Last2Digits = temp.Substring(temp.Length - 2, 2);
		}
	}
}
