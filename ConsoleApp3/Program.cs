using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Thread.CurrentThread.Name = "Main";

            ThreadArray thread = new ThreadArray(1500000,500,4);
            var one = DateTime.Now;
            var th1 = new Thread(Go);
            
            DateTime first = DateTime.Now;
            th1.Start(thread);
           th1.Join();

            var two = DateTime.Now;

            Console.WriteLine($" Second {two-one} ");
            
                        
           
            Thread.Sleep(200);

           
            // Console.WriteLine(second-first);
            /* for (int i = 0; i < 100; i++)
             {

                 if (thread[i]==0)
                 {
                     Console.BackgroundColor = ConsoleColor.Red;
                     Console.WriteLine($"{thread[i]} {i}");
                     Console.ResetColor();
                 }

             }*/
            Console.WriteLine("ENd");
          //  thr.Start();
           // Console.WriteLine("dggdrgdrg");
                     
                                                                        
                                            
                                  

            Console.ReadKey();
        }
        static void Start()
        {
            for (int i = 0; i < 1000000; i++)
            {
                Console.WriteLine(i);
            }
        }
        static void Go(object array) {

            var arr = (ThreadArray)array;
            arr.TimeOn();
            arr.Run();
            
            arr.TimeOff();
            Console.WriteLine(arr.Average());
            //Thread.Sleep(100);
        }
        
    }
}
