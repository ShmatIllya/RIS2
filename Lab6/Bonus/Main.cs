using Bonus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

class Program
{
    static List<Appartement> appartements = new List<Appartement>();
    private static AppartementRep appartementRep = new AppartementRep();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("");
            Console.WriteLine("Выберите функцию:");
            Console.WriteLine("1. Загрузить информацию о квартирах из XML");
            Console.WriteLine("2. Сохранить информацию о квартирах в XML");
            Console.WriteLine("3. Просмотреть информацию о всех квартирах");
            Console.WriteLine("4. Зарегистрировать новую квартиру");
            Console.WriteLine("5. Посмотреть описание квартиры");
            Console.WriteLine("6. Сохранить данные о квартире в файле");
            Console.WriteLine("7. Вывод отфильтрованного списка");
            Console.WriteLine("0. Выход");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    appartements = appartementRep.LoadAppartementsFromXml();
                    DisplayAllAppartements();
                    break;
                case "2":
                    appartementRep.SaveAppartementToXml(appartements);
                    break;
                case "3":
                    DisplayAllAppartements();
                    break;
                case "4":
                    RegisterNewAppartement();
                    break;
                case "5":
                    ViewAppartmentDescription();
                    break;
                case "6":
                    SaveToFile();
                    break;
                case "7":
                    FilterList();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    static void DisplayAllAppartements()
    {
        if (appartements.Any())
        {
            foreach (var appartement in appartements)
            {
                Console.WriteLine($"Number: {appartement.Number}");
                Console.WriteLine($"Region: {appartement.Region}");
                Console.WriteLine($"Views: {appartement.Views}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Нет информации о квартирах. Загрузите данные сначала.");
        }
    }

    static void RegisterNewAppartement()
    {
        Console.WriteLine("Введите номер квартиры:");
        string number = Console.ReadLine();

        Console.WriteLine("Введите адрес квартиры:");
        string adress = Console.ReadLine();

        Console.WriteLine("Введите регион квартиры:");
        string region = Console.ReadLine();

        Console.WriteLine("Введите описание квартиры:");
        string description = Console.ReadLine();

        decimal views = 0;
        /*while (!decimal.TryParse(Console.ReadLine(), out initialBalance))
        {
            Console.WriteLine("Некорректный ввод. Введите число:");
        }*/

        appartementRep.RegisterNewAppartement(number, adress, region, description, views, appartements);
    }

    static void ViewAppartmentDescription()
    {
        Console.WriteLine("Введите номер квартиры:");
        string number = Console.ReadLine();
        appartementRep.ViewAppartementDescription(number, appartements);
    }

    static void SaveToFile()
    {
        Console.WriteLine("Введите номер квартиры:");
        string number = Console.ReadLine();

        appartementRep.SaveToFile(number, appartements);
        Console.WriteLine("Успешно сохранено");
    }

    static void FilterList()
    {
        while(true)
        {
            Console.WriteLine("");
            Console.WriteLine("Выберите пункт для фильтрации:\n1. По региону\n2. По числу просмотров\n3. Выход\n");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nВведите регион: ");
                    string region = Console.ReadLine();
                    appartementRep.ShowListByRegion(region, appartements);
                    break;
                case "2":
                    Console.WriteLine("\nВведите минимальное число просмотров: ");
                    decimal minViews, maxViews;
                    while (!decimal.TryParse(Console.ReadLine(), out minViews))
                    {
                        Console.WriteLine("Некорректный ввод.\nВведите минимальное число просмотров: ");
                    }
                    Console.WriteLine("\nВведите максимальное число просмотров: ");
                  
                    while (!decimal.TryParse(Console.ReadLine(), out maxViews))
                    {
                        Console.WriteLine("Некорректный ввод.\nВведите максимальное число просмотров: ");
                    }

                    appartementRep.ShowListByView(minViews, maxViews, appartements);
                    break;
                case "3":
                    return;
   
                default:
                    Console.WriteLine("Неверный ввод");
                    break;
            }
        }
    }
}