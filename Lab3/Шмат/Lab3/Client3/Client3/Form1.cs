using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client3
{
    public partial class Form1 : Form
    {
        static TcpClient tcp_client = new TcpClient("localhost", 5555);
        Encoding ae = Encoding.UTF8;
        NetworkStream ns = tcp_client.GetStream();

        public Form1()
        {
            InitializeComponent();
        }

        public void CollapseForm(Form1 form1)
        {
            CollapseForm(form1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            quant.Text = Regex.Replace(quant.Text, "[^0-9]", "");
            quant.SelectionStart = quant.Text.Length;
            quant.SelectionLength = 0;
        }
        private bool CheckForErrors()
        {
            var textboxList = new List<string>()
            {
                "Name",
                "Students",
                "Hours",
                "ID"
            };
            var errorsCount = 0;
            var boolDictionary = new Dictionary<string, bool>();
            foreach (var name in textboxList)
            {
                boolDictionary.Add(name, false);
            }
            if (amount.Text.Length == 0)
            {
                boolDictionary["Hours"] = true;
                errorsCount++;
            }
            if (quant.Text.Length == 0)
            {
                boolDictionary["Students"] = true;
                errorsCount++;
            }
            if (name.Text.Length == 0)
            {
                boolDictionary["Name"] = true;
                errorsCount++;
            }
            if (number.Text.Length == 0)
            {
                boolDictionary["ID"] = true;
                errorsCount++;
            }
            if (errorsCount != 0)
            {
                var errorString = "";
                foreach (var error in boolDictionary)
                {
                    if (error.Value)
                        errorString += $" {error.Key}";
                }
                MessageBox.Show($"Are empty {errorString}");
                return true;
            }
            return false;
        }
        private void start_Click(object sender, EventArgs e)
        {
          
            if (radio_view.Checked == true)
            {

                String command = "view";
                String res = command + "|";
                byte[] sent = ae.GetBytes(res);
                byte[] recived = new byte[256];
                ns.Write(sent, 0, sent.Length);
                ns.Read(recived, 0, recived.Length);
                richTextBox1.Text = ae.GetString(recived);
                String status = "=>Command sent:view data";
                listBox1.Items.Add(status);

            }
            if (radio_add.Checked == true)
            {
                if (CheckForErrors()) { 
                }
                string subject_name = name.Text;
                string subject_students = quant.Text;
                string subject_hours = amount.Text;
                String command = "add";
                String res = command + "|" + subject_name + " " + subject_students + " "+ subject_hours + "*";
                byte[] sent = ae.GetBytes(res);
                byte[] recived = new byte[256];
                ns.Write(sent, 0, sent.Length);
                ns.Read(recived, 0, recived.Length);
                richTextBox1.Text = ae.GetString(recived);
                String status = "=>Command sent:add data";
                listBox1.Items.Add(status);
            }
            if (radio_del.Checked == true)
            {
                string line_number = number.Text;
                String command = "delete";
                String res = command + "|" + line_number + "*";
                byte[] sent = ae.GetBytes(res);
                byte[] recived = new byte[256];
                ns.Write(sent, 0, sent.Length);
                ns.Read(recived, 0, recived.Length);
                richTextBox1.Text = ae.GetString(recived);
                String status = "=>Command sent:delete line";
                listBox1.Items.Add(status);
            }
            if (radio_edit.Checked == true)
            {
                string subject_name = name.Text;
                string subject_students = quant.Text;
                string subject_hours = amount.Text;
                string line_number = number.Text;
                String command = "edit";
                String res = command + "|" + subject_name + " " + subject_students+ " " + subject_hours + "*" + line_number + "#";
                byte[] sent = ae.GetBytes(res);
                byte[] recived = new byte[256];
                ns.Write(sent, 0, sent.Length);
                ns.Read(recived, 0, recived.Length);
                richTextBox1.Text = ae.GetString(recived);
                String status = "=>Command sent:edit line";
                listBox1.Items.Add(status);
            }
            if (radio_find.Checked == true)
            {
                string subject_name = name.Text;
                string subject_students = quant.Text;
                string subject_hours = amount.Text;
                string line_number = number.Text;
                String command = "find";
                String res = command + "|" + subject_name + " " + subject_students + " " + subject_hours + "*";
                byte[] sent = ae.GetBytes(res);
                byte[] recived = new byte[256];
                ns.Write(sent, 0, sent.Length);
                ns.Read(recived, 0, recived.Length);
                richTextBox1.Text = ae.GetString(recived);
                String status = "=>Command sent:find line";
                listBox1.Items.Add(status);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            String command = "exit";
            String res = command + "|";
            byte[] sent = ae.GetBytes(res);
            byte[] recived = new byte[256];
            ns.Write(sent, 0, sent.Length);
            String status = "=>You disconnected from server. Please, close the form.";
            listBox1.Items.Add(status);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Name_OnTextChange(object sender, EventArgs e)
        {
            name.Text = Regex.Replace(name.Text, "[0-9]", "");
            name.SelectionStart = name.Text.Length;
            name.SelectionLength = 0;
        }

        private void number_TextChanged(object sender, EventArgs e)
        {
            number.Text = Regex.Replace(number.Text, "[^0-9]", "");
            number.SelectionStart = number.Text.Length;
            number.SelectionLength = 0;
        }

        private void amount_TextChanged(object sender, EventArgs e)
        {
            amount.Text = Regex.Replace(amount.Text, "[^0-9]", "");
            amount.SelectionStart = amount.Text.Length;
            amount.SelectionLength = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
