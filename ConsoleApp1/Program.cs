using ConsoleApp1;

class Program
{
    static void Main()
    {
        
        Repository<string> stringRepository = new Repository<string>();

        stringRepository.Add("Apple");
        stringRepository.Add("Banana");
        stringRepository.Add("Cherry");
        stringRepository.Add("Date");

        
        Repository<string>.Criteria<string> startsWithA = item => item.StartsWith("A");
        List<string> resultStrings = stringRepository.Find(startsWithA);

        Console.WriteLine("Рядки, які починаються на 'A':");
        foreach (string item in resultStrings)
        {
            Console.WriteLine(item);
        }

        
        Repository<int> intRepository = new Repository<int>();

        intRepository.Add(5);
        intRepository.Add(10);
        intRepository.Add(15);
        intRepository.Add(20);

        
        Repository<int>.Criteria<int> isEven = item => item % 2 == 0;
        List<int> resultIntegers = intRepository.Find(isEven);

        Console.WriteLine("Парні цілі числа:");
        foreach (int item in resultIntegers)
        {
            Console.WriteLine(item);
        }
    }
}
