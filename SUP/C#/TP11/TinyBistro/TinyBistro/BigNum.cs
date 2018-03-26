using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Xml.Schema;

namespace TinyBistro
{
    public class BigNum
    {
        private List<int> digits;

        public BigNum(string number)
        {
            digits = new List<int>();
            for (int i = number.Length - 1; i >= 0; --i)
            {
                if (number[i] < '0' || number[i] > '9')
                    throw new ArgumentException("You have to write a number");
                digits.Add(number[i] - '0');
            }
        }

        public int GetNumDigits()
        {
            return digits.Count;
        }

        public void AddDigit(int digit)
        {
            digits.Add(digit);
        }

        public int GetDigit(int position)
        {
            if (position >= digits.Count)
                throw new OverflowException("the number isn't that big");

            return digits[position];
        }

        public void SetDigit(int digit, int position)
        {
            if (digit < 0 || digit > 9)
                throw new ArgumentException("the number has to be a digit");

            int length = digits.Count;

            if (position >= length)
            {
                for (int i = 0; i < position - length - 2; ++i)
                {
                    digits.Add(0);
                }
                
                digits.Add(digit);
            }

            else
            {
                digits[position] = digit;
            }

            for (int i = length - 1; digits[i] == 0; --i)
            {
                digits.RemoveAt(i);
            }
        }

        public string GetStringNumber()
        {
            string result = "";

            for (int i = 0; i < GetNumDigits(); ++i)
            {
                result += GetDigit(i);
            }

            return result;
        }

        public void Print()
        {
            if (digits.Count == 0)
                Console.WriteLine(0);

            else
            {
                string result = "";
                for (int i = digits.Count - 1; i >= 0; --i)
                {
                    result += digits[i];
                }

                Console.WriteLine(result);
            }
        }

        public static bool operator <(BigNum a, BigNum b)
        {
            int aNum = a.GetNumDigits(), bNum = b.GetNumDigits();
            if (aNum != bNum)
                return aNum < bNum;

            int i = aNum;
            for (; i >= 0 && a.GetDigit(i) < b.GetDigit(i); --i)
            {
            }

            return i < 0;
        }

        public static bool operator >(BigNum a, BigNum b)
        {
            return !(a < b);
        }

        public static bool operator ==(BigNum a, BigNum b)
        {
            if (a.GetNumDigits() != b.GetNumDigits())
                return false;

            int i = 0;
            for (; i < a.GetNumDigits() && a.GetDigit(i) == b.GetDigit(i); ++i)
            {
            }

            return i >= a.GetNumDigits();
        }

        public static bool operator !=(BigNum a, BigNum b)
        {
            return !(a == b);
        }

        public static BigNum operator +(BigNum a, BigNum b)
        {
            int aLength = a.GetNumDigits(), bLength = b.GetNumDigits();
            int count = Math.Max(a.GetNumDigits(), b.GetNumDigits());
            int r = 0;

            for (int i = 0; i < count; ++i)
            {
                int x = 0, y = 0;

                if (i >= aLength)
                    y = b.GetDigit(i);

                else if (i >= bLength)
                    x = a.GetDigit(i);

                else
                {
                    x = a.GetDigit(i);
                    y = b.GetDigit(i);
                }

                int n = x + y + r;

                if (n > 9)
                {
                    r = 1;
                    a.SetDigit(n - 10, i);
                }

                else
                {
                    r = 0;
                    a.SetDigit(n, i);
                }
            }

            return a;
        }

        public static BigNum operator -(BigNum a, BigNum b)
        {
            BigNum c = new BigNum("");

            int n = 0, r = 0;
            int bLength = b.GetNumDigits();
            for (int i = 0; i < a.GetNumDigits(); ++i)
            {
                int x = 0, y = 0;

                if (i >= bLength)
                    x = a.GetDigit(i);

                else
                {
                    x = a.GetDigit(i);
                    y = b.GetDigit(i);
                }

                if (x < y + r)
                {
                    a.SetDigit(x - (y + r) + 10, i);
                    r = 1;
                }

                else
                {
                    a.SetDigit(x - (y + r), i);
                    r = 0;
                }
            }

            return a;
        }

        public static BigNum operator *(BigNum a, BigNum b)
        {
            int aLength = a.GetNumDigits(), bLength = b.GetNumDigits();
            
            if (a < b)
            {
                BigNum c = new BigNum(b.GetStringNumber());
                b = a;
                a = c;
            }

            int r = 0, n = 0, count = 1;
            BigNum result = new BigNum("0");

            for (int i = 0; i < bLength; ++i)
            {
                string product = "";
                for (int j = 0; j < aLength; ++j)
                {
                    n = b.GetDigit(i) * a.GetDigit(j) + r;
                    r = n / 10;
                    n %= 10;

                    product += ('0' + n);
                }

                for (int k = 0; k < count; ++k)
                {
                    product += '0';
                }

                result += new BigNum(product);
            }

            return result;
        }

        /*public static BigNum operator /(BigNum a, BigNum b)
        {
            if (a < b)
                return new BigNum("0");

            int count = b.GetNumDigits();
            int parsed = 0;

            for (int i = 0; i < count; ++i)
            {

            }

        }*/


    }
}
