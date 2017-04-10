using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LR_1
{
    class MySemaphore
    {
        private static Semaphore _pool;
        private static int _padding;

        public void Semafor()
        {
            Console.WriteLine("Input timeout sleep:");
            int timeoutsleep;
            timeoutsleep = int.Parse(Console.ReadLine());

            _pool = new Semaphore(0, 3);
            for (int i = 1; i <= 5; i++)
            {
                Thread t = new Thread(new ParameterizedThreadStart(Worker));
                t.Start(i);
            }
            Thread.Sleep(timeoutsleep);
            Console.WriteLine("Main thread calls Release(3).");
            _pool.Release(3);
            Console.WriteLine("Main thread exits.");
        }

        private static void Worker(object num)
        {
            Console.WriteLine("Thread {0} begins " +
            "and waits for the semaphore.", num);
            _pool.WaitOne();
            int padding = Interlocked.Add(ref _padding, 1000);
            Console.WriteLine("Thread {0} enters the semaphore.", num);
            Thread.Sleep(1000 + padding);
            Console.WriteLine("Thread {0} releases the semaphore.", num);
            Console.WriteLine("Thread {0} previous semaphore count: {1}",
            num, _pool.Release());
        }
    }
}
