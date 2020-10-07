using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EulerProject
{
	[EulerProblemNumber(5)]
	[EulerSolutionDescription("")]
	public class EulerSolution5 : IEulerSolution
	{

		public void Driver()
		{
			Stopwatch sw = new Stopwatch();
			Console.WriteLine($"Running {this.GetType().Name}:");
			sw.Start();
			ulong answer = this.SmallestMultiple(20);
			sw.Stop();
			Console.WriteLine($"The answer is: {answer}");
			Console.WriteLine($"\nElapsed Seconds: {sw.Elapsed.TotalSeconds}");
		}

		public ulong SmallestMultiple(uint upperBound)
		{
			ulong num = upperBound;
			while (true)
			{
				uint i;
				for (i = upperBound; i > 1; --i)
				{
					if (!(num % i == 0)) break;
				}
				if (i == 1) return num;
				num += upperBound;
			}
		}

	}
}
