using System;
using System.Threading;

namespace QueueExtended
{
    static class Program
    {
        static QueueExtended<int> Element = new QueueExtended<int>();
        static void Main(string[] args)
        {

            Thread thread1 = new Thread(Test_pop);
            thread1.Start();
            Thread thread2 = new Thread(Test_push);
            thread2.Start();            

            Console.ReadKey();
        }

        public static void Test_pop()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Element.Pop());
            }

        }

        public static void Test_push()
        {
            for (int i = 0; i < 10; i++)
            {
                Element.Push(i);
            }
        }
    }
}
