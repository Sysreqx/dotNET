using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4Part2
{


    #region Understanding the enum Type

    //A custom enumeration.
    enum EmpType
    {
        Manager, // = 0
        Grunt, // = 1
        Contractor, // = 2
        VicePresident // = 3
    }
    #endregion

    #region Value Types, References Types, and the Assignment Operator
    // Classes are always reference types.
    class PointRef
    {
        public int X { get; set; }
        public int Y { get; set; }
        // Same members as the Point structure...
        // Be sure to change your constructor name to PointRef!
        public PointRef(int XPos, int YPos)
        {
            X = XPos;
            Y = YPos;
        }

        internal void Display()
        {
            Console.WriteLine($"X: {X}, Y: {Y}");
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Nullable Data *****\n");
            string[] a = new string[0];
            int[] b = new int[] { 1, 2, 3, 4 };
            TesterMethod(a);
            Console.ReadLine();
        }

        #region The Null Conditional Operator
        static void TesterMethod(string[] args)
        {
            // We should check for null before accessing the array data!
            Console.WriteLine($"You sent me {args?.Length ?? 0} arguments.");
        }
        #endregion

        #region Working with Nullable Types
        class DatabaseReader
        {
            // Nullable data field.
            public int? numericValue = null;
            public bool? boolValue = true;
            // Note the nullable return type.
            public int? GetIntFromDatabase()
            { return numericValue; }
            // Note the nullable return type.
            public bool? GetBoolFromDatabase()
            { return boolValue; }
        }
        #endregion

        #region Understanding C# Nullable Types
        static void LocalNullableVariables()
        {
            // Define some local nullable variables.
            int? nullableInt = 10;
            double? nullableDouble = 3.14;
            bool? nullableBool = null;
            char? nullableChar = 'a';
            int?[] arrayOfNullableInts = new int?[10];
            // Error! Strings are reference types!
            // string? s = "oops";
        }
        #endregion

        #region Passing Reference Types by Reference
        static void SendAPersonByReference(ref Person p)
        {
            // Change some data of "p".
            p.personAge = 555;
            // "p" is now pointing to a new object on the heap!
            p = new Person("Nikki", 999);
        }
        #endregion

        #region Passing Reference Types by Value

        static void Change(int[] pArray)
        {
            pArray[0] = 888;  // This change affects the original element.
            pArray = new int[5] { -3, -1, -2, -3, -4 };   // This change is local.
            System.Console.WriteLine("Inside the method, the first element is: {0}", pArray[0]);
        }
        /* Output:
            Inside Main, before calling the method, the first element is: 1
            Inside the method, the first element is: -3
            Inside Main, after calling the method, the first element is: 888
        */

        class Person
        {
            public string personName;
            public int personAge;
            // Constructors.
            public Person(string name, int age)
            {
                personName = name;
                personAge = age;
            }
            public Person() { }
            public void Display()
            {
                Console.WriteLine("Name: {0}, Age: {1}", personName, personAge);
            }
        }
        static void SendAPersonByValue(Person p)
        {
            // Change the age of "p"?
            p.personAge = 99;
            // Will the caller see this reassignment?
            p = new Person("Nikki", 99);
        }
        #endregion

        #region Value Types Containing Reference Types
        class ShapeInfo
        {
            public string InfoString;
            public ShapeInfo(string info)
            {
                InfoString = info;
            }
        }
        struct Rectangle
        {
            // The Rectangle structure contains a reference type member.
            public ShapeInfo RectInfo;
            public int RectTop, RectLeft, RectBottom, RectRight;
            public Rectangle(string info, int top, int left, int bottom, int right)
            {
                RectInfo = new ShapeInfo(info);
                RectTop = top; RectBottom = bottom;
                RectLeft = left; RectRight = right;
            }
            public void Display()
            {
                Console.WriteLine("String = {0}, Top = {1}, Bottom = {2}, " +
                "Left = {3}, Right = {4}",
                RectInfo.InfoString, RectTop, RectBottom, RectLeft, RectRight);
            }
        }

        static void ValueTypeContainingRefType()
        {
            // Create the first Rectangle.
            Console.WriteLine("-> Creating r1");
            Rectangle r1 = new Rectangle("First Rect", 10, 10, 50, 50);
            // Now assign a new Rectangle to r1.
            Console.WriteLine("-> Assigning r2 to r1");
            Rectangle r2 = r1;
            // Change some values of r2.
            Console.WriteLine("-> Changing values of r2");
            r2.RectInfo.InfoString = "This is new info!";
            r2.RectBottom = 4444;
            // Print values of both rectangles.
            r1.Display();
            r2.Display();
        }
        #endregion

        #region Value Types, References Types, and the Assignment Operator
        // Assigning two intrinsic value types results in
        // two independent variables on the stack.
        static void ValueTypeAssignment()
        {
            Console.WriteLine("Assigning value types\n");
            Point p1 = new Point(10, 10);
            Point p2 = p1;
            // Print both points.
            p1.Display();
            p2.Display();
            // Change p1.X and print again. p2.X is not changed.
            p1.X = 100;
            Console.WriteLine("\n=> Changed p1.X\n");
            p1.Display();
            p2.Display();
        }

        static void ReferenceTypeAssignment()
        {
            Console.WriteLine("Assigning reference types\n");
            PointRef p1 = new PointRef(10, 10);
            PointRef p2 = p1;
            // Print both point refs.
            p1.Display();
            p2.Display();
            // Change p1.X and print again.
            p1.X = 100;
            Console.WriteLine("\n=> Changed p1.X\n");
            p1.Display();
            p2.Display();
        }

        #endregion

        #region Understanding Value Types and Reference Types

        // Local structures are popped off
        // the stack when a method returns.
        static void LocalValueTypes()
        {
            // Recall! "int" is really a System.Int32 structure.
            int i = 0;
            // Recall! Point is a structure type.
            Point p = new Point();
        } // "i" and "p" popped off the stack here!
        #endregion

        #region Understanding the Structure (aka Value Type)
        struct Point
        {
            // Fields of the structure.
            public int X;
            public int Y;
            // A custom constructor.
            public Point(int XPos, int YPos)
            {
                X = XPos;
                Y = YPos;
            }
            // Add 1 to the (X, Y) position.
            public void Increment()
            {
                X++; Y++;
            }
            // Subtract 1 from the (X, Y) position.
            public void Decrement()
            {
                X--; Y--;
            }
            // Display the current position.
            public void Display()
            {
                Console.WriteLine("X = {0}, Y = {1}", X, Y);
            }
        }
        #endregion

        #region Dynamically Discovering an enum’s Name-Value Pairs
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("**** Fun with Enums *****");
        //    EmpType e2 = EmpType.Contractor;
        //    // These types are enums in the System namespace.
        //    DayOfWeek day = DayOfWeek.Monday;
        //    ConsoleColor cc = ConsoleColor.Gray;
        //    EvaluateEnum(e2);
        //    EvaluateEnum(day);
        //    EvaluateEnum(cc);
        //    Console.ReadLine();
        //}

        // This method will print out the details of any enum.
        static void EvaluateEnum(System.Enum e)
        {
            Console.WriteLine("=> Information about {0}", e.GetType().Name);
            Console.WriteLine("Underlying storage type: {0}",
            Enum.GetUnderlyingType(e.GetType()));
            // Get all name-value pairs for incoming parameter.
            Array enumData = Enum.GetValues(e.GetType());
            Console.WriteLine("This enum has {0} members.", enumData.Length);
            // Now show the string name and associated value, using the D format
            // flag (see Chapter 3).
            for (int i = 0; i < enumData.Length; i++)
            {
                Console.WriteLine("Name: {0}, Value: {0:D}",
                enumData.GetValue(i));
            }
            Console.WriteLine();
        }
        #endregion

        #region Declaring enum Variables

        //    static void Main(string[] args)
        //    {
        //        Console.WriteLine("**** Fun with Enums *****");
        //        // Make a contractor type.
        //        EmpType emp = EmpType.Contractor;
        //        AskForBonus(emp);
        //        // Print storage for the enum.
        //        Console.WriteLine("EmpType uses a {0} for storage",
        //        Enum.GetUnderlyingType(emp.GetType()));
        //        Console.ReadLine();
        //    }
        // Enums as parameters.
        static void AskForBonus(EmpType e)
        {
            switch (e)
            {
                case EmpType.Manager:
                    Console.WriteLine("How about stock options instead?");
                    break;
                case EmpType.Grunt:
                    Console.WriteLine("You have got to be kidding...");
                    break;
                case EmpType.Contractor:
                    Console.WriteLine("You already get enough cash...");
                    break;
                case EmpType.VicePresident:
                    Console.WriteLine("VERY GOOD, Sir!");
                    break;
            }
        }
        #endregion

        #region Invoking Methods Using Named Parameters
        static void DisplayFancyMessage(ConsoleColor textColor, ConsoleColor backgroundColor, string message)
        {
            // Store old colors to restore after message is printed.
            ConsoleColor oldTextColor = Console.ForegroundColor;
            ConsoleColor oldbackgroundColor = Console.BackgroundColor;
            // Set new colors and print message.
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(message);
            // Restore previous colors.
            Console.ForegroundColor = oldTextColor;
            Console.BackgroundColor = oldbackgroundColor;
        }
        #endregion

        #region Defining Optional Parameters
        static void EnterLogData(string message, string owner = "Programmer")
        {
            Console.Beep();
            Console.WriteLine("Error: {0}", message);
            Console.WriteLine("Owner of Error: {0}", owner);
        }
        #endregion

        #region The params Modifier
        // Return average of "some number" of doubles.
        static double CalculateAverage(params double[] values)
        {
            Console.WriteLine("You sent me {0} doubles.", values.Length);
            double sum = 0;
            if (values.Length == 0)
                return sum;
            for (int i = 0; i < values.Length; i++)
                sum += values[i];
            return (sum / values.Length);
        }
        #endregion

        #region ref Locals and Returns (New)
        // Returns the value at the array position.
        public static string SimpleReturn(string[] strArray, int position)
        {
            return strArray[position];
        }
        // Returning a reference.
        public static ref string SampleRefReturn(string[] strArray, int position)
        {
            return ref strArray[position];
        }
        #endregion

        #region The ref Modifier
        // Reference parameters.
        public static void SwapStrings(ref string s1, ref string s2)
        {
            string tempStr = s1;
            s1 = s2;
            s2 = tempStr;
        }
        #endregion

        #region The out Modifier (Updated)
        static void Add(int x, int y, out int ans)
        {
            ans = x + y;
        }
        // Returning multiple output parameters.
        static void FillTheseValues(out int a, out string b, out bool c)
        {
            a = 9;
            b = "Enjoy your string.";
            c = true;
        }
        #endregion

        #region The Default by Value Parameter-Passing Behavior
        // Arguments are passed by value by default.
        //static int Add(int x, int y)
        //{
        //    int ans = x + y;
        //    // Caller will not see these changes
        //    // as you are modifying a copy of the
        //    // original data.
        //    x = 10000;
        //    y = 88888;
        //    return ans;
        //}
        #endregion
    }
}
