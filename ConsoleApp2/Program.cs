class Program
{
    static void Main()
    {
        FunctionCache<string, int> cache = new FunctionCache<string, int>();

        FunctionCache<string, int>.Func expensiveFunction = key =>
        {
            Console.WriteLine($"Calculating result for key: {key}");
            return key.Length;
        };

        string key1 = "Hello";
        string key2 = "World";

        int result1 = cache.GetOrAdd(key1, expensiveFunction, TimeSpan.FromSeconds(10));
        Console.WriteLine($"Result for key1: {result1}");

        
        int result1FromCache = cache.GetOrAdd(key1, expensiveFunction, TimeSpan.FromSeconds(10));
        Console.WriteLine($"Cached result for key1: {result1FromCache}");

        
        System.Threading.Thread.Sleep(11000);

        int result2 = cache.GetOrAdd(key2, expensiveFunction, TimeSpan.FromSeconds(10));
        Console.WriteLine($"Result for key2: {result2}");
    }
}