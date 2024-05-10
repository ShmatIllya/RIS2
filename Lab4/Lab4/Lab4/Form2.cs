using Lab4.Database1DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form2 : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database1.accdb";
        private OleDbConnection myConnection;
       
        public Form2(Database1DataSet dataSet, Database1DataSetTableAdapters.studentsTableAdapter studAdapt)
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            studAdapt.Fill(dataSet.students);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int book_id = Convert.ToInt32(bookIdBox.Text);
            string book_name = bookNameBox.Text;
            string author = authorBox.Text;
            bool is_taken = takenCheckBox.Checked;
            string fio_taken = fioBox.Text;
            int days_amount = Convert.ToInt32(daysBox.Text);
            string query = "INSERT INTO students (book_id, book_name, book_author, is_taken, fio_of_person, return_period) " +
                "VALUES(" + book_id + ", '" + book_name + "', '" + author + "', " + is_taken + ", '" + fio_taken + "', " + days_amount
                + ")";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные о книге добавлены");
            this.Close();
        }
    }
}
