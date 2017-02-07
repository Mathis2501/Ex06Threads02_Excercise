using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex06Threads02_Excercise
{
    class Consumer
    {
        AutoResetEvent waitHandle = new AutoResetEvent(false);

        public static void ConsumeCustomer()
        {
            while (true)
            {
                Thread.Sleep(1234);
                lock (Program.lockThis)
                {
                    if (Program.nextNmbr.Count >= 1)
                    {
                        
                        Console.WriteLine(Program.nextNmbr[0] + " has been consumed");
                        Program.nextNmbr.RemoveAt(0);
                    }
                }
                Program.WakeProducer.Set();
                if (Program.nextNmbr.Count > 0)
                {
                    Program.WakeConsumer.WaitOne();
                }
            }
        }
    }
}
