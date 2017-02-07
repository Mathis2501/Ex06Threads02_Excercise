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
            int sleeptime = 10;
            while (true)
            {
                
                //if (Program.nextNmbr.Count > 0)
                //{
                //    sleeptime = 1000;
                //}
                //else
                //{
                //    sleeptime = 0;
                //}
                lock (Program.lockThis)
                {
                    if (Program.nextNmbr.Count > 0)
                    {
                        sleeptime = 1000;
                        Console.WriteLine(Program.nextNmbr[0] + " has been consumed");
                        Program.nextNmbr.RemoveAt(0);
                    }
                    else
                    {
                        sleeptime = 10;
                    }
                }
                Thread.Sleep(sleeptime);
                Program.WakeProducer.Set();
                if (Program.nextNmbr.Count <= 0)
                {
                    Program.WakeConsumer.WaitOne();
                }
            }
        }
    }
}
