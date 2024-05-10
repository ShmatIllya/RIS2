

public static class AppartementExtensions
{
    public static void SpecialMethod(this Appartement appartement, string specialParameter)
    {
        
        Console.WriteLine($"Вызван специальный метод для карты {appartement.Number} с параметром {specialParameter}");
    }
}
