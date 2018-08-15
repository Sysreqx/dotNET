using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7._0_in_a_Nutshell_Delegates
{
    class Program
    {
        //public delegate int Transformer(int x);
        public delegate void ProgressReporter(int percentComplete);
        public delegate T Transformer<T>(T arg);
        class Util
        {
            //public static void Transform(int[] values, Transformer t)
            //{
            //    for (int i = 0; i < values.Length; i++)
            //        values[i] = t(values[i]);
            //}
            public static void HardWork(ProgressReporter p)
            {
                for (int i = 0; i < 10; i++)
                {
                    p(i * 10); // Invoke delegate
                    System.Threading.Thread.Sleep(100); // Simulate hard work
                }
            }
            public static void Transform<T>(T[] values, Transformer<T> t)
            {
                for (int i = 0; i < values.Length; i++)
                    values[i] = t(values[i]);
            }
        }
        class Test
        {
            //#region Transform
            //static void Main()
            //{
            //    int[] values = { 1, 2, 3 };
            //    Util.Transform(values, Square); // Hook in the Square method
            //    foreach (int i in values)
            //        Console.Write(i + " "); // 1 4 9
            //    Console.ReadLine();
            //}
            ////#endregion

            //#region ProgressReporter
            //static void Main()
            //{
            //    ProgressReporter p = WriteProgressToConsole;
            //    p += WriteProgressToFile;
            //    Util.HardWork(p);
            //}
            ////#endregion
            #region Delegates Versus Interfaces
            public interface ITransformer
            {
                int Transform(int x);
            }
            public class Util
            {
                public static void TransformAll(int[] values, ITransformer t)
                {
                    for (int i = 0; i < values.Length; i++)
                        values[i] = t.Transform(values[i]);
                }
            }
            class Squarer : ITransformer
            {
                public int Transform(int x) => x * x;
            }
            #endregion
            #region ProgressReporter
            static void Main()
            {
                //#region GDT
                //X x = new X();
                //ProgressReporter p = x.InstanceProgress;
                //p(99); // 99
                //Console.WriteLine(p.Target == x); // True
                //Console.WriteLine(p.Method); // Void InstanceProgress(Int32)
                //#endregion
                //#region Generic Delegate Types
                //int[] values = { 1, 2, 3 };
                //Util.Transform(values, Square); // Hook in Square
                //foreach (int i in values)
                //    Console.Write(i + " "); // 1 4 9    
                //#endregion
                #region The Func and Action Delegates
                int[] values = { 1, 2, 3 };
                Util.TransformAll(values, new Squarer());
                foreach (int i in values)
                    Console.WriteLine(i);
                #endregion
                Console.ReadLine();
            }
            #endregion


            // Methods.
            static void WriteProgressToConsole(int percentComplete)
            => Console.WriteLine(percentComplete);
            static void WriteProgressToFile(int percentComplete)
            => System.IO.File.WriteAllText("progress.txt",
            percentComplete.ToString()); // Why only 90?
            static int Square(int x) => x * x;
        }
        class X
        {
            public void InstanceProgress(int percentComplete)
            => Console.WriteLine(percentComplete);
        }
    }
}
