using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EulerProject
{
	class Program
	{
		static void Main(string[] args)
		{
			////"73167176531330624919225119674426574742355349194934" +
			//string digits =
			//	"73167176531330624919225119674426574742355349194934" +
			//	"96983520312774506326239578318016984801869478851843" +
			//	"85861560789112949495459501737958331952853208805511" +
			//	"12540698747158523863050715693290963295227443043557" +
			//	"66896648950445244523161731856403098711121722383113" +
			//	"62229893423380308135336276614282806444486645238749" +
			//	"30358907296290491560440772390713810515859307960866" +
			//	"70172427121883998797908792274921901699720888093776" +
			//	"65727333001053367881220235421809751254540594752243" +
			//	"52584907711670556013604839586446706324415722155397" +
			//	"53697817977846174064955149290862569321978468622482" +
			//	"83972241375657056057490261407972968652414535100474" +
			//	"82166370484403199890008895243450658541227588666881" +
			//	"16427171479924442928230863465674813919123162824586" +
			//	"17866458359124566529476545682848912883142607690042" +
			//	"24219022671055626321111109370544217506941658960408" +
			//	"07198403850962455444362981230987879927244284909188" +
			//	"84580156166097919133875499200524063689912560717606" +
			//	"05886116467109405077541002256983155200055935729725" +
			//	"71636269561882670428252483600823257530420752963450";
			//int num = 13;
			//Console.WriteLine($"LargestProduct for: {num} digits in:\n{digits} \n\nis: {LargestProduct(digits, num)}");

			//uint num = 2000000;
			//Console.WriteLine($"SumPrimes below {num}: {SumPrimes(num)}");

			//Console.WriteLine(LargestProduct().ToString());

			//Console.WriteLine(HighlyDivisibleTriangle());

			IEulerSolution solution = new EulerSolution7();
			solution.Driver();
			Console.WriteLine("---------------------------");
			solution = new EulerSolution7NthPrimeSieve();
			solution.Driver();
			Console.WriteLine("---------------------------");

			//solution = new EulerSolution6Formulas();
			//solution.Driver();
			//Console.WriteLine("---------------------------");
			//solution = new EulerSolution5Log();
			//solution.Driver();
			//Console.WriteLine("---------------------------");

			_ = Console.ReadKey();
		}

		static ulong SumPrimes(uint upperBound)
		{
			bool[] isprime = new bool[upperBound];
			for(int i =0; i< isprime.Length; ++i)
			{ isprime[i] = true; }
			//uint loopBound = (uint)Math.Floor(Math.Sqrt(upperBound));
			ulong sum = 0;
			for (uint i = 2; i < isprime.Length; ++i)
			{
				if (isprime[i] == false) continue;
				sum += i;
				ulong check = i * i;
				for (uint j = i*2; j < isprime.Length; j += i)
				{
					isprime[j] = false;
				}
				//while (check < upperBound)
				//{
				//	notprime[check] = true;
				//	check += i;
				//}
				//if (i > 2) ++i;
			}
			
			//for (uint j = 2; j < upperBound; ++j) { if (notprime[j] == false) sum += j; }
			return sum;
		}
		
		static uint SpecialPythagoreanTriple()
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();
			for (int c = 997; c > 2; --c)
			{
				for (int b = 1000 - c - 1; b > 1; --b)
				{
					for (int a = 1000 -b -c; a > 0; --a)
					{
						if (a + b + c != 1000) continue;
						if ((a * a ) + (b * b) == (c * c))
						{
							Console.WriteLine($"a: {a} b: {b} c: {c}");
							sw.Stop();
							Console.WriteLine($"{sw.ElapsedMilliseconds}");
							return (uint)(a * b * c);
						}
					}
				}
			}
			return 0;
		}
		

		static uint SpecialTriple2()
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();
			int n = 1, m = 2;
			int a=0, b=0, c=0;
			//int sum;
			while (a + b + c != 1000)
			{
				a = m * m - n * n;
				b = 2 * m * n;
				c = m * m + n * n;

				n++;
				if (n == m)
				{
					n = 1;
					m++;
				}
			}
			sw.Stop();
			Console.WriteLine($"{sw.ElapsedMilliseconds}");
			return (uint)(a * b * c);
		}

		//numFactors is the number of digits to multiply together
		static ulong LargestProduct (string digits, int numFactors)
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();
			ulong biggest = 0, product;
			List<uint> sequence = new List<uint>(numFactors + 1);

			for (int i = 0; i < digits.Length; ++i)
			{
				sequence.Add(UInt32.Parse(digits[i].ToString()));
				if (sequence.Count >= numFactors)
				{
					if (sequence.Count > numFactors ) sequence.RemoveAt(0);

					product = 1;
					int j;
					bool skip = false;
					for (j = sequence.Count - 1; j >= 0; --j)
					{
						uint cur = sequence[j];
						if (cur == 0)
						{
							sequence.RemoveRange(0, j + 1);
							skip = true;
							break; //for j
						}
						product *= cur;
					}
					if (skip) continue; //for i
					if (product > biggest) biggest = product;
				}
			}
			sw.Stop();
			Console.WriteLine($"{sw.ElapsedMilliseconds}");
			return biggest;
		}
		
		
		
		
		static ulong FindPrime(int which)
		{
			List<ulong> primes = new List<ulong>() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37 };
			if (which <= primes.Count) return primes[which - 1];

			while (primes.Count < which)
			{
				primes.Add(NextPrime());
			}
			return primes[which -1];

			ulong NextPrime()
			{
				ulong cur = primes[primes.Count - 1];
				while(true)
				{
					cur += 2;  //relies on the fact array has more than just '2' in it 
					int i;
					for (i = primes.Count -1; i >= 0; --i)
					{
						if (cur % primes[i] == 0) break; //for
					}
					if (i == -1) break; //while 
				}
				return cur;
			}
		}
		


		static ulong BiggestPrime(ulong num)
		{
			ulong prime = 2;
			while (true)
			{
				if (prime == num) return prime;
				if (num % prime == 0) num = num / prime;
				else ++prime;
			}
		}



		


		static int LargestProduct()
		{
			int[] arr = new int[400] {  08, 02, 22, 97, 38, 15, 00, 40, 00, 75, 04, 05, 07, 78, 52, 12, 50, 77, 91, 08,
										49, 49, 99, 40, 17, 81, 18, 57, 60, 87, 17, 40, 98, 43, 69, 48, 04, 56, 62, 00,
										81, 49, 31, 73, 55, 79, 14, 29, 93, 71, 40, 67, 53, 88, 30, 03, 49, 13, 36, 65,
										52, 70, 95, 23, 04, 60, 11, 42, 69, 24, 68, 56, 01, 32, 56, 71, 37, 02, 36, 91,
										22, 31, 16, 71, 51, 67, 63, 89, 41, 92, 36, 54, 22, 40, 40, 28, 66, 33, 13, 80,
										24, 47, 32, 60, 99, 03, 45, 02, 44, 75, 33, 53, 78, 36, 84, 20, 35, 17, 12, 50,
										32, 98, 81, 28, 64, 23, 67, 10, 26, 38, 40, 67, 59, 54, 70, 66, 18, 38, 64, 70,
										67, 26, 20, 68, 02, 62, 12, 20, 95, 63, 94, 39, 63, 08, 40, 91, 66, 49, 94, 21,
										24, 55, 58, 05, 66, 73, 99, 26, 97, 17, 78, 78, 96, 83, 14, 88, 34, 89, 63, 72,
										21, 36, 23, 09, 75, 00, 76, 44, 20, 45, 35, 14, 00, 61, 33, 97, 34, 31, 33, 95,
										78, 17, 53, 28, 22, 75, 31, 67, 15, 94, 03, 80, 04, 62, 16, 14, 09, 53, 56, 92,
										16, 39, 05, 42, 96, 35, 31, 47, 55, 58, 88, 24, 00, 17, 54, 24, 36, 29, 85, 57,
										86, 56, 00, 48, 35, 71, 89, 07, 05, 44, 44, 37, 44, 60, 21, 58, 51, 54, 17, 58,
										19, 80, 81, 68, 05, 94, 47, 69, 28, 73, 92, 13, 86, 52, 17, 77, 04, 89, 55, 40,
										04, 52, 08, 83, 97, 35, 99, 16, 07, 97, 57, 32, 16, 26, 26, 79, 33, 27, 98, 66,
										88, 36, 68, 87, 57, 62, 20, 72, 03, 46, 33, 67, 46, 55, 12, 32, 63, 93, 53, 69,
										04, 42, 16, 73, 38, 25, 39, 11, 24, 94, 72, 18, 08, 46, 29, 32, 40, 62, 76, 36,
										20, 69, 36, 41, 72, 30, 23, 88, 34, 62, 99, 69, 82, 67, 59, 85, 74, 04, 36, 16,
										20, 73, 35, 29, 78, 31, 90, 01, 74, 31, 49, 71, 48, 86, 81, 16, 23, 57, 05, 54,
										01, 70, 54, 71, 83, 51, 54, 69, 16, 92, 33, 48, 61, 43, 52, 01, 89, 19, 67, 48};

			int maxProduct = 0;
			for (int i = 0; i < arr.Length; ++i)
			{
				//horizontal
				if (i % 20 < 17)
				{
					int horiz = arr[i] * arr[i + 1] * arr[i + 2] * arr[i + 3];
					if (horiz > maxProduct) maxProduct = horiz;
				}

				//vertical
				if (i >= 60)
				{
					int vert = arr[i] * arr[i - 20] * arr[i - 40] * arr[i - 60];
					if (vert > maxProduct) maxProduct = vert;
				}

				//up and left
				if (i >= 60 && i % 20 > 2)
				{
					int upleft = arr[i] * arr[i - 21] * arr[i - 42] * arr[i - 63];
					if (upleft > maxProduct) maxProduct = upleft;
				}

				//up and right
				if (i >= 60 && i % 20 < 17)
				{
					int upright = arr[i] * arr[i - 19] * arr[i - 38] * arr[i - 57];
					if (upright > maxProduct) maxProduct = upright;
				}
			}
			return maxProduct;
		}

		static ulong HighlyDivisibleTriangle()
		{
			int minFactors = 501;

			ulong triangle = 0;
			uint factors = 0;
			uint i = 0;
			while (factors < minFactors)
			{
				triangle += ++i;
				factors = NumFactors(triangle);
			}

			return triangle;

			uint NumFactors(ulong num)
			{
				uint count = 0;
				for (ulong divisor = num; divisor > 0; --divisor)
				{
					if (num % divisor == 0) ++count; 
				}
				return count;
			}

		}

	}
}
