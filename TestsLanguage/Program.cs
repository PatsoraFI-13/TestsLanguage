class Program
{
    static void Main()
    {
        // 1) Демонстрація передачі значень за посиланням та за значенням
        int value = 10;
        SimpleClass reference = new SimpleClass();

        ModifyValue(value);
        ModifyReference(reference);

        Console.WriteLine("Value after modification: " + value);
        Console.WriteLine("Reference after modification: " + reference.Value);

        // 2) Створення об'єкту на стеку та на хіпі
        int valueOnStack = 10;
        SimpleClass referenceOnHeap = new SimpleClass();

        // 3) Робота garbage collector
        for (int i = 0; i < 10; i++)
        {
            SimpleClass obj = new SimpleClass();
        }
        GC.Collect();
        GC.WaitForPendingFinalizers();

        // 4) Демонстрація явища memory leak:
        string wishOfMemoryLeak;
        do
        {
            Console.Write("Do you want test memory leak?(y/n) ");
            wishOfMemoryLeak = Console.ReadLine();
        }
        while (!wishOfMemoryLeak.Equals("y") && !wishOfMemoryLeak.Equals("n"));

        if (wishOfMemoryLeak.Equals("y"))
        {
            Console.WriteLine("\nwait");
            List<SimpleClass> list = new List<SimpleClass>();
            while (true)
            {
                SimpleClass obj = new SimpleClass();
                list.Add(obj);
            }
        }
    }

    static void ModifyValue(int num)
    {
        num = 20;
    }

    static void ModifyReference(SimpleClass obj)
    {
        obj.Value = 20;
    }
}