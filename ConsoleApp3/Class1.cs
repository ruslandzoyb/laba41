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

        private readonly Thread[] Threads;
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

           

               Parallel.For(0, Threads.Length, new ParallelOptions() { MaxDegreeOfParallelism = proccesor }, i =>
            {

                Threads[i].Start();
              
            }


            );
            //Thread.Sleep(500);

            //Time();


           
          

        }

        public void TimeOn()
        {
            nev = DateTime.Now;
        }
        public void TimeOff()
        {
            off = DateTime.Now;

            // Console.BackgroundColor = ConsoleColor.Red;
            // Console.WriteLine(Array[999999]+"  ");
           
            Console.WriteLine(off-nev);
           
        }

        private void Initiliaz()
        {



            lock (locker)
            {
                end += valForThread;
                for (int j = start; j < end; j++)
                {
                    if (j==9999)
                    {
                        Array[j] = 69;
                    }
                    else
                    {
                        Array[j] =  r.Next(2, 10);
                        // Console.WriteLine($"{j} {Array[j]} {Thread.CurrentThread.Name}");
                    }




                }
                start = end;
            }
            //off = DateTime.Now;
            


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
