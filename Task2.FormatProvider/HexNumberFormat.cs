using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.FormatProvider
{
    public class HexNumberFormat : IFormatProvider, ICustomFormatter
    {
        private static readonly Dictionary<string, char> binaryToHexDictionary;
        static HexNumberFormat()
        {
            binaryToHexDictionary = new Dictionary<string, char>();
            binaryToHexDictionary.Add("0000", '0');
            binaryToHexDictionary.Add("0001", '1');
            binaryToHexDictionary.Add("0010", '2');
            binaryToHexDictionary.Add("0011", '3');
            binaryToHexDictionary.Add("0100", '4');
            binaryToHexDictionary.Add("0101", '5');
            binaryToHexDictionary.Add("0110", '6');
            binaryToHexDictionary.Add("0111", '7');
            binaryToHexDictionary.Add("1000", '8');
            binaryToHexDictionary.Add("1001", '9');
            binaryToHexDictionary.Add("1010", 'A');
            binaryToHexDictionary.Add("1011", 'B');
            binaryToHexDictionary.Add("1100", 'C');
            binaryToHexDictionary.Add("1101", 'D');
            binaryToHexDictionary.Add("1110", 'E');
            binaryToHexDictionary.Add("1111", 'F');
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        public string Format(string fmt, object arg, IFormatProvider formatProvider)
        {
            if (arg.GetType() != typeof(Int32))
            {
                try
                {
                    return HandleOtherFormats(fmt, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(String.Format("The format of '{0}' is invalid.", fmt), e);
                }
            }

            string ufmt = fmt.ToUpper(CultureInfo.InvariantCulture);
            if (ufmt != "HEX")
            {
                try
                {
                    return HandleOtherFormats(fmt, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(String.Format("The format of '{0}' is invalid.", fmt), e);
                }
            }

            string bits = BitArrayToString(new BitArray(new int[] { (int)arg }));
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < bits.Length; i += 4)
                result.Append(GetHexDigit(bits.Substring(i, 4)));
            return result.ToString();
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            else if (arg != null)
                return arg.ToString();
            else
                return String.Empty;
        }

        private static char GetHexDigit(string str)
        {
            return binaryToHexDictionary[str];
        }

        private static string BitArrayToString(BitArray bits)
        {
            StringBuilder result = new StringBuilder();
            for (int i = bits.Length - 1; i >= 0; i--)
            {
                if (bits[i])
                    result.Append('1');
                else
                    result.Append('0');
            }
            return result.ToString();
        }
    }
}
