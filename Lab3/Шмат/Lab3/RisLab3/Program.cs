using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace RisLab3 {
    class Program {
        public const string FILE_NAME = "tvcompany.txt";
        public const int COLUMN_SIZE = 25;

        static void Main(string[] args) {
            Program app = new Program();
            app.StartProject();
        }

        private List<Tvcompany> tvcompany = null;

        private void StartProject() {
            Console.WriteLine("Приложение учёта продаж телевизоров!");
            ReadData();
            CreateMenu();
            WriteData();
            Console.WriteLine("Работа завершена!");
            Console.ReadKey();
        }

        private void CreateMenu() {
            while (true) {
                ShowMenu();
                int menuItem = Program.EnterIntNumber();
                if (!ExecuteOperation(menuItem)) {
                    break;
                }
            }
        }

        private bool ExecuteOperation(int menuItem) {
            switch (menuItem) {
                case 0:
                    return false;
                case 1:
                    this.Create(); break;
                case 2:
                    this.Read(this.tvcompany); break;
                case 3:
                    this.Update(); break;
                case 4:
                    this.Delete(); break;
                case 5:
                    this.Find(); break;
                case 6:
                    this.Sort(); break;
                default:
                    Console.WriteLine("Некорректный пункт меню (" + menuItem + ")!"); break;
            }
            return true;
        }


        private void ShowMenu() {
            String[] menuRows = { "\n\tМеню для работы с данными:", "1) Добавить", "2) Просмотреть",
                "3) Изменить", "4) Удалить", "5) Искать" , "6) Сортировать", "0) ВЫЙТИ" };
            foreach (String menuRow in menuRows) {
                Console.WriteLine(menuRow);
            }
        }

        private void ReadData() {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Tvcompany>));

            using (FileStream stream = new FileStream(Program.FILE_NAME, FileMode.OpenOrCreate)) {
                try {
                    object tempObject = jsonFormatter.ReadObject(stream);
                    this.tvcompany = (List<Tvcompany>)tempObject;
                } catch(Exception ex) {
                    this.tvcompany = new List<Tvcompany>();
                }
            }
        }

        private void WriteData() {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Tvcompany>));

            using (FileStream stream = new FileStream(Program.FILE_NAME, FileMode.OpenOrCreate)) {
                jsonFormatter.WriteObject(stream, this.tvcompany);
            }
        }

        private void Read(List<Tvcompany> tvcompanyToSwhor) {
            ShowHead();
            foreach (Tvcompany tvcompany in tvcompanyToSwhor) {
                ReadOneRow(tvcompany);
            }
        }

        private void ShowHead() {
            this.showOneRow("ID", "Название", "Страна", "Цена");
        }

        private void ReadOneRow(Tvcompany tvcompany) {
            this.showOneRow(tvcompany.Id.ToString(), tvcompany.Name, tvcompany.Country, tvcompany.Price.ToString());
        }

        private void showOneRow(string first, string second, string thrid, string fourth) {
            first += getSpaces(first);
            second += getSpaces(second);
            thrid += getSpaces(thrid);
            fourth += getSpaces(fourth);
            Console.WriteLine("|| " + first + " || " + second + " || " + thrid + " || " + fourth + " || ");

        }

        private string getSpaces(string value) {
            string spaces = "";
            for (int i = 0; i < COLUMN_SIZE - value.Length; i++) {
                spaces += " ";
            }
            return spaces;
        }

        private void Create() {
            Tvcompany newTvcompany = new Tvcompany();
            Console.Write("Введите ИД: ");
            newTvcompany.Id = this.EnterUniqueId();
            Console.Write("Введите Название: ");
            newTvcompany.Name = Program.EnterString();
            Console.Write("Введите Страну: ");
            newTvcompany.Country = Program.EnterString();
            Console.Write("Введите Цену: ");
            newTvcompany.Price = Program.EnterDoubleNumber();
            this.tvcompany.Add(newTvcompany);
        }

        private int EnterUniqueId() {
            int id;
            while (true) {
                id = Program.EnterIntNumber();
                if (this.isIdUnique(id)) {
                    break;
                } else {
                    Console.Write("Ид не уникален. Введите заново: ");
                }
            }
            return id;
        }

        private bool isIdUnique(int id) {
            foreach (Tvcompany tvcompany in this.tvcompany) {
                if (tvcompany.Id == id) {
                    return false;
                }
            }
            return true;
        }

        private void Delete() {
            findByChange("Введите ИД для удаления: ", "Удалено!", true);
        }

        private void Update() {
            findByChange("Введите ИД для редактирования: ", "Изменено!", false);
        }

        private void findByChange(string headMessage, string okMessage, bool isRemove) {
            this.Read(this.tvcompany);
            Console.Write(headMessage);
            int id = Program.EnterIntNumber();
            foreach (Tvcompany tvcompany in this.tvcompany) {
                if (tvcompany.Id == id) {
                    chooseAction(isRemove, tvcompany, id);
                    Console.WriteLine(okMessage);
                    return;
                }
            }
            Console.WriteLine("Запись не найдена!");
        }

        private void chooseAction(bool isRemove, Tvcompany tvcompany, int id) {
            if (isRemove) {
                this.tvcompany.Remove(tvcompany);
            } else {
                this.UpdateField(id);
            }
        }

        private void UpdateField(int id) {
            int fieldId = this.ChooseField();
            Console.Write("Введите новое значение: ");
            switch (fieldId) {
                case 1:
                    this.GetById(id).Id = this.EnterUniqueId(); break;
                case 2:
                    this.GetById(id).Name = Program.EnterString(); break;
                case 3:
                    this.GetById(id).Country = Program.EnterString(); break;
                case 4:
                    this.GetById(id).Price = Program.EnterDoubleNumber(); break;
                default:
                    Console.WriteLine("Некорректный номер поля!"); break;
            }
        }

        private Tvcompany GetById(int id) {
            foreach (Tvcompany tvcompany in this.tvcompany) {
                if (tvcompany.Id == id) {
                    return tvcompany;
                }
            }
            return null;
        }
        
        private int ChooseField() {
            Console.WriteLine("Выберите поле: ");
            Console.WriteLine("1) ИД");
            Console.WriteLine("2) Название");
            Console.WriteLine("3) Страна");
            Console.WriteLine("4) Цена");
            return Program.EnterIntNumber();
        }
        
        private void Sort() {
            Console.WriteLine("Поиск по элементам!");
            int fieldId = ChooseField();
            switch (fieldId) {
                case 1:
                    this.tvcompany = this.tvcompany.OrderBy(o => o.Id).ToList(); break;
                case 2:
                    this.tvcompany = this.tvcompany.OrderBy(o => o.Name).ToList(); break;
                case 3:
                    this.tvcompany = this.tvcompany.OrderBy(o => o.Country).ToList(); break;
                case 4:
                    this.tvcompany = this.tvcompany.OrderBy(o => o.Price).ToList(); break;
                default:
                    Console.WriteLine("Некорректный номер поля!"); break;
            }
            this.Read(this.tvcompany);
        }

        private void Find() {
            Console.WriteLine("Поиск по элементам!");
            int fieldId = ChooseField();
            Console.Write("Введите данные для поиска: ");
            string value = Program.EnterString();
            switch (fieldId) {
                case 1:
                    this.Read(this.tvcompany.Where(o => value == o.Id.ToString()).ToList()); break;
                case 2:
                    this.Read(this.tvcompany.Where(o => value == o.Name).ToList()); break;
                case 3:
                    this.Read(this.tvcompany.Where(o => value == o.Country).ToList()); break;
                case 4:
                    this.Read(this.tvcompany.Where(o => value == o.Price.ToString()).ToList()); break;
                default:
                    Console.WriteLine("Некорректный номер поля!"); break;
            }
        }

        private static int EnterIntNumber() {
            string value = Console.ReadLine();
            int result;
            if (!Int32.TryParse(value, out result)) {
                Console.Write("Это не целое число, введите заново: ");
                return Program.EnterIntNumber();
            } else {
                return result;
            }
        }

        private static string EnterString() {
            return Console.ReadLine();
        }

        private static double EnterDoubleNumber() {
            string value = Console.ReadLine();
            double result;
            if (!Double.TryParse(value, out result)) {
                Console.Write("Это не число, введите заново: ");
                return Program.EnterIntNumber();
            } else {
                return result;
            }
        }

    }
}
