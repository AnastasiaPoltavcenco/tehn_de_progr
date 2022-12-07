using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyString str = new MyString(new char[] { 'a', 'b' });
            MyString str1 = new MyString(str);
            Console.WriteLine("str:");
            MyString.Print(str);
            Console.WriteLine("str1:");
            MyString.Print(str1);
            Console.WriteLine("str1 == str1 ?" + (str1 == str));
            Console.WriteLine("str1 equals str1 ?" + (str1.Equals(str)));
            Console.WriteLine("Changed array");
            str1[0] = 'd';
            MyString.Print(str1);
            Console.WriteLine("Concatination: str + str1");
            MyString.Print(str + str1);
            Console.WriteLine("str concatination with array {a,b,a}");
            MyString.Print(str.Concat(new char[] { 'a','b','a'}));
            MyString str4 = new MyString(10);
            Console.WriteLine("str4 is Null? " + str4.IsNull());
            Console.WriteLine("str4: ");
            str4[9] = 'j';
            MyString.Print(str4);
            Console.WriteLine("str to upper: ");
            str4.ToUpper();
            MyString.Print(str4);
            Console.WriteLine("str to lower: ");
            str4.ToLower();
            MyString.Print(str4);
            Console.WriteLine("substr str from 1 to 4");
            Console.WriteLine(str.SubString(1,4));
            Console.WriteLine("substr str from 1");
            Console.WriteLine(str.SubString(1));
            Console.WriteLine("insertion: ");
            str.InsertAt(2, 's');
            MyString.Print(str);
        }
    }
}
