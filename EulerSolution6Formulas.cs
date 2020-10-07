using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EulerProject
{
	[EulerProblemNumber(6)]
	[EulerSolutionDescription("Use formaulas instead of brute force")]
	public class EulerSolution6Formulas : IEulerSolution
	{

		public void Driver()
		{
			Stopwatch sw = new Stopwatch();
			Console.WriteLine($"Running {this.GetType().Name}:");
			sw.Start();
			ulong answer = this.SumSquareDiff(7000);
			sw.Stop();
			Console.WriteLine($"The answer is: {answer}");
			Console.WriteLine($"\nElapsed Seconds: {sw.Elapsed.TotalSeconds}");
		}

		public ulong SumSquareDiff(int upperBound)
		{
			ulong sum = Helpers.Sum1ToN((uint)upperBound);
			return (sum * sum) - Helpers.SumSquares1ToN((ulong)upperBound);
		}

	}
}
