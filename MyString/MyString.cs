using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyString
{
    internal class MyString
    {
        private char[] str;
        public int Length
        {
            //get,set length
            get { return str.Length; }
            set
            {
                char[] temp = new char[value];
                if (value > str.Length)
                {
                    value = str.Length;
                }
                for (int i = 0; i < value; i++)
                {
                    temp[i] = str[i];
                    str = temp;
                }
            }
        }

        //override []
        public char this[int index]
        {
            get { return str[index]; }
            set { str[index] = value; }
        }

        public char[] Value
        {
            get { return str; }
            set
            {
                if (value != null)
                    str = value;
                else
                    throw new ArgumentException("Null Value");
            }
        }

        //override +
        public static MyString operator +(MyString s1, MyString s2)
        {
            int length = s1.Length + s2.Length;
            MyString resultString = new MyString(length);
            for (int i = 0; i < s1.Length; i++)
            {
                resultString[i] = s1[i];
            }
            for (int i = s1.Length; i < resultString.Length; i++)
            {
                resultString[i] = s2[i - s1.Length];
            }
            return resultString;
        }

        //override ==
        public static bool operator ==(MyString str1, MyString str2)
        {
            if (ReferenceEquals(str1, str2))
            {
                return true;
            }
            return false;
        }

        //override !=
        public static bool operator !=(MyString str1, MyString str2)
        {
            if (!ReferenceEquals(str1, str2))
            {
                return true;
            }
            return false;
        }

        public char CharAt(int index)
        {
            return str[index];
        }

        public void InsertAt(int index, char[] s)
        {
            if (index <= 0 || index >= Length)
            {
                throw new ArgumentOutOfRangeException("Index");
            }

            char[] result1 = new char[str.Length - (str.Length - index)];

            for (int i = 0; i < result1.Length; i++)
            {
                result1[i] = str[i];
            }

            char[] result2 = new char[str.Length - index];

            for (int i = 0; i < result2.Length; i++)
            {
                result2[i] = str[index];
            }
            MyString mass1 = new MyString(result1);
            MyString mass2 = new MyString(result2);
            MyString symbol = new MyString(s);
            str = (mass1 + symbol + mass2).GetString();
        }

        public void InsertAt(int index, char s)
        {
            if (index <= 0 || index >= Length)
            {
                throw new ArgumentOutOfRangeException("Index");
            }

            char[] result1 = new char[str.Length - (str.Length - index)];

            for (int i = 0; i < result1.Length; i++)
            {
                result1[i] = str[i];
            }

            char[] result2 = new char[str.Length - index];

            for (int i = 0; i < result2.Length; i++)
            {
                result2[i] = str[index];
            }
            char[] result3 = new char[] { s };
            MyString mass1 = new MyString(result1);
            MyString mass2 = new MyString(result2);
            MyString symbol = new MyString(result3);
            str = (mass1 + symbol + mass2).GetString();
        }

        public char[] Concat(char[] mass1)
        {
            this.str = (new MyString(this.str) + new MyString(mass1)).GetString();
            return this.str;
        }

        public char[] Concat(MyString str2)
        {
            this.str = (new MyString(this.str) + str2).GetString();
            return this.str;
        }

        public char[] SubString(int index1, int index2)
        {
            if (index1 < 0 || index1 > str.Length
                && index2 < 0 || index2 > str.Length 
                && index1 > index2)
            {
                throw new ArgumentException("Index out of range");
            }
            char[] temp = new char[index2 - index1];
            int indexTemp = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (i >= index1 && i < index2)
                {
                    temp[indexTemp] = str[i];
                    indexTemp++;
                }
            }
            return temp;
        }

        public char[] SubString(int index)
        {
            if (index < 0 || index > str.Length)
            {
                throw new ArgumentException("Index out of range");
            }

            char[] temp = new char[str.Length - index];
            int indexTemp = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (i >= index && i < str.Length)
                {
                    temp[indexTemp] = str[i];
                    indexTemp++;
                }
            }
            return temp;
        }

        public char[] GetString()
        {
            return str;
        }

        public static void Print(char[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
            }
            Console.WriteLine();
        }

        public static void Print(MyString str1)
        {
            for (int i = 0; i < str1.Length; i++)
            {
                Console.Write(str1.GetString()[i]);
            }
            Console.WriteLine();
        }

        public bool Equals(MyString obj)
        {
            if (str.Length == obj.GetString().Length)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] != obj.GetString()[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public void ToUpper()
        {
            for(int i = 0; i < this.str.Length; i++)
            {
                str[i] = Char.ToUpper(str[i]);
            }
        }

        public void ToLower()
        {
            for (int i = 0; i < this.str.Length; i++)
            {
                str[i] = Char.ToLower(str[i]);
            }
        }

        public bool IsNull()
        {
            return this.str == null;
        }

        public MyString()
        {
            str = new char[256];
        }

        public MyString(int length)
        {
            str = new char[length];
        }

        public MyString(MyString newString)
        {
            str = new char[newString.str.Length];
            for (int i = 0; i < newString.str.Length; i++)
            {
                str[i] = newString.str[i];
            }
        }

        public MyString(char[] arrayParam)
        {
            str = new char[arrayParam.Length];
            for (int i = 0; i < arrayParam.Length; i++)
            {
                str[i] = arrayParam[i];
            }
        }
    }
}
