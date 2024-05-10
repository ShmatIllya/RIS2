using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client3
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles(); //включает визуальные стили для приложения
            Application.SetCompatibleTextRenderingDefault(false);//устанавливает значения по умолчанию
            Application.Run(new Form1());
        }
    }
}
