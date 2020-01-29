using System;

namespace euler
{
    class Program
    {
        static void Main(string[] args)
        {
            //var result = new Euler.Problems.Problem_0001(999).Run().Result;
            //var result = new Euler.Problems.Problem_0002(4000000L).Run().Result;
            //var result = new Euler.Problems.Problem_0003(600851475143L).Run().Result;
            //var result = new Euler.Problems.Problem_0004(3).Run().Result;
            var result = new Euler.Problems.Problem_0096("sudoku.txt").Run().Result;

            Console.WriteLine(result);
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
