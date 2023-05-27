class SimpleClass
{
    public int Value { get; set; }
    ~SimpleClass()
    {
        Console.WriteLine("Object finalized");
    }
}