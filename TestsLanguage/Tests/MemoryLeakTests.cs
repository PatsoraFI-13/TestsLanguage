using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class MemoryLeakTests
{
    private List<int> leakedList;

    [SetUp]
    public void SetUp()
    {
        leakedList = new List<int>();
    }

    [TearDown]
    public void TearDown()
    {
        leakedList = null;
    }

    [Test]
    public void MemoryLeak()
    {
        for (int i = 0; i < 1000000; i++)
        {
            leakedList.Add(i);
        }

        // Тут не відбувається очищення пам'яті leakedList,
        // тому це може призвести до пам'яткового утіку
    }
}
