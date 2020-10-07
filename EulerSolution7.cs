using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EulerProject
{
	[EulerProblemNumber(7)]
	[EulerSolutionDescription("")]
	public class EulerSolution7 : IEulerSolution
	{

		public void Driver()
		{
			Stopwatch sw = new Stopwatch();
			Console.WriteLine($"Running {this.GetType().Name}:");
			sw.Start();
			ulong answer = this.NthPrime(10001);
			sw.Stop();
			Console.WriteLine($"The answer is: {answer}");
			Console.WriteLine($"\nElapsed Seconds: {sw.Elapsed.TotalSeconds}");
		}


		public ulong NthPrime(int n)
		{
			List<ulong> primes = new List<ulong>() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37 };
			if (n <= primes.Count) return primes[n - 1];

			while (primes.Count < n)
			{
				primes.Add(NextPrime());
			}
			return primes[n - 1];

			ulong NextPrime()
			{
				ulong cur = primes[primes.Count - 1];
				while (true)
				{
					cur += 2;  //relies on the fact array has more than just '2' in it 
					int i;
					for (i = primes.Count - 1; i >= 0; --i)
					{
						if (cur % primes[i] == 0) break; //for
					}
					if (i == -1) break; //while 
				}
				return cur;
			}
		}

	}
}
