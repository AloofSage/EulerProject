using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EulerProject
{
	[EulerProblemNumber(3)]
	[EulerSolutionDescription("Brute force reduction by division")]
	public class EulerSolution3 : IEulerSolution
	{

		public void Driver()
		{
			Stopwatch sw = new Stopwatch();
			Console.WriteLine($"Running {this.GetType().Name}:");
			sw.Start();
			//ulong answer = this.BiggestPrime(2*49*1009);
			//ulong answer = this.BiggestPrime(3622049131122);
			ulong answer = this.BiggestPrime(600851475143);	 //official input
			sw.Stop();
			Console.WriteLine($"The answer is: {answer}");
			Console.WriteLine($"\nElapsed Seconds: {sw.Elapsed.TotalSeconds}");
		}

		public ulong BiggestPrime(ulong num)
		{
			ulong prime = 2;
			while (true)
			{
				if (prime == num) return prime;
				if (num % prime == 0) num = num / prime;
				else ++prime;
			}
		}

	}
}
