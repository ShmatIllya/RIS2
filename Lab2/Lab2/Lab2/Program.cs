using System;

namespace Laba2
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        private const string FileName = "D:\\FCP\\SEM7\\RIS\\Lab2\\Lab1\\subjects.txt";

        static void Main(string[] args)
        {
            List<Subject> subjects = LoadSubjects();

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
                        DisplaySubjects(subjects);
                        break;
                    case "2":
                        AddSubject(subjects);
                        break;
                    case "3":
                        UpdateSubject(subjects);
                        break;
                    case "4":
                        DeleteSubject(subjects);
                        break;
                    case "5":
                        SearchSubject(subjects);
                        break;
                    case "6":
                        SortSubjects(subjects);
                        break;
                    case "7":
                        SaveSubjects(subjects);
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        private static List<Subject> LoadSubjects()
        {
            List<Subject> subjects = new List<Subject>();

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
                                decimal students = decimal.Parse(values[1]);
                                int hours = int.Parse(values[2]);
                                subjects.Add(new Subject { Name = name, Students = students, Hours = hours });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                }
            }

            return subjects;
        }

        private static void SaveSubjects(List<Subject> subjects)
        {
            try
            {
                using (var writer = new StreamWriter(FileName))
                {
                    foreach (var subject in subjects)
                    {
                        writer.WriteLine($"{subject.Name},{subject.Students},{subject.Hours}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении файла: {ex.Message}");
            }
        }



        private static void DisplaySubjects(List<Subject> subjects)
        {
            Console.WriteLine("Список дисциплин:");
            foreach (var subject in subjects)
            {
                Console.WriteLine($"Наименование: {subject.Name}, Количество студентов: {subject.Students}, Количество часов: {subject.Hours}");
            }
        }



        private static void AddSubject(List<Subject> subjects)
        {
            Console.Write("Введите наименование дисциплины: ");
            string name = Console.ReadLine();

            decimal students;
            while (true)
            {
                Console.Write("Введите количество студентов: ");
                if (decimal.TryParse(Console.ReadLine(), out students) && students >= 0)
                    break;
                else
                    Console.WriteLine("Некорректное значение для кол-ва студентов. Пожалуйста, введите положительное число.");
            }

            int hours;
            while (true)
            {
                Console.Write("Введите количество часов: ");
                if (int.TryParse(Console.ReadLine(), out hours) && hours >= 0)
                    break;
                else
                    Console.WriteLine("Некорректное значение для кол-ва часов. Пожалуйста, введите положительное целое число.");
            }

            subjects.Add(new Subject { Name = name, Students = students, Hours = hours });
            Console.WriteLine("Предмет успешно добавлен.");
        }
        private static void UpdateSubject(List<Subject> subjects)
        {
            Console.Write("Введите наименование дисциплины для изменения: ");
            string nameToEdit = Console.ReadLine();

            var subjectToUpdate = subjects.FirstOrDefault(p => p.Name.Equals(nameToEdit, StringComparison.OrdinalIgnoreCase));

            if (subjectToUpdate != null)
            {
                string newName;
                decimal newStudents;
                int newHours;

                Console.Write("Введите новое наименование дисциплины: ");
                newName = Console.ReadLine();

                while (true)
                {
                    Console.Write("Введите новое кол-во студентов: ");
                    if (decimal.TryParse(Console.ReadLine(), out newStudents) && newStudents >= 0)
                        break;
                    else
                        Console.WriteLine("Некорректное значение для кол-ва студентов. Пожалуйста, введите положительное число.");
                }

                while (true)
                {
                    Console.Write("Введите новое количество часов: ");
                    if (int.TryParse(Console.ReadLine(), out newHours) && newHours >= 0)
                        break;
                    else
                        Console.WriteLine("Некорректное значение для кол-ва часов. Пожалуйста, введите положительное целое число.");
                }

                subjectToUpdate.Name = newName;
                subjectToUpdate.Students = newStudents;
                subjectToUpdate.Hours = newHours;

                Console.WriteLine("Дисциплина успешно изменена.");
            }
            else
            {
                Console.WriteLine("Дисциплина не найдена.");
            }
        }
        private static void DeleteSubject(List<Subject> subjects)
        {
            Console.Write("Введите наименование дисциплины для удаления: ");
            string nameToDelete = Console.ReadLine();

            var subjectToDelete = subjects.FirstOrDefault(p => p.Name.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase));

            if (subjectToDelete != null)
            {
                subjects.Remove(subjectToDelete);
                Console.WriteLine("Дисциплина успешно удалена.");
            }
            else
            {
                Console.WriteLine("Дисциплина не найдена.");
            }
        }

        private static void SearchSubject(List<Subject> subjects)
        {
            Console.Write("Введите наименование дисциплины для поиска: ");
            string searchTerm = Console.ReadLine();

            var searchResults = subjects.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));

            if (searchResults.Any())
            {
                Console.WriteLine("Результаты поиска:");
                foreach (var subject in searchResults)
                {
                    Console.WriteLine($"Наименование: {subject.Name}, Кол-во студентов: {subject.Students}, Кол-во часов: {subject.Hours}");
                }
            }
            else
            {
                Console.WriteLine("Данная дисциплина не найдена.");
            }
        }

        private static void SortSubjects(List<Subject> subjects)
        {
            var sortedSubjects = subjects.OrderBy(p => p.Name).ToList();
            DisplaySubjects(sortedSubjects);
        }
    }

    class Subject
    {
        public string Name { get; set; }
        public decimal Students { get; set; }
        public int Hours { get; set; }
    }



}

