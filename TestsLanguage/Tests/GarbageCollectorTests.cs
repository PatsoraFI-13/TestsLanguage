using NUnit.Framework;

[TestFixture]
public class GarbageCollectorTests
{
    [Test]
    public void MemoryAllocation_ExceedingLimit()
    {
        // Створення об'єктів до тих пір, поки не вийде за межі доступної пам'яті
        while (true)
        {
            var obj = new byte[1024 * 1024]; // Виділення 1 МБ пам'яті

            // Перевірка, чи відбулося очищення пам'яті
            if (obj == null)
                break;
        }

        // Успішно очищено пам'ять, якщо код досяг цієї точки
        Assert.Pass();
    }
}
