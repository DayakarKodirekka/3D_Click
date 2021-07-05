using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BenchmarkLinqSelect
{

    class ClassA
    {
        public int Data { get; set; } = 0;
    }

    class ClassB
    {
        public int Data { get; set; } = 0;
    }

    struct SturctA
    {
        public int Data { get; set; }
    }

    struct StructB
    {
        public int Data { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // // Defining the random 
            Random r = new Random();

            // Adding data in form of a list

            int ln = 100;
            List<ClassA> inputList = new List<ClassA>(ln);
            for (int i = 0; i < ln; i++)
            {
                inputList.Add(item: new ClassA() { Data = r.Next() }); // make it random.
            }

            // Adding data in form of an Array

            ClassA[] inputObjArr = new ClassA[ln];
            for (int i = 0; i < inputObjArr.Length; i++)
            {
                inputObjArr[i] = new ClassA() { Data = r.Next() };
            }

            // Adding data in form of a Structure 

            SturctA[] inputSturctArr = new SturctA[ln];
            for (int i = 0; i < inputObjArr.Length; i++)
            {
                // inputArr[i].Data = r.Next();
                inputSturctArr[i] = new SturctA() { Data = r.Next() };
            }


            // Maybe StopWatch

            // Executon time calculation for Linq
            Stopwatch sw1 = Stopwatch.StartNew();
            List<ClassB> resultLinq = inputList.Select(r => new ClassB() { Data = r.Data + 10 }).ToList();
            // stop
            sw1.Stop();
            Console.WriteLine("Time Taken for Linq: {0}ms", (sw1.Elapsed.TotalMilliseconds) * 1000);

            // sw2
            // int nSamples = 100
            // for (100)
            Stopwatch sw2 = Stopwatch.StartNew();
            int n1 = 100;
            for (int i = 0; i < n1; i++)
            {
                List<ClassB> resultLinq1 = inputList.Select(r => new ClassB() { Data = r.Data + 10 }).ToList();
            }
            sw2.Stop();
            Console.WriteLine("Time Taken for 100th Linq: {0}ms", ((sw2.Elapsed.TotalMilliseconds) * 1000) / n1);

            // sw3
            Stopwatch sw3 = Stopwatch.StartNew();
            int n2 = 1000;
            for (int i = 0; i < n2; i++)
            {
                List<ClassB> resultLinq2 = inputList.Select(r => new ClassB() { Data = r.Data + 10 }).ToList();
            }
            sw3.Stop();

            Console.WriteLine("Time Taken for 1000th Linq: {0}ms", ((sw3.Elapsed.TotalMilliseconds) * 1000) / n2);
            // sw.Stop();

            // Execution time calculation using imperative method
            Stopwatch swi1 = Stopwatch.StartNew();
            List<ClassB> resultImp = new List<ClassB>(ln);
            // int j = 0;
            for (int i = 0; i < ln; i++)
            {
                resultImp.Add(new ClassB() { Data = inputList[i].Data + 10 }); // make it random.

            }
            swi1.Stop();
            Console.WriteLine("Time Taken for imperative method 1st iterattion: {0}ms", (swi1.Elapsed.TotalMilliseconds) * 1000);
            // if (j == 1)
            // {
            //     Console.WriteLine("Time Taken for imperative method 1st iterattion: {0}ms", (sw_i.Elapsed.TotalMilliseconds) * 1000);
            // }
            // else if (j == 100)
            // {
            //     Console.WriteLine("Time Taken for imperative method 100th iterattion: {0}ms", (sw_i.Elapsed.TotalMilliseconds) * 1000);

            // }
            // else if (j == 1000)
            // {
            //     Console.WriteLine("Time Taken for imperative method 1000th iterattion: {0}ms", (sw_i.Elapsed.TotalMilliseconds) * 1000);
            // }
            // sw_i.Stop();
            // Console.WriteLine("Time Taken for imperative method: {0}ms", sw_i.Elapsed.TotalMilliseconds);

            // Time calculation using arrays

            Stopwatch sw_a = Stopwatch.StartNew();
            ClassB[] resultObjArr = new ClassB[ln];
            for (int i = 0; i < inputObjArr.Length; i++)
            {
                resultObjArr[i] = new ClassB() { Data = inputObjArr[i].Data + 15 };
            }
            sw_a.Stop();
            Console.WriteLine($"Time Taken for array : {sw_a.Elapsed.TotalMilliseconds:0.000}ms");

            // Time calculation using Structures

            Stopwatch sw_s = Stopwatch.StartNew();
            StructB[] resultStructArr = new StructB[ln];
            for (int i = 0; i < inputSturctArr.Length; i++)
            {
                resultStructArr[i].Data = inputSturctArr[i].Data + 15;
                //resultStructArr[i] = new DataB() { Data = inputSturctArr[i].Data + 15 };
            }
            sw_s.Stop();
            Console.WriteLine($"Time Taken for structures :{sw_s.Elapsed.TotalMilliseconds:0.000}ms");
        }



    }
}

