using NUnit.Framework;

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
        ExampleStruct stackObj = new ExampleStruct();
        stackObj.Value = 10;

        Assert.AreEqual(10, stackObj.Value);
    }

    [Test]
    public void HeapAllocation()
    {
        SimpleClass heapObj = new SimpleClass();
        heapObj.Value = 10;

        SimpleClass heapObj2 = heapObj;
        heapObj2.Value = 20;

        Assert.AreNotEqual(heapObj.Value, heapObj2.Value);
    }
}
