using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
public class TaskScheduler<TTask, TPriority>
    {
        private SortedDictionary<TPriority, Queue<TTask>> taskQueue = new SortedDictionary<TPriority, Queue<TTask>>();
        private Func<TTask, TPriority> prioritySelector;

        public delegate void TaskExecution<TTask>(TTask task);

        public TaskScheduler(Func<TTask, TPriority> prioritySelector)
        {
            this.prioritySelector = prioritySelector;
        }

        public void EnqueueTask(TTask task)
        {
            TPriority priority = prioritySelector(task);
            if (!taskQueue.ContainsKey(priority))
            {
                taskQueue[priority] = new Queue<TTask>();
            }
            taskQueue[priority].Enqueue(task);
        }

        public void ExecuteNext(TaskExecution<TTask> executeTask)
        {
            if (taskQueue.Count > 0)
            {
                var highestPriority = taskQueue.Keys.Max();
                var nextTask = taskQueue[highestPriority].Dequeue();

                executeTask(nextTask);

                if (taskQueue[highestPriority].Count == 0)
                {
                    taskQueue.Remove(highestPriority);
                }
            }
            else
            {
                Console.WriteLine("No tasks to execute.");
            }
        }
    }
}

