/*
 *Jett Smith
 *ITSE 1430 Fall 2021
 */
using System;
using System.Text;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        static void DemoLogicalOperators ()
        {
            //Logical AND - true if both operands are true
            //Logical OR - true if either operand is true
            // X  Y &&  ||
            //---------------
            // F  F  F  F
            // F  T  F  T
            // T  F  F  T
            // T  T  T  T

            // NOT
            //    F !F = T
            //    T !T = F
        }
        static void DemoRelationalOperators ()
        {
            int x = 10, y = 20;

            bool isLessThan = x < y;
            bool isLessThanOrEqualTo = x <= y;

            bool isGreaterThan = x > y;
            bool isGreaterThanOrEqualTo = x >= y;

            bool isEqual = x ==y;
            bool isNotEqual = x != y;
        }
        static void DemoCombinationOperators ()
        {
            //Works for more than just arithmetic
            int x = 10;

            x += 10;    // x = x + 10;
            x -= 20;    // x = x - 20;
            x *= 3;     // x = x * 3;
            x /= 5;     // x = x / 5;
            x %= 2;     // x = x % 2;
        }
        static void DemoPrefixPostfixOperators ()
        {
            int x = 10, y;

            //Prefix increment
            y = ++x;    // y = 11, x = 11

            //Prefix decrement
            y = --x;    // y = 10, x = 10

            //Postfix increment
            y = x++;    // y = 10, x = 11

            //Postfix decrement
            y = x--;    // y = 11, x = 10
        }
        static void DemoAssignmentOperator ()
        {
            int x;
            int y;
            int z;

            x = 20;
            y = 20;
            z = 10;

            //left associative (E1 op E2) => E1, E2, op
            //right associative operator (E1 op E2) => E2, E1, op
            x = y = z = 20; // x = (y = (z = 20))
        }
        static void DemoConditionalOperator ()
        {
            int grade = 70;

            string passStatus;

            if (grade < 60)
                passStatus = "Not Passing";
            else
                passStatus = "Passing";

            //Terninary - 3 operands
            // E(bool) ? E(true) : E(false)
            string passStatus2 = (grade < 60) ? "Not Passing" : "Passing";
        }
        static void DemoStrings ()
        {
            string firstName = "Bob";

            //Relationals work, case sensitive
            bool isBob = firstName == "Bob";

            //String literals
            string literal1 = "Hello World";

            //Escape sequence - \?, only work in string literals
            //  \n => newline
            //  \t => horizontal tab
            //  \\ => slash
            //  \" => double quote
            //  \' => character literal, single quote
            literal1 = "Hello\nWorld";
            string quoteString = "Hello \"Bob\"";
            
            string filePath = "C:\\windows\\system32\\tasks";
            string verbatimFilePath = @"C:\windows\system32\tasks";
            

            //String length '.Length' => how many characters
            int length = literal1.Length;

            //Empty string
            string emptyString = "";                        //.Length = 0
            string emptyString2 = String.Empty;             //.Length = 0
            bool areEmptyStringEqual = String.Empty == "";  // True

            // null != empty string
            // default value for strings is null
            string nullString = null;
            bool areEqualNull = "" == null; //false

            // string is the universal type in C#
            // all expressions are convertible to string using .ToString
            string asString = length.ToString();    // length as a string
            asString = 10.ToString();               // "10"
            asString = areEqualNull.ToString();     // "False"

            // Comparison
            string value1 = "Hello", value2 = "hello";
            bool compareCaseInsensitive = String.Compare(value1, value2, true) == 0; //Preferred
            bool compareCaseSensitive = String.Compare(value1, value2) == 0;

            compareCaseSensitive = value1.CompareTo(value2) == 0; //works but not safe

            string lowerValue1 = value1.ToLower();
            string upperValue1 = value1.ToUpper();
            compareCaseInsensitive = value1.ToUpper() == value2.ToUpper();

            // Concatenation
            int year = 2021;
            firstName = "Bob";
            string lastName = "Smith";
            string name = firstName + " " + lastName + " " + year; //Bob Smith
            name = String.Concat(firstName, " ", lastName, " ", year); //For larger # of strings

            var builder = new StringBuilder(); //For complex situations
            builder.Append(firstName);
            builder.Append(" ");
            builder.Append(lastName);
            builder.Append(" ");
            builder.Append(year);
            name = builder.ToString();

                //first last year
            name = String.Join(" ", firstName, lastName, year);

            //Misc
            bool startsWithB = name.StartsWith("B");
            startsWithB = name.StartsWith("B", StringComparison.CurrentCultureIgnoreCase);

            bool endsWith9 = name.EndsWith("9");
            endsWith9 = name.EndsWith("9", StringComparison.CurrentCultureIgnoreCase);

            //Removes leading and trailing whitespace
            string normalizedName = name.Trim();
            //name.TrimStart().TrimEnd()

            //Some useful functions
            //name.Substring(startIndex); //gets a subset of string
            //name.IndexOf(character); //Finds a character

            name.PadLeft(50);   //Add enough spaces on left to make string length 50
            name.PadRight(50);  //Add enough spaces on right to make string length 50

            // Empty string checking
            bool isEmpty;
            isEmpty = name == "";       //Not always going to work correctly for yoy
            isEmpty = name.Length == 0; //Will crash if null

            //handle null
            isEmpty = (name != null) ? name == "" : true;
            isEmpty = name == null || name == "";
            isEmpty = (name != null) ? name.Length == 0 : true;
            isEmpty = String.IsNullOrEmpty(name); //Preferred

            // Formatting - Hello first last, the year is year.
            name = "Hello " + firstName + " " + lastName + ", the year is " + year + ".";
            name = String.Format("Hello {0} {1}, the year is {2}.", firstName, lastName, year);
            Console.WriteLine("Hello {0} {1}, the year is {2}.", firstName, lastName, year);

            decimal price = 8.75M;
            string priceString = price.ToString();      //8.7500000
            priceString = price.ToString("C");          //Money 8.75
            priceString = price.ToString("N6:N2");      //8.7500 if positive
            priceString = String.Format("{0:C}", price);

            //String interpolation - way to go
            name = $"Hello {firstName} {lastName}, the year is {year:0000}.";
        }
    }
}