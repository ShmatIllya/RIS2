using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace Lab4
{
    public partial class Form1 : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database1.accdb";
        private OleDbConnection myConnection;
        public Form1()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.students". При необходимости она может быть перемещена или удалена.
            this.studentsTableAdapter.Fill(this.database1DataSet.students);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            string query = "DELETE FROM students WHERE book_id = " + id;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные о книге удалены");
            this.studentsTableAdapter.Fill(this.database1DataSet.students);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox2.Text);
            string query = "UPDATE students SET book_name = '" + textBox3.Text + "' WHERE book_id = " + id;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные о книге обновлены");
            this.studentsTableAdapter.Fill(this.database1DataSet.students);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(database1DataSet, studentsTableAdapter);
            f2.Owner = this;
            f2.Show();
           
        }
    }
}
