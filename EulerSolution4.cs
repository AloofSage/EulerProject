using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EulerProject
{
	[EulerProblemNumber(4)]
	[EulerSolutionDescription("")]
	public class EulerSolution4 : IEulerSolution
	{

		public void Driver()
		{
			Stopwatch sw = new Stopwatch();
			Console.WriteLine($"Running {this.GetType().Name}:");
			sw.Start();
			long answer = this.BiggestPalindrome(3);
			sw.Stop();
			Console.WriteLine($"The answer is: {answer}");
			Console.WriteLine($"\nElapsed Seconds: {sw.Elapsed.TotalSeconds}");
		}

		public long BiggestPalindrome(int digits)
		{
			int upperbound = (int)Math.Pow(10, digits) - 1;
			int lowerbound = (int)Math.Pow(10, digits - 1) - 1;
			long biggest = 0;
			int smallestj = 0;

			for (int i = upperbound; i > lowerbound; --i)
			{
				if (i < smallestj) break;
				for (int j = upperbound; j > lowerbound; --j)
				{
					long prod = i * j;
					if (prod <= biggest)
					{
						break;
					}
					string s = prod.ToString();
					char[] rev = new char[s.Length];
					for (int k = s.Length - 1, r =0; k >= 0; --k, ++r)
					{ rev[r] = s[k]; }
					if (s == new string(rev))
					{
						biggest = prod;
						smallestj = j;
						break;
					}
				}
			}
			return biggest;
		}
	}
}
