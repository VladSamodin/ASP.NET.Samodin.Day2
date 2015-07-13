using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Task3.GCD
{
    public static class Algorithms
    {
        private delegate int AlgorithmGCD(out TimeSpan runtime, int a, int b);

        #region Euclidean algorithm
        public static int GCDEuclidean(out TimeSpan runTime, int a, int b)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            a = a < 0 ? -a : a;
            b = b < 0 ? -b : b;
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a = a % b;
                }
                else
                {
                    b = b % a;
                }
            }
            stopWatch.Stop();
            runTime = stopWatch.Elapsed;
            return a + b;
        }

        public static int GCDEuclidean(out TimeSpan runTime, int a, int b, int c)
        {
            return GCD(out runTime, GCDEuclidean, a, b, c);
        }

        public static int GCDEuclidean(out TimeSpan runTime, params int[] array)
        {
            return GCD(out runTime, GCDEuclidean, array);
        }
        #endregion

        #region Binary algorithm
        public static int GCDBinary(out TimeSpan runTime, int a, int b)
        {          
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int shift;
            a = a < 0 ? -a : a;
            b = b < 0 ? -b : b;

            if (a == 0 || b == 0)
            {
                stopWatch.Stop();
                runTime = stopWatch.Elapsed;
                return a | b;
            }

            for (shift = 0; ((a | b) & 1) == 0; shift++)
            {
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
            {
                a >>= 1;
            }

            do
            {
                while ((b & 1) == 0)
                {
                    b >>= 1;
                }

                if (a < b)
                {
                    b -= a;
                }
                else
                {
                    int diff = a - b;
                    a = b;
                    b = diff;
                }
                b >>= 1;
            } while (b != 0);

            stopWatch.Stop();
            runTime = stopWatch.Elapsed;

            return a << shift;
        }

        public static int GCDBinary(out TimeSpan runTime, int a, int b, int c)
        {
            return GCD(out runTime, GCDBinary, a, b, c);
        }

        public static int GCDBinary(out TimeSpan runTime, params int[] array)
        {
            return GCD(out runTime, GCDBinary, array);
        }
        #endregion

        private static int GCD(out TimeSpan runTime, AlgorithmGCD algorithm, int a, int b, int c)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int intermediateGCD = algorithm(out runTime, a, b);
            int finalGCD = algorithm(out runTime, intermediateGCD, c);

            stopWatch.Stop();
            runTime = stopWatch.Elapsed;
            return finalGCD;
        }

        private static int GCD(out TimeSpan runTime, AlgorithmGCD algorithm, int[] array)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            if (array.Length == 0)
                throw new ArgumentException("array is empty", "array");
            if (array.Length == 1)
            {
                stopWatch.Stop();
                runTime = stopWatch.Elapsed;
                return array[0];
            }
            int intermediateGCD = algorithm(out runTime, array[0], array[1]);
            for (int i = 2; i < array.Length; i++)
                intermediateGCD = algorithm(out runTime, intermediateGCD, array[i]);
            int finalGCD = intermediateGCD;

            stopWatch.Stop();
            runTime = stopWatch.Elapsed;
            return finalGCD;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int Abs(int number)
        {
            return number < 0 ? -number : number;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DivisionBy2WithoutResidue(ref int number)
        {
            while ((number & 1) == 0)
            {
                number >>= 1;
            }
        }

    }
}
