using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab5_new_
{
    public partial class Uchet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCar_Click(object sender, EventArgs e)
        {
            if (double.TryParse(milesPassed.Value, NumberStyles.Number, CultureInfo.InvariantCulture, out double amount))
            {
                if (amount >= 0)
                {
                    string result = CarBadFeeling(amount);
                    lblResult.Text = result;
                }
                else
                {
                    lblResult.Text = "Введенное значение должно быть положительным...";
                }
            }
            else
            {
                lblResult.Text = "Значение введено неверно!";
            }
        }

        private string CarBadFeeling(double amount)
        {
            string result = string.Empty;
            if (amount < 10000)
            {
                result = "Автомобиль в хорошем состоянии.";
            }
            else if (amount >= 10000 && amount < 50000)
            {
                result = "Автомобиль требует небольшого ремонта.";
            }
            else if (amount >= 50000 && amount < 100000)
            {
                result = "Автомобиль требует серьезного ремонта.";
            }
            else
            {
                result = "Автомобиль не пригоден для использования.";
            }
            return result;
        }

    }
}
