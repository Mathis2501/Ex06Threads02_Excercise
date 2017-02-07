using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex06Threads02_Excercise
{
    class Producer
    {
        internal int PrevProduced;
        

        public static void ProduceCustomer()
        {
            Producer Prod = new Producer();
            while (true)
            {
                Thread.Sleep(20);
                lock (Program.lockThis)
                {
                    if (Program.nextNmbr.Count <= 100)
                    {
                        
                        Prod.PrevProduced++;
                        Program.nextNmbr.Add(Prod.PrevProduced);
                        Console.WriteLine("Next number to take: " + Prod.PrevProduced);
                    }
                }
                Program.WakeConsumer.Set();
                if (Program.nextNmbr.Count >= 100)
                {
                    Program.WakeProducer.WaitOne();
                }

            }
        }
    }
}
