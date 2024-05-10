using System;

namespace Laba3
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        private const string FileName = "D:/University/RIS/Laba2/Laba3/products.txt";

        static void Main(string[] args)
        {
            List<Product> products = LoadProducts();

            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Просмотреть все записи");
                Console.WriteLine("2. Добавить запись");
                Console.WriteLine("3. Изменить запись");
                Console.WriteLine("4. Удалить запись");
                Console.WriteLine("5. Поиск записи");
                Console.WriteLine("6. Сортировка записей");
                Console.WriteLine("7. Выйти из программы");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayProducts(products);
                        break;
                    case "2":
                        AddProduct(products);
                        break;
                    case "3":
                        UpdateProduct(products);
                        break;
                    case "4":
                        DeleteProduct(products);
                        break;
                    case "5":
                        SearchProduct(products);
                        break;
                    case "6":
                        SortProducts(products);
                        break;
                    case "7":
                        SaveProducts(products);
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        private static List<Product> LoadProducts()
        {
            List<Product> products = new List<Product>();

            if (File.Exists(FileName))
            {
                try
                {
                    using (var reader = new StreamReader(FileName))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var values = line.Split(',');

                            if (values.Length == 3)
                            {
                                string name = values[0];
                                decimal price = decimal.Parse(values[1]);
                                int quantity = int.Parse(values[2]);
                                products.Add(new Product { Name = name, Price = price, Quantity = quantity });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                }
            }

            return products;
        }

        private static void SaveProducts(List<Product> products)
        {
            try
            {
                using (var writer = new StreamWriter(FileName))
                {
                    foreach (var product in products)
                    {
                        writer.WriteLine($"{product.Name},{product.Price},{product.Quantity}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении файла: {ex.Message}");
            }
        }


    
        private static void DisplayProducts(List<Product> products)
        {
            Console.WriteLine("Список продуктов:");
            foreach (var product in products)
            {
                Console.WriteLine($"Наименование: {product.Name}, Цена: {product.Price}, Количество: {product.Quantity}");
            }
        }



        private static void AddProduct(List<Product> products)
        {
            Console.Write("Введите наименование продукта: ");
            string name = Console.ReadLine();

            decimal price;
            while (true)
            {
                Console.Write("Введите цену продукта: ");
                if (decimal.TryParse(Console.ReadLine(), out price) && price >= 0)
                    break;
                else
                    Console.WriteLine("Некорректное значение для цены. Пожалуйста, введите положительное число.");
            }

            int quantity;
            while (true)
            {
                Console.Write("Введите количество продукта: ");
                if (int.TryParse(Console.ReadLine(), out quantity) && quantity >= 0)
                    break;
                else
                    Console.WriteLine("Некорректное значение для количества. Пожалуйста, введите положительное целое число.");
            }

            products.Add(new Product { Name = name, Price = price, Quantity = quantity });
            Console.WriteLine("Продукт успешно добавлен.");
        }
        private static void UpdateProduct(List<Product> products)
        {
            Console.Write("Введите наименование продукта для изменения: ");
            string nameToEdit = Console.ReadLine();

            var productToUpdate = products.FirstOrDefault(p => p.Name.Equals(nameToEdit, StringComparison.OrdinalIgnoreCase));

            if (productToUpdate != null)
            {
                string newName;
                decimal newPrice;
                int newQuantity;

                Console.Write("Введите новое наименование продукта: ");
                newName = Console.ReadLine();

                while (true)
                {
                    Console.Write("Введите новую цену продукта: ");
                    if (decimal.TryParse(Console.ReadLine(), out newPrice) && newPrice >= 0)
                        break;
                    else
                        Console.WriteLine("Некорректное значение для цены. Пожалуйста, введите положительное число.");
                }

                while (true)
                {
                    Console.Write("Введите новое количество продукта: ");
                    if (int.TryParse(Console.ReadLine(), out newQuantity) && newQuantity >= 0)
                        break;
                    else
                        Console.WriteLine("Некорректное значение для количества. Пожалуйста, введите положительное целое число.");
                }

                productToUpdate.Name = newName;
                productToUpdate.Price = newPrice;
                productToUpdate.Quantity = newQuantity;

                Console.WriteLine("Продукт успешно изменен.");
            }
            else
            {
                Console.WriteLine("Продукт не найден.");
            }
        }
        private static void DeleteProduct(List<Product> products)
        {
            Console.Write("Введите наименование продукта для удаления: ");
            string nameToDelete = Console.ReadLine();

            var productToDelete = products.FirstOrDefault(p => p.Name.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase));

            if (productToDelete != null)
            {
                products.Remove(productToDelete);
                Console.WriteLine("Продукт успешно удален.");
            }
            else
            {
                Console.WriteLine("Продукт не найден.");
            }
        }

        private static void SearchProduct(List<Product> products)
        {
            Console.Write("Введите наименование продукта для поиска: ");
            string searchTerm = Console.ReadLine();

            var searchResults = products.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));

            if (searchResults.Any())
            {
                Console.WriteLine("Результаты поиска:");
                foreach (var product in searchResults)
                {
                    Console.WriteLine($"Наименование: {product.Name}, Цена: {product.Price}, Количество: {product.Quantity}");
                }
            }
            else
            {
                Console.WriteLine("Продукты не найдены.");
            }
        }

        private static void SortProducts(List<Product> products)
        {
            var sortedProducts = products.OrderBy(p => p.Name).ToList();
            DisplayProducts(sortedProducts);
        }
    }

    class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }



}
