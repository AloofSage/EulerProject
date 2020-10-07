using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EulerProject
{
	[EulerProblemNumber(5)]
	[EulerSolutionDescription("Suggested solution using logarithm")]
	public class EulerSolution5Log : IEulerSolution
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

		public ulong SmallestMultiple(int upperBound)
		{
			List<int> primes = Helpers.GetPrimeList(upperBound);
			double logUpper = Math.Log(upperBound);
			double sqrtUpper = Math.Sqrt(upperBound);
			ulong smallestMult = 1;

			foreach (int item in primes)
			{
				int power = 1;
				if (item <= sqrtUpper )
				{
					power = (int)(logUpper / Math.Log(item));
				}
				smallestMult = smallestMult * (ulong)Math.Pow(item, power);
			}

			return smallestMult;
		}
	}
}

