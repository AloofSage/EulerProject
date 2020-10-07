using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EulerProject
{
	//this is the solution given by the Euler Project
	//for any numbers I've tried it's 1.5x to 3x slower
	//probably sensitive to the speed of Sqrt function
	[EulerProblemNumber(3)]
	[EulerSolutionDescription("Special case 2 and use square root check")]
	public class EulerSolution3Optimized : IEulerSolution
	{

		public void Driver()
		{
			Stopwatch sw = new Stopwatch();
			Console.WriteLine($"Running {this.GetType().Name}:");
			sw.Start();
			//ulong answer = this.BiggestPrime(2 * 49 * 1009);
			//ulong answer = this.BiggestPrime(3622049131122);
			ulong answer = this.BiggestPrime(600851475143);	  //official input
			sw.Stop();
			Console.WriteLine($"The answer is: {answer}");
			Console.WriteLine($"\nElapsed Seconds: {sw.Elapsed.TotalSeconds}");
		}

		public ulong BiggestPrime(ulong num)
		{
			ulong biggest;
			if (num % 2 == 0)
			{
				biggest = 2;
				num = num / 2;
				while (num % 2 == 0) { num = num / 2; }
			}
			else
			{
				biggest = 1;
			}

			ulong factor = 3;
			double max = Math.Sqrt(num);
			while (num > 1 && factor <= max)
			{
				if (num % factor == 0)
				{
					biggest = factor;
					num = num / factor;
					while (num % factor == 0) { num = num / factor; }
					max = Math.Sqrt(num);
				}
				factor += 2;
			}
			
			if (num == 1) { return biggest; }
			else { return num; }

		}
	}
}
