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
        var obj = new ExampleStruct();
        Assert.IsFalse(obj.GetType().IsValueType == false);
    }

    [Test]
    public void HeapAllocation()
    {
        SimpleClass obj = new SimpleClass();
        Assert.IsTrue(obj.GetType().IsValueType == false);
    }

}
