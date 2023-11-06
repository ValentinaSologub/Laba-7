using ConsoleApp3;

class Program
{
    static void Main()
    {
        TaskScheduler<string, int> taskScheduler = new TaskScheduler<string, int>(task => task.Length);

        
        while (true)
        {
            Console.Write("Enter a task (or 'exit' to quit): ");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                break;
            }

            taskScheduler.EnqueueTask(input);
        }

        
        Console.WriteLine("Executing tasks:");
        while (true)
        {
            taskScheduler.ExecuteNext(task => Console.WriteLine($"Task: {task}"));
            Console.WriteLine("Press Enter to continue or 'exit' to quit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "exit")
            {
                break;
            }
        }
    }
}