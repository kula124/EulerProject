using EulerProject;
using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Problem59
{
    class Program
    {
        static bool UseHashes = true;
        static string hash;
        static string key;
        static Random r = new Random();
        static string solution;
        static Hashtable ht = new Hashtable();
        static int c = 0;
        static int ac = 0;
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("file.txt"))
            {
                hash = reader.ReadToEnd();
            }
            var words = hash.Split(',');
            Benchmark.Start();
            do
            {
                key = GenerateKey();
                Console.Write("Tring key: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(key);
                Console.ResetColor();
                c++;
                solution = Decrypt(words);
            }
            while (!IsValid(solution, new string[] {" the ","and", " a "}));
            Benchmark.Stop();
            Console.Write("SOLVED with KEY: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(key);
            Console.ResetColor();
            Console.WriteLine("Keys tested: {0}", c);
            Console.WriteLine("Key found in {0} ms", Benchmark.ShowTime());
            Console.WriteLine(solution);
            Console.WriteLine("CheckSum(solution): {0}", GetSum());
            Console.ReadKey();
        }

        private static int GetSum()
        {
            int sum = 0;
            foreach (var item in solution)
            {
                sum += item;
            }
            return sum;
        }

        private static string Decrypt(string[] words)
        {
            int i = 0;
            StringBuilder sb = new StringBuilder();
            foreach (var item in words)
            {
                var target = Int32.Parse(item);
                var keyp = (int)key[i++];
                var S = target ^ keyp;
                sb.Append((char)S);
                if (i == key.Length)
                    i = 0;
            }
            return sb.ToString();
        }
        private static bool IsValid(string s, string[] words)
        {
            s = s.ToLower();
            foreach (var item in words)
            {
                if (!s.Contains(item))
                    return false;
            }
            return true;
        }
        private static string GenerateKey()
        {
            char[] t = new char[3];
            for (int i = 0; i < 3; i++)
            {
                t[i] = (char)(r.Next(97, 122));
            }
            var key = new string(t);
            ac++;
            if (UseHashes)
                if (KeyExistis(key))
                    return GenerateKey();
                else
                    return key;
            else
                return key;
        }

        private static bool KeyExistis(string key)
        {
            if (!(ht[key] is null))
                return true;
            ht.Add(key, true);
            return false;
        }
    }
}
