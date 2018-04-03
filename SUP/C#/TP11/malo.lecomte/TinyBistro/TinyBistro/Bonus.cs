using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace TinyBistro
{
	public class BigNumExtended : BigNum
	{
		private List<bool> binary;
		private bool isPositive;

		public BigNumExtended(string number)
			: base(number)
		{
            // 0 represents false
            // 1 represents true
            // BigNumExtended("123456789") => isPositive = true, binary = (1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1)
            // BigNumExtended("-123456789") => isPositive = false, binary = (1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1)

            if (number[0] == '-')
                isPositive = false;
            else
                isPositive = true;

            List<int> digits = new List<int>();
            for (int i = number.Count() - 1; i >= 0; --i)
            {
                digits.Add(number[i] - '0');
            }

            binary = DecToBool(digits);
            Digits = digits;
		}
		
		// 0 represents false
		// 1 represents true
		// List<bool> list = {1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1}
		// BigNumExtended(new List<bool>(list), true) => digits = (9, 8, 7, 6, 5, 4, 3, 2, 1), isPositive = true
		// BigNumExtended(new List<bool>(list), false) => digits = (9, 8, 7, 6, 5, 4, 3, 2, 1), isPositive = false
		public BigNumExtended(List<bool> l, bool b)
			: base(null)
        {
            isPositive = b;
            Digits = BoolToDec(l);
            binary = l;
		}

		// l is the binary list
		// Returns the translation to decimal base
		// List<bool> list = {1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1}
		// BoolToDec(list) = {9, 8, 7, 6, 5, 4, 3, 2, 1}
		public static List<int> BoolToDec(List<bool> l)
		{
            BigNum result = new BigNum("");

            for (int i = 0; i < l.Count(); ++i)
            {
                if (l[i])
                {
                    string number = Math.Pow(2, i).ToString();
                    result += new BigNum(number);
                }
            }

            string str = result.GetStringNumber();
            List<int> list = new List<int>();
            for (int j = str.Count() - 1; j >= 0; --j)
            {
                list.Add(str[j] - '0');
            }

            return list;
		}
		
		// l is the binary list
		// Returns the translation to binary base
		// List<int> list = {9, 8, 7, 6, 5, 4, 3, 2, 1}
		// DecToBool(list) = {1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1}
		public static List<bool> DecToBool(List<int> l)
		{
            string digits = "", result = "";
            for (int i = l.Count() - 1; i >= 0; --i)
            {
                digits += (l[i]);
            }

            
            for (; digits.Count() > 0 && digits[0] > '0';)
            {
                string digits2 = digits;
                digits = "";
                int retain = 0;

                for (int j = 0; j < digits2.Count(); ++j)
                {
                    
                    int digit = 0;

                    if (j == digits2.Count() - 1)
                        result += digits2[j] % 2;

                    if (digits2[j] == '1' && j == 0)
                    {
                        retain = 1;
                        continue;
                    }
                    digit = (digits2[j] - '0') / 2;

                    if (digits2.Count() == 1)
                    {
                        digits += digit;
                        continue;
                    }

                    if (retain > 0)
                        digit += 5;

                    if ((digits2[j]) % 2 == 1)
                        retain = 1;
                    else
                        retain = 0;

                    digits += digit;
                }
            }

            List<bool> ret = new List<bool>();
            for (int k = 0; k < result.Count(); ++k)
            {
                if (result[k] == '0')
                    ret.Add(false);
                else
                    ret.Add(true);
            }

            return ret;
		}
		
		// a is a BigNumExtended
		// b is a BigNumExtended
		// Returns a to the power b
		// Power(BigNumExtended("123456789"), BigNumExtended("2")) = 975461057789971041
		public static BigNumExtended Power(BigNumExtended a, BigNumExtended b)
		{
            throw new NotImplementedException();
		}

		// a is a BigNumExtended
		// Returns square root of a
		// Root(BigNumExtended("123456789")) = 11111
		// Root(BigNumExtended("-123456789")) = ArgumentException
		public static BigNumExtended Root(BigNumExtended a)
		{
            if (!a.isPositive)
                throw new ArgumentException("the number can't be negative");
			throw new NotImplementedException();
		}

		// a is a BigNumExtended
		// l is the liste containing the base
		// Prints on standart output a using the base l
		// char[] list = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'l'};
		// Print(BigNumExtended("123456789"), new List<char>(list)) = bcdefghjkl
		// Print(BigNumExtended("-123456789"), new List<char>(list)) = -bcdefghjkl
		public static void Print(BigNumExtended a, List<char> l)
		{
            string result = "";
            if (!a.isPositive)
                result = "-";
            for (int i = a.GetNumDigits() - 1; i >= 0; --i)
            {
                if (a.GetDigit(i) - '0' > l.Count())
                    throw new OverflowException("the digit is too big for the base");
                result += l[a.GetDigit(i) - '0'];
            }

            Console.WriteLine(result);
		}

		// a is a BigNumExtended
		// b is a BigNumExtended
		// Returns the binary and between a and b
		// OpAnd(BigNumExtended("123456789"), BigNumExtended("987654321")) = 39471121
		public static BigNumExtended OpAnd(BigNumExtended a, BigNumExtended b)
		{
            if (a < b)
                return OpAnd(b, a);

            List<bool> l = new List<bool>();

            for (int i = 0; i < a.binary.Count(); ++i)
            {
                bool x = false, y = false;

                if (i >= b.binary.Count())
                    x = a.binary[i];

                else
                {
                    x = a.binary[i];
                    y = b.binary[i];
                }

                l.Add(x && y);
            }

            bool sign = false;
            if ((a.isPositive && b.isPositive) || (!a.isPositive && !b.isPositive))
                sign = true;

            return new BigNumExtended(l, sign);
		}

        // a est un BigNumExtended
        // b est un BigNumExtended
        // Returns the binary or between a and b
        // OpOr(BigNumExtended("123456789"), BigNumExtended("987654321")) = 1071639989
        public static BigNumExtended OpOr(BigNumExtended a, BigNumExtended b)
        {
            if (a < b)
            {
                BigNumExtended c = a;
                a = b;
                b = c;
            }

            List<bool> l = new List<bool>();

            for (int i = 0; i < a.binary.Count(); ++i)
            {
                bool x = false, y = false;

                if (i >= b.binary.Count())
                    x = a.binary[i];

                else
                {
                    x = a.binary[i];
                    y = b.binary[i];
                }

                l.Add(x || y);
            }

            bool sign = false;
            if ((a.isPositive && b.isPositive) || (!a.isPositive && !b.isPositive))
                sign = true;

            return new BigNumExtended(l, sign);
        }

		// a is a BigNumExtended
		// b is a BigNumExtended
		// Returns not a
		// OpXor(BigNumExtended("123456789")) = 10760938
		public static BigNumExtended OpNot(BigNumExtended a)
		{
            List<bool> binaries = new List<bool>();

            for (int i = 0; i < a.binary.Count(); ++i)
            {
                if (a.binary[i])
                    binaries.Add(false);
                else
                    binaries.Add(true);
            }

            return new BigNumExtended(binaries, a.isPositive);
		}

		// a is a BigNumExtended
		// b is a BigNumExtended
		// Returns the binary xor between a and b
		// OpXor(BigNumExtended("123456789"), BigNumExtended("987654321")) = 1032168868
		public static BigNumExtended OpXor(BigNumExtended a, BigNumExtended b)
		{
			throw new NotImplementedException();
		}

		// a is a BigNumExtended
		// i is the number of bits to shift
		// Returns a left shifted by i
		public static BigNumExtended operator <<(BigNumExtended a, int i)
		{
            List<bool> binaries = new List<bool>();
			for (int j = 0; j < i; ++j)
                binaries.Add(false);

            for (int k = 0; k < a.binary.Count(); ++k)
                binaries.Add(a.binary[k]);

            return new BigNumExtended(binaries, a.isPositive);
		}

		// a is a BigNumExtended
		// i is the number of bits to shift
		// Returns a right shifted by i
		public static BigNumExtended operator >>(BigNumExtended a, int i)
		{
            for (int j = 0; j < i; ++j)
            {
                a.binary.RemoveAt(0);
            }

            return new BigNumExtended(a.binary, a.isPositive);
		}

		// a is a BigNumExtended
		// b is a BigNumExtended
		// Returns the a + b addition
		// BigNumExtended("100") + BigNumExtended("1") = 101
		// BigNumExtended("100") + BigNumExtended("-1") = 99
		public static BigNumExtended operator +(BigNumExtended a, BigNumExtended b)
		{
			throw new NotImplementedException();
		}
		
		// a is a BigNumExtended
		// b is a BigNumExtended
		// Returns the a + b substraction
		// BigNumExtended("100") - BigNumExtended("1") = 99
		// BigNumExtended("100") - BigNumExtended("-1") = 101
		public static BigNumExtended operator -(BigNumExtended a, BigNumExtended b)
		{
			throw new NotImplementedException();
		}
		
		// a is a BigNumExtended
		// b is a BigNumExtended
		// Returns the a + b multiplication
		// BigNumExtended("100") * BigNumExtended("1") = 100
		// BigNumExtended("100") * BigNumExtended("-1") = -100
		public static BigNumExtended operator *(BigNumExtended a, BigNumExtended b)
		{
			throw new NotImplementedException();
		}
		
		// a is a BigNumExtended
		// b is a BigNumExtended
		// Returns the a + b division
		// BigNumExtended("100") / BigNumExtended("1") = 100
		// BigNumExtended("100") / BigNumExtended("-1") = -100
		public static BigNumExtended operator /(BigNumExtended a, BigNumExtended b)
		{
			throw new NotImplementedException();
		}
	}
}
