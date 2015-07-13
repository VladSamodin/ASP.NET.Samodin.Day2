using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.NthRoot
{
    public static class Math
    {
        public static double NthRoot(double number, int degreeRoot, double precision)
        {
            if (IsEven(degreeRoot) && number < 0)
            {
                throw new ArgumentException("Even degree root of a negative number does not exist");
            }
            double previousApproximation;
            double currentApproximation = number / degreeRoot;
            do
            {
                previousApproximation = currentApproximation;
                currentApproximation = ((degreeRoot - 1) * previousApproximation + number / System.Math.Pow(previousApproximation, degreeRoot - 1)) / degreeRoot;
            }
            while (System.Math.Abs(previousApproximation - currentApproximation) >= precision);
            return currentApproximation;
        }

        private static bool IsEven(int number)
        {
            return (number % 2) == 0;
        }
    }
}
