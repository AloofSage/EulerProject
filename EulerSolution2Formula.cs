using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EulerProject
{
	[EulerProblemNumber(2)]
	[EulerSolutionDescription("Even number recursive definition")]
	public class EulerSolution2Formula : IEulerSolution
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

		
		/// <summary>
		/// Combines the facts that every third number is even in the full sequence
		/// and that the formula F(n) = 4 * F(n-3) + F(n-6) holds for the full sequence.
		/// That means that looking at a sequence of just the even numbers
		/// E(n) = 4 * E(n-1) + E(n-2) holds.
		/// </summary>
		public ulong EvenFibonacci()
		{
			long lastEven2 = 2;
			long lastEven1 = 8;
			long sum = lastEven1 + lastEven2;
			long currEven = 34;
			while (currEven < 4000000)
			{
				sum += currEven;
				lastEven2 = lastEven1;
				lastEven1 = currEven;
				currEven = 4 * lastEven1 + lastEven2;
			}
			return (ulong)sum;
		}

	}
}
