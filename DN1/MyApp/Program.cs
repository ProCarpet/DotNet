using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

/// <summary>
/// Sieb des Eratosthenes
/// Autor: Karl Rege 
/// </summary>

namespace DN1
{
    public enum PrimeType { Prime, NotPrime };

    public class Eratosthenes
    {

        public PrimeType[] Sieve(int maxPrime)
        {
            PrimeType[] prime_sived = new PrimeType[maxPrime];
            Array.Fill(prime_sived,PrimeType.Prime,0,maxPrime-1);
            prime_sived[0] = PrimeType.NotPrime;
            prime_sived[1] = PrimeType.NotPrime; 
            for (int i = 2; i < maxPrime; i++) {
                for (int y = 2; y < maxPrime && i*y < maxPrime; y++) {
                    prime_sived[i * y] = PrimeType.NotPrime;
                }
            }
            return prime_sived;
        }

        public int[] PrimesAsArray(PrimeType[] primes)
        {
            List<int> ls = new List<int>();
            for (int i = 0; i < primes.Length;i++) {
                if (primes[i] == PrimeType.Prime)
                {
                    ls.Add(i);
                }
            }
            return ls.ToArray();
        }

        public List<int> PrimesAsList(PrimeType[] primes)
        {

            List<int> ls = new List<int>();
            for (int i = 0; i < primes.Length; i++)
            {
                if (primes[i] == PrimeType.Prime)
                {
                    ls.Add(i);
                }
            }
            return ls; 
        }

        public Dictionary<int, int> PrimesAsDictionary(PrimeType[] primes)
        {
            Dictionary<int, int> ls = new Dictionary<int, int>();
            int current_it = 0; 
            for (int i = 0; i < primes.Length; i++)
            {
                if (primes[i] == PrimeType.Prime)
                {
                    ls.Add(current_it,i);
                    current_it++;
                }
            }
            return ls;
        }

        public void printAll(IEnumerable<int> collection)
        {
            int i = 0;
            foreach (int p in collection)
            {
                Console.Write((i++) + "->" + p + " ");
                if ((i + 1) % 5 == 0) Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int maxPrime = 100;
            Eratosthenes eratosthenes = new Eratosthenes();
            if (args.Length >= 1)
                maxPrime = Int32.Parse(args[0]);

            PrimeType[] primes = eratosthenes.Sieve(maxPrime);
            Console.WriteLine("Aufgabe 1");
            for (int i = 0; i < maxPrime; i++)
            {
                Console.Write(i + ":" + primes[i] + " ");
                if ((i + 1) % 5 == 0) Console.WriteLine();
            }
            Console.WriteLine("\nAufgabe 2");
            eratosthenes.printAll(eratosthenes.PrimesAsArray(primes));
            Console.WriteLine("\nAufgabe 3");
            eratosthenes.printAll(eratosthenes.PrimesAsList(primes));
            Console.WriteLine("\nAufgabe 4");
            eratosthenes.printAll(eratosthenes.PrimesAsDictionary(primes).Select(z => z.Value).ToArray());

            Console.ReadLine();
        }
    }
}