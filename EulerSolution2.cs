using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EulerProject
{
	[EulerProblemNumber(2)]
	[EulerSolutionDescription("Brute force")]
	public class EulerSolution2 : IEulerSolution
	{

		public void Driver()
		{
			Stopwatch sw = new Stopwatch();
			Console.WriteLine($"Running {this.GetType().Name}:");
			sw.Start();
			ulong answer = this.EvenFibonacci();
			sw.Stop();
			Console.WriteLine($"The answer is: {answer}");
			Console.WriteLine($"\nElapsed Seconds: {sw.Elapsed.TotalSeconds}");
		}

		public ulong EvenFibonacci()
		{
			long sum = 0;
			//every third Fibonacci number is even
			long odd1 = 0, odd2 = 1, even = 2;

			while (even < 4000000)
			{
				sum += even;
				odd1 = even + odd2;
				odd2 = odd1 + even;
				even = odd2 + odd1;
			}
			return (ulong)sum;
		}


	}
}
