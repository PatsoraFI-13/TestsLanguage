public struct ExampleStruct
{
    public int Value { get; set; }
}

[TestFixture]
public class StackHeapTests
{
    [Test]
    public void StackAllocation()
    {
        long memoBefor = GC.GetTotalMemory(true);
        var value = new ExampleStruct();
        long memoAfter = GC.GetTotalMemory(true);
        long delta = memoBefor - memoAfter; 
        Assert.AreEqual(0, delta);
    }

    [Test]
    public void HeapAllocation()
    {
        long memoBefor = GC.GetTotalMemory(true);
        var reference = new SimpleClass();
        long memoAfter = GC.GetTotalMemory(true);
        long delta = memoBefor - memoAfter;
        Assert.Greater(delta, 0);
    }
}
