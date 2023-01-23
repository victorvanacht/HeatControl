using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HeatControl
{
    public class CommandQueue
    {
        public class CommandQueueItem
        {
            public string command;
            public int retryAttempts;
            public int maxRetryAttempts;
            public long enqueTick;
            public long lastTransmitAttemptTick;
            public long retryDelayTicks;

            public CommandQueueItem(string command) : this(command, 10, 3 * System.TimeSpan.TicksPerSecond) { }

            public CommandQueueItem(string command, int maxRetryAttempts, long retryDelayTicks)
            {
                this.command = command;
                this.retryAttempts = 0;
                this.maxRetryAttempts = maxRetryAttempts;
                this.enqueTick = DateTime.Now.Ticks;
                this.retryDelayTicks = retryDelayTicks;
            }

        }
        private ConcurrentQueue<CommandQueueItem> queue;

        public CommandQueue()
        {
            this.queue = new ConcurrentQueue<CommandQueueItem>();
        }


        public void EnqueueCommand(string command)
        {
            CommandQueueItem item = new CommandQueueItem(command);
            queue.Enqueue(item);
        }

        public bool TryDequeueCommand(string command)
        {
            if (!queue.IsEmpty)
            {
                CommandQueueItem firstItem;
                if (queue.TryPeek(out firstItem))
                {
                    if ((command.Length >= 2) && (firstItem.command.Length >= 2))
                    {
                        if (command.Substring(0, 2).ToUpper().Equals(firstItem.command.Substring(0, 2).ToUpper()))
                        {
                            return queue.TryDequeue(out firstItem);
                        }
                    }
                }
            }
            return false;
        }

        public bool IsEmpty()
        {
            return this.queue.IsEmpty;
        }

        public bool TryDequeue(out CommandQueueItem result)
        {
            return this.queue.TryDequeue(out result);
        }

        public bool TryPeek(out CommandQueueItem result)
        {
            return this.queue.TryPeek(out result);
        }
    }   
}
