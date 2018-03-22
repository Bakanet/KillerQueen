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
            for (int i = number.Length - 1; i >= 0; --i)
            {
                digits.Add(number[i]);
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

        public void Print()
        {
            if (digits.Count == 0)
                Console.WriteLine(0);

            else
            {
                string result = "";
                for (int i = digits.Count; i >= 0; --i)
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
            int aNum = a.GetNumDigits(), bNum = b.GetNumDigits();
            if (aNum != bNum)
                return aNum > bNum;

            int i = aNum;
            for (; i >= 0 && a.GetDigit(i) > b.GetDigit(i); --i)
            {
            }

            return i < 0;
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
            if (a.GetNumDigits() == b.GetNumDigits())
                return false;

            int i = 0;
            for (; i < a.GetNumDigits() && a.GetDigit(i) != b.GetDigit(i); ++i)
            {
            }

            return i >= a.GetNumDigits();
        }

        public static BigNum operator +(BigNum a, BigNum b)
        {
            string result = "";

            int count = a.GetNumDigits() > b.GetNumDigits() ? a.GetNumDigits() : b.GetNumDigits();
            int x = 0, y = 0, r = 0;

            for (int i = 0; i < count; ++i)
            {
              
            }
        }

    }
}
