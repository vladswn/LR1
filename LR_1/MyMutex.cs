using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LR_1
{
    public class MyMutex
    {
        static Mutex mutex = new Mutex();
        static int count = 0;
        void StartMutex()
        {
            mutex.WaitOne();
            for(int i = 0; i< 10;i++)
            {
                count++;
                Console.Write("{0} : {1} ", Thread.CurrentThread.Name, count);
                Thread.Sleep(50);
            }
            Console.WriteLine("\n");
            
            mutex.ReleaseMutex();
        }

        public void Print()
        {
            for (int i = 0; i < 5; i++)
            {
                    Thread th = new Thread(StartMutex);
                    th.Name = "Поток " + i.ToString();
                    th.Start();

            }
        }
    }
}
