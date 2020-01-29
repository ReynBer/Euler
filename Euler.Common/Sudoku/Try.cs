namespace Euler.Common.Sudoku
{
    public class Try
    {
        public Case Case { get; private set; }
        public int Value { get; private set; }
        public int[] Grid { get; private set; }
        public Try(Case c, int v, int[] grid)
        {
            Case = c;
            Value = v;
            Grid = grid;
        }
    }
}
