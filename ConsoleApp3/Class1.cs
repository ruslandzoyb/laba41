using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class ThreadArray
    {

        private Thread[] Threads;
        private int[] Array;
        private readonly int arrSize;
        private readonly int threadCount;
        private readonly int proccesor;
        private int valForThread;
        private static Random r = new Random();
        private int start = 0;
        private int end = 0;
        public int begin=0;
        public DateTime nev;
        public DateTime off;
        static object locker = new object();

        public ThreadArray(int arrSize, int threadCount, int proccesor)
        {
            if (arrSize <= 0 || threadCount <= 0 || proccesor <= 0)
            {
                throw new Exception("Менее ,или == 0");
            }
            this.arrSize = arrSize;
            this.threadCount = threadCount;
            this.proccesor = proccesor;

            if (arrSize % threadCount == 0)
            {
                valForThread = arrSize / threadCount;
            }
            else
            {
                throw new Exception("");
            }
            Threads = new Thread[threadCount];
            Array = new int[arrSize];

            for (int i = 0; i < Threads.Length; i++)
            {
                Threads[i] = new Thread(Initiliaz);
                Threads[i].Name = "Thread " + i.ToString();
                //


            }
        }
        public void Run()
            


        {
           
           
            nev = DateTime.Now;
            Parallel.For(0, Threads.Length, new ParallelOptions() { MaxDegreeOfParallelism = proccesor }, i =>
            {

                Threads[i].Start();
               
            }


            );



            off = DateTime.Now;
            Time();
        }
        public void Time()
        {
            Console.WriteLine(off.Millisecond-nev.Millisecond);
           
        }

        private void Initiliaz()
        {



            lock (locker)
            {
                end += valForThread;
                for (int j = start; j < end; j++)
                {
                    Array[j] = r.Next(1, 10);

                    Console.WriteLine($"{j} {Array[j]} {Thread.CurrentThread.Name}");

                }
                start = end;
            }

            


        }

        public int this [int index]
        {
            get
            {
                return Array[index];
            }
        }


    }
}
