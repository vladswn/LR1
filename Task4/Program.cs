using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task4
{
    public class Shares
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
    }

    public class Traidning
    {
        //double cost; 
        double newPrice;
        List<Shares> shares;

        public Traidning()
        {
            shares = new List<Shares>();

        }

        public void AddShares(string name, double price, int count)
        {
            shares.Add(new Shares { Name = name, Price = price, Count = count });
            shares.Add(new Shares{ Name = "First", Price = 120, Count = 100 });
        }

        public void Print()
        {
            foreach(var i in shares)
            {
                Console.WriteLine($"{i.Name} " );
            }
        }

        public int GetLength()
        {
            return shares.Count();
        }

        public double StartingPrice(string name)
        {
            var a = shares.Where(s=> s.Name == name).Select(s => s).First();
            return a.Price;
        }

        public void RealPrice(string name)
        {

            var a = shares.Where(s => s.Name == name).Select(s => s).First();
            newPrice = a.Price - 25;
            // newPrice = (a.Count * 1.5 + a.Price * 0.5); 
            Console.WriteLine(newPrice);
        }

        public double Buy(double count, string name)
        {
            var a = shares.Where(s => s.Name == name).Select(s => s).First();
            //var q = a.Price - 25;
            return a.Count - count;
        }
        

    }

    class Program
    {
        static void Main(string[] args)
        {
            Traidning t = new Traidning();
            t.AddShares("First", 220 , 100);
            t.AddShares("Second", 320, 100);

            //t.Print();

            Console.WriteLine($"Стартовая цена {t.StartingPrice("First")}");
            t.Buy(20, "First");
            Console.WriteLine("Новая цена");
            t.RealPrice("First");


            Console.WriteLine("Начало торогов");
            Console.WriteLine("Хотите купить акцию? нажмите 1");
            int a;
            a = int.Parse(Console.ReadLine());
            if(a==1)
            {
                for (int i = 1; i < t.GetLength(); i++)
                {
                    Reader reader = new Reader(i);
                  
                }

                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Торги завершены.");
            }
            t.StartingPrice("First");
        }
    
        class Reader
        {
            
            // создаем семафор
            static Semaphore sem = new Semaphore(2, 3);
            Thread myThread;
            int count = 2;
            


            public Reader(int i)
            {
                myThread = new Thread(Read);
                myThread.Name = "Акции." + i.ToString();
                myThread.Start();
            }
           
            public void Read()
            {
                Traidning t = new Traidning();
                while (count > 0)
                {
                    sem.WaitOne();

                    Console.WriteLine("{0} Продажа акций", Thread.CurrentThread.Name);

                    Console.WriteLine("{0} выполнение сделки", Thread.CurrentThread.Name);
                    Thread.Sleep(1000);


                    Console.WriteLine("{0} Конец сделки. Успешно завершена", Thread.CurrentThread.Name);

                    sem.Release();

                    count--;
                    Thread.Sleep(1000);
                }
            }
        }
    }

}
