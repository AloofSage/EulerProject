using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EulerProject
{
	[EulerProblemNumber(6)]
	[EulerSolutionDescription("")]
	public class EulerSolution6 : IEulerSolution
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
			ulong sum = 0, sumSq = 0;
			for (uint i = 1; i <= upperBound; ++i)
			{
				sum += i;
				sumSq += i * i;
			}
			return (sum * sum) - sumSq;
		}

	}
}
