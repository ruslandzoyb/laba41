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
            ThreadArray thread = new ThreadArray(100, 5,4);
            thread.Run();
            
            Thread.Sleep(200);
            //thread.Time();
          //  Console.WriteLine( $"Time {thread.nev.ToLongTimeString()} + {thread.off.ToLongTimeString()} ");


           /* for (int i = 0; i < 150; i++)
            {
                Console.WriteLine($"{thread[i]} {i}");
            }*/

            Console.ReadKey();
        }
    }
}
