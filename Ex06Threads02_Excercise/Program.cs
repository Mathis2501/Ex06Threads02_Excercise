using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex06Threads02_Excercise
{
    class Program
    {
        internal static AutoResetEvent WakeProducer = new AutoResetEvent(true);
        internal static AutoResetEvent WakeConsumer = new AutoResetEvent(true);
        internal static object lockThis = new object();
        internal static List<int> nextNmbr = new List<int>();

        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Run();
        }

        private void Run()
        {
            Thread prodThread = new Thread(Producer.ProduceCustomer);
            Thread consThread = new Thread(Consumer.ConsumeCustomer);

            prodThread.Start();
            consThread.Start();
        }
    }
}
