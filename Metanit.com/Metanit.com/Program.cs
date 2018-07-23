using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metanit.com
{
    class tryCatchFinally
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };
            ref int numberRef = ref Find(4, numbers); // ищем число 4 в массиве
            numberRef = 9; // заменяем 4 на 9
            Console.WriteLine(numbers[3]); // 9

            Console.Read();
        }
        static ref int Find(int number, int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
                if (numbers[i] == number)
                    return ref numbers[i]; // возвращаем ссылку на адрес, а не само значение
            throw new IndexOutOfRangeException("число не найдено");
        }
    }
    class Structures
    {
        //static void Main(string[] args)
        //{
        //    Book[] books = new Book[]
        //    {
        //        new Book("Война и мир", "Л. Н. Толстой", 1869),
        //        new Book("Преступление и наказание", "Ф. М. Достоевский", 1866),
        //        new Book("Отцы и дети", "И. С. Тургенев", 1862)
        //    };
        //    books[3].name = "Отцы и дети";
        //    books[3].author = "И. С. Тургенев";
        //    books[3].year = 1862;

        //    foreach (Book b in books)
        //    {
        //        b.Info();
        //    }

        //    Console.ReadLine();
        //}
        struct Book
        {
            public string name;
            public string author;
            public int year;

            public Book(string n, string a, int y)
            {
                name = n;
                author = a;
                year = y;
            }

            public void Info()
            {
                Console.WriteLine($"Книга '{name}' (автор {author}) была издана в {year} году");
            }
        }
    }
    class enumM
    {
        enum Days
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        enum Time : byte
        {
            Morning,
            Afternoon,
            Evening,
            Night
        }
        enum Operation
        {
            Add = 1,
            Subtract,
            Multiply,
            Divide
        }
        static void MathOp(double x, double y, Operation op)
        {
            double result = 0.0;

            switch (op)
            {
                case Operation.Add:
                    result = x + y;
                    break;
                case Operation.Subtract:
                    result = x - y;
                    break;
                case Operation.Multiply:
                    result = x * y;
                    break;
                case Operation.Divide:
                    result = x / y;
                    break;
            }

            Console.WriteLine("Результат операции равен {0}", result);
        }

    }
    class Recursive // начало контекста класса
    {
        static int a = 9; // переменная уровня класса

        void Display() // начало контекста метода Display
        {
            // переменная a определена в контексте класса, поэтому доступна
            int d = a + 1;

        } // конец конекста метода Display, переменная d уничтожается

        static int Factorial(int x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return x * Factorial(x - 1);
            }
        }
        static int Fibonachi(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return Fibonachi(n - 1) + Fibonachi(n - 2);
            }
        }

    } // конец контекста класса, переменная a уничтожается
    public class Kata
    {

        static void Addition(params int[] integers)
        {
            int result = 0;
            for (int i = 0; i < integers.Length; i++)
            {
                result += integers[i];
            }
            Console.WriteLine(result);
        }
        static void GetData(int x, int y, out int area, out int perim)
        {
            area = x * y;
            perim = (x + y) * 2;
        }
        static void Sum(int x, int y, out int a)
        {
            a = x + y;
        }
        static int OptionalParam(string x, string y, int z = 5, int s = 4)
        {
            return int.Parse(x) + int.Parse(y) + z + s;
        }
        static string GetHello() => ("hello");
        static string GetHellso() => "hello";
        static string Method1()
        {
            return "Hello, world!";
        }
        static void Method2()
        {
            Console.WriteLine("Method2");
        }
    }
}
