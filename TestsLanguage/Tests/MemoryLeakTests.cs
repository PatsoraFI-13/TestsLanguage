using NUnit.Framework;

[TestFixture]
public class MemoryLeakTests
{
    private WeakReference leakedListReference;

    [SetUp]
    public void SetUp()
    {
        leakedListReference = new WeakReference(new List<int>());
    }

    [TearDown]
    public void TearDown()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
    }

    [Test]
    public void MemoryLeak()
    {
        for (int i = 0; i < 1000000; i++)
        {
            leakedListReference.Target = new List<int>();
        }

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        // Перевірка, чи залишається leakedList у пам'яті
        if (leakedListReference.IsAlive)
        {
            // Пам'ятковий утік: leakedList не звільнений
            Assert.Fail();
        }
        else
        {
            // Успішно звільнено пам'ять, тест пройшов
            Assert.Pass();
        }
    }
}
