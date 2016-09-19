using System;
using System.Collections.Generic;
using System.Threading;

namespace QueueExtended
{
    internal class QueueExtended<T>
    {
        private readonly Queue<T> queue = new Queue<T>();

        public T Pop()
        {
            lock (queue)
            {
                while (queue.Count == 0)
                {
                    Monitor.Wait(queue);
                }

                return queue.Dequeue();
            }
        }

        public void Push(T data)
        {
            lock (queue)
            {
                queue.Enqueue(data);
                Console.WriteLine("записал число {0}", data);
                Monitor.Pulse(queue);
            }
        }
    }
}
