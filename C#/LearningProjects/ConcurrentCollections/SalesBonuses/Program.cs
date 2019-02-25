using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConcurrentCollections.SalesBonuses {

    class Program {
        public static readonly List<string> AllShirtNames = new List<string> {
            "techHour",
            "Code school",
            "jDays",
            "iGeek",
            "Redley",
        };

        static void Main(string[] args) {
            StaffLogsForBonuses staffLogs = new StaffLogsForBonuses();
            //ToDoQueue todoQueue = new ToDoQueue(staffLogs);
            ToDoQueueBlockingCollection todoQueue = new ToDoQueueBlockingCollection(staffLogs);

            SalesPerson[] people = {
                new SalesPerson("Mui"),
                new SalesPerson("Thais"),
                new SalesPerson("Wesley"),
                new SalesPerson("Carolayne")
            };

            StockController controller = new StockController(todoQueue);
            TimeSpan workDay = new TimeSpan(0, 0, 1);

            Task t1 = Task.Run(() => people[0].Work(controller, workDay));
            Task t2 = Task.Run(() => people[1].Work(controller, workDay));
            Task t3 = Task.Run(() => people[2].Work(controller, workDay));
            Task t4 = Task.Run(() => people[3].Work(controller, workDay));

            Task bonusLogger = Task.Run(() => todoQueue.MonitorAndLogTrades());
            Task bonusLogger2 = Task.Run(() => todoQueue.MonitorAndLogTrades());

            Task.WaitAll(t1, t2, t3, t4);
            todoQueue.CompleteAdding();
            Task.WaitAll(bonusLogger, bonusLogger2);

            controller.DisplayStatus();
            staffLogs.DisplayReport(people);
        }
    }
}