using System;
using System.Collections.Generic;
using System.Text;

namespace EulerProject
{
	public static class Helpers
	{
		public static ulong Sum1ToN(uint n)
		{
			return n * (n + 1) / 2;
		}

		//range is inclusive of max
		public static ulong SumDivisibleByN(uint n, uint max)
		{
			uint numItems = max / n;
			return Sum1ToN(numItems) * n;
		}

		public static ulong SumSquares1ToN(ulong n)
		{
			
			return (ulong)(n * (2*n + 1) * (n + 1) / 6);
		}
		
		
		public static bool[] GetPrimeSieve(int max)
		{
			bool[] primes = new bool[max+1];
			for (int i = 2; i < primes.Length; ++i) { primes[i] = true; }
			
			for (int i = 2; i * i <= max; ++i)
			{
				if (primes[i] == true)
				{
					for (int j = i * i; j < primes.Length; j += i)
					{
						primes[j] = false;
					}
				}
			}

			return primes;
		}

		public static List<int> GetPrimeList(int max)
		{
			bool[] arr = GetPrimeSieve(max);
			List<int> list = new List<int>(1000); 
			for (int i = 0; i < arr.Length; ++i)
			{
				if (arr[i] == true) list.Add(i);
			}
			return list;
		}

		public static Dictionary<int, int> GetPrimeDictionary(int max)
		{
			bool[] arr = GetPrimeSieve(max);
			Dictionary<int, int> dict = new Dictionary<int, int>(1000);
			for (int i = 0; i < arr.Length; ++i)
			{
				if (arr[i] == true) dict.Add(i,0);
			}
			return dict;
		}


	}
}
