using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Bonus
{
    internal class AppartementRep

    {
        public void RegisterNewAppartement(string number, string adress, string region, string description, decimal views,
            List<Appartement> appartements)
        {
            // Проверка наличия квартиры с таким номером (можно добавить валидацию номера)
            if (appartements.Any(c => c.Number == number))
            {
                Console.WriteLine("Квартира с таким номером уже существует.");
                return;
            }

            Appartement newAppartement = new Appartement(number, adress, region, description, views);
            appartements.Add(newAppartement);
            Console.WriteLine("Новая квартира зарегистрирована.");
        }

        public List<Appartement> LoadAppartementsFromXml()
        {
            string filePath = "D:\\FCP\\SEM7\\RIS\\Lab6\\Bonus\\XMLFile1.xml";
            XDocument doc = XDocument.Load(filePath);
            var appartements = doc.Descendants("Appartement")
                           .Select(c => {
                               var appartement = new Appartement(
                                   (string)c.Element("Number"),
                                   (string)c.Element("Adress"),
                                   (string)c.Element("Region"),
                                   (string)c.Element("Description"),
                                   (decimal)c.Element("Views")
                               );
                               return appartement;
                           }).ToList();
            return appartements;
        }

        public void SaveAppartementToXml(List<Appartement> appartements)
        {
            string filePath = "D:\\FCP\\SEM7\\RIS\\Lab6\\Bonus\\XMLFile1.xml";
            XElement xml = new XElement("Appartements",
                            from appartement in appartements
                            select new XElement("Appartement",
                                new XElement("Number", appartement.Number),
                                new XElement("Adress", appartement.Adress),
                                new XElement("Region", appartement.Region),
                                new XElement("Description", appartement.Description),
                                new XElement("Views", appartement.Views)
                            )
                        );

            xml.Save(filePath);
            Console.WriteLine("Информация о квартирах сохранена в XML.");
        }

        public void ViewAppartementDescription(string number, List<Appartement> appartements)
        {
            Appartement appartiment = appartements.FirstOrDefault(c => c.Number == number);
            if (appartiment != null)
            {
                appartiment.IncreaseViews();
                Console.WriteLine("");
                Console.WriteLine($"Number: {appartiment.Number}");
                Console.WriteLine($"Adress: {appartiment.Adress}");
                Console.WriteLine($"Region: {appartiment.Region}");
                Console.WriteLine($"Description: {appartiment.Description}");
                Console.WriteLine($"Views: {appartiment.Views}");
              
            }
            else
            {
                Console.WriteLine("Квартира не найдена.");
            }
        }

        public void SaveToFile(string number, List<Appartement> appartements)
        {
            Appartement appartement = appartements.FirstOrDefault(c => c.Number == number);
            if (appartement != null)
            {
                Console.WriteLine("Укажите путь для сохранения: ");
                string path = Console.ReadLine();
                path = path.Replace("\\", "\\\\");
                path += "\\\\";
                using (StreamWriter writetext = new StreamWriter(path + "results.txt"))
                {
                    writetext.WriteLine($"Number: {appartement.Number}");
                    writetext.WriteLine($"Adress: {appartement.Adress}");
                    writetext.WriteLine($"Region: {appartement.Region}");
                    writetext.WriteLine($"Description: {appartement.Description}");
                    writetext.WriteLine($"Views: {appartement.Views}");
                }
                /*if (card.Region >= pointsToDeduct)
                {
                    card.DecreaseBalance(pointsToDeduct);
                    Console.WriteLine($"С карты {cardNumber} списано {pointsToDeduct} бонусных баллов.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Недостаточно баллов на карте.");
                }*/
            }
            else
            {
                Console.WriteLine("Квартира не найдена.");
            }
        }

        public void ShowListByRegion(string region, List<Appartement> appartements)
        {
            List<Appartement> resultList = appartements.FindAll(c => c.Region == region);
            if (resultList.Any())
            {
                foreach (Appartement app in resultList)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Number: {app.Number}");
                    Console.WriteLine($"Region: {app.Region}");
                    Console.WriteLine($"Views: {app.Views}");
                }
            }
        }

        public void ShowListByView(decimal minValue, decimal maxValue, List<Appartement> appartements)
        {
            List<Appartement> resultList = appartements.FindAll(c => c.Views >= minValue && c.Views <= maxValue);
            if (resultList.Any())
            {
                foreach (Appartement app in resultList)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Number: {app.Number}");
                    Console.WriteLine($"Region: {app.Region}");
                    Console.WriteLine($"Views: {app.Views}");
                }
            }
        }

    }
}
