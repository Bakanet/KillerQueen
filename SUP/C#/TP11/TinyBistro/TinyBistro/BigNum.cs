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

        public List<int> Digits
        {
            get { return digits; }
            set { digits = value; }
        }

        public BigNum(string number)
        {
            if (number == null)         // pour gérer le cas si le number est nul, sinon ça plante au niveau de number.Length
                goto pass;
            digits = new List<int>();
            for (int i = number.Length - 1; i >= 0; --i)
            {
                if (number[i] < '0' || number[i] > '9')
                    throw new ArgumentException("You have to write a number");
                digits.Add(number[i] - '0');
            }

            pass:;
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

            for (int i = length - 1; i > -1 && digits[i] == 0; --i)
            {
                digits.RemoveAt(i);
            }
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

        public string GetStringNumber()
        {
            string result = "";

            for (int i = digits.Count - 1; i >= 0; --i)
            {
                result += GetDigit(i);
            }

            return result;
        }

        public static bool operator <(BigNum a, BigNum b)
        {
            int aNum = a.GetNumDigits(), bNum = b.GetNumDigits();
            if (aNum != bNum)
                return aNum < bNum;

            int i = aNum - 1;
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
            BigNum c = new BigNum("");

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
                    c.AddDigit(n - 10);
                }

                else
                {
                    r = 0;
                    c.AddDigit(n);
                }
            }

            if (r == 1)
                c.AddDigit(1);

            return c;
        }

        public static BigNum operator -(BigNum a, BigNum b)
        {
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

            int r = 0, n = 0, count = 0;
            BigNum result = new BigNum("");

            for (int i = 0; i < bLength; ++i)
            {
                string product = "";
                for (int j = 0; j < aLength; ++j)
                {
                    n = b.GetDigit(i) * a.GetDigit(j) + r;
                    r = n / 10;
                    n %= 10;

                    product = n + product;
                }

                for (int k = 0; k < count; ++k)
                {
                    product += '0';
                }

                ++count;
                result += new BigNum(product);
            }

            if (r > 0)
                result.AddDigit(r);

            return result;
        }

        /* public int Divide(BigNum n, int interval)
        {
            string s = n.GetStringNumber();
        } */

        public static BigNum operator /(BigNum a, BigNum b)
        {
            if (a < b)
                return new BigNum("0");

            if (b == new BigNum("1"))
                return a;

            BigNum c = new BigNum("");
            BigNum zero = new BigNum("0");
            while (a > b)
            {
                a -= b;
                c += new BigNum("1");
            }

            return c;
        }

        public static BigNum operator %(BigNum a, BigNum b)
        {
            BigNum c = new BigNum(a.GetStringNumber());
            BigNum result = c - ((a / b) * b);
            return result;
        }
    }
}
