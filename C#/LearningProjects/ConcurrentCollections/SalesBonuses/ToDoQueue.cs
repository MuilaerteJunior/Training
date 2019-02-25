using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ConcurrentCollections.SalesBonuses {
    public class ToDoQueue {
        private readonly ConcurrentQueue<Trade> _queue = new ConcurrentQueue<Trade>();
        private bool _workingDayComplete = false;
        private readonly StaffLogsForBonuses _staffLogs;

        public ToDoQueue(StaffLogsForBonuses staffResults) {
            _staffLogs = staffResults;
        }

        public void AddTrade(Trade transaction) {
            _queue.Enqueue(transaction);
        }

        public void CompleteAdding() {
            _workingDayComplete = true;
        }

        /// <summary>
        /// This method will do the work to monitoring the queue 
        /// and make sure that all task will be processed.
        /// This method uses a pooling concept.
        /// </summary>
        public void MonitorAndLogTrades() {
            while (true) {
                Trade nextTrade;
                bool done = _queue.TryDequeue(out nextTrade);
                if ( done ) {
                    _staffLogs.ProcessTrade(nextTrade);
                    Console.WriteLine("Processing Transaction from: "+ nextTrade.Person.Name);
                } else if ( _workingDayComplete ) {
                    Console.WriteLine("No more sales to log - exiting");
                    return;
                } else {
                    Console.WriteLine("No transactions available");
                    Thread.Sleep(500);
                }
            }
        }
    }
}