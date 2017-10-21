using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProject
{
    static class Benchmark
    {
        private static Stopwatch a = new Stopwatch();
        public static void Start()
        {
            a.Start();
        }
        public static void Stop()
        {
            if (a.IsRunning)
                a.Stop();
        }
        public static string ShowTime()
        {
            return a.IsRunning ? null : a.ElapsedMilliseconds.ToString();
        }
    }
}
