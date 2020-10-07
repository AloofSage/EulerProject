using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;

namespace EulerProject
{
	[EulerProblemNumber(5)]
	[EulerSolutionDescription("")]
	public class EulerSolution5PrimeFactors : IEulerSolution
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
			Dictionary<int, int> primeDict = Helpers.GetPrimeDictionary(upperBound);

			for (int i = 2; i <= upperBound; ++i)
			{
				int num = i;
				foreach (var item in primeDict)
				{
					if (num % item.Key == 0)
					{
						int count = 1;
						num = num / item.Key;
						while (num % item.Key == 0)
						{
							++count;
							num = num / item.Key;
						}
						if (count > item.Value) { primeDict[item.Key] = count; }
					}
					if (num == 1) break;
				}
			}

			int answer = primeDict.Aggregate(1, (total, item) => (int)(total * Math.Pow(item.Key, item.Value)));
			return (ulong)answer;

		}

	}
}
