using NUnit.Framework;

[TestFixture]
public class ValueReferenceTests
{
    [Test]
    public void PassByReference_ReferenceType()
    {
        SimpleClass obj1 = new SimpleClass();
        obj1.Value = 10;

        SimpleClass obj2 = obj1;
        obj2.Value = 20;

        Assert.AreEqual(obj1.Value, obj2.Value);
    }

    [Test]
    public void PassByValue_ValueType()
    {
        int num1 = 10;
        int num2 = num1;
        num2 = 20;

        Assert.AreNotEqual(num1, num2);
    }
}
