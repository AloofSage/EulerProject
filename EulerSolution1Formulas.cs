using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EulerProject
{
	[EulerProblemNumber(1)]
	[EulerSolutionDescription("A solution using summation formulas")]
	public class EulerSolution1Formulas : IEulerSolution
	{

		public void Driver()
		{
			Stopwatch sw = new Stopwatch();
			Console.WriteLine($"Running {this.GetType().Name}:");
			sw.Start();
			//ulong answer = this.TheMethod();
			sw.Stop();
			//Console.WriteLine("The answer is: {answer}");
			ulong answer = this.SumOfMultiples(999);
			sw.Stop();
			Console.WriteLine($"The answer is: {answer}");
			Console.WriteLine($"\nElapsed Seconds: {sw.Elapsed.TotalSeconds}");
		}

		public ulong SumOfMultiples(uint upperBound)
		{
			return Helpers.SumDivisibleByN(3, upperBound) + Helpers.SumDivisibleByN(5, upperBound) - Helpers.SumDivisibleByN(15, upperBound);
		}
																	   
	}
}
