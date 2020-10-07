using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EulerProject
{
	[EulerProblemNumber(1)]
	[EulerSolutionDescription("Brute force")]
	public class EulerSolution1 : IEulerSolution
	{

		public void Driver()
		{
			Stopwatch sw = new Stopwatch();
			Console.WriteLine($"Running {this.GetType().Name}:");
			sw.Start();
			int answer = this.SumOfMultiples(1000);
			sw.Stop();
			Console.WriteLine($"The answer is: {answer}");
			Console.WriteLine($"\nElapsed Seconds: {sw.Elapsed.TotalSeconds}");
		}

		public int SumOfMultiples(int upperBound)
		{
			int sum = 0;
			for (int i = 1; i < upperBound; ++i)
			{
				if(i % 3 == 0 || i % 5 == 0)
				{
					sum += i;
				}
			}
			return sum;
		}

	}
}
