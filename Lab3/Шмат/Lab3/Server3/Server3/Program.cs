using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server3
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);// устанавливает режим высокого разрешения для процесса
            Application.EnableVisualStyles();//включает визуальные стили для приложения
            Application.SetCompatibleTextRenderingDefault(false);//устанавливает значения по умолчанию
            //false - новые эл. исп. класс TextRenderer на основе GDI
            Application.Run(new Form1());
        }
    }
}
