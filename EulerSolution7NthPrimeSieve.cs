using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EulerProject
{
	[EulerProblemNumber(7)]
	[EulerSolutionDescription("Uses a prime sieve. Wont work for primes large than 1 million.")]
	public class EulerSolution7NthPrimeSieve : IEulerSolution
	{

		public void Driver()
		{
			Stopwatch sw = new Stopwatch();
			Console.WriteLine($"Running {this.GetType().Name}:");
			sw.Start();
			ulong answer = this.NthPrimeSieve(10001);
			sw.Stop();
			Console.WriteLine($"The answer is: {answer}");
			Console.WriteLine($"\nElapsed Seconds: {sw.Elapsed.TotalSeconds}");
		}


		public ulong NthPrimeSieve(int n)
		{
			bool[] sieve = Helpers.GetPrimeSieve(1000000);
			int primeCount = 0;
			for (int i = 0; i < sieve.Length; ++i)
			{
				if (sieve[i])
				{
					if (++primeCount == n) return (ulong)i;
				}
			}
			return 0;
		}

	}
}
