using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LR_1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMutex m = new MyMutex();
            MySemaphore ms = new MySemaphore();
            string f = "";
            do
            {
                Console.WriteLine("Mutex - Нажмите '1' \nSemaphore - Нажмите '2' ");
                int a = int.Parse(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        m.Print();
                        break;
                    case 2:
                        ms.Semafor();
                        break;
                }

                while (f != "y" || f != "n")
                {
                    Console.WriteLine("Продолжить работу? (y/n)");
                    f = Console.ReadLine();
                    if (f == "y" || f == "n") break;
                }
            } while (f == "y");
        }
    }
}

