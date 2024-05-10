using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Collections;

namespace Server3
{
    public partial class Form1 : Form
    {
        string fileName = "D:\\FCP\\SEM7\\RIS\\Lab3\\Шмат\\Lab3\\subject.txt";
        int fileCount = 0;
        TcpListener listener = null;
        Socket socket = null;
        NetworkStream ns = null;
        Encoding ae = null;

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            listener = new TcpListener(IPAddress.Any, 5555);
            listener.Start(); 
            socket = listener.AcceptSocket();
            if (socket.Connected)
            {
                ns = new NetworkStream(socket);
                ae = Encoding.UTF8;
                ThreadClass threadClass = new ThreadClass();
                var connection = threadClass.Start(ns, fileName, fileCount, this);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    public class ThreadClass
    {
        public NetworkStream ns;
        public String fileName;
        public int fileCount;
        public Form1 form;
        public Encoding ae;
        private string s1;
        public async Task Start(NetworkStream ns, String fileName, int fileCount, Form1 form)
        {
            this.ns = ns;
            ae = Encoding.UTF8;
            this.fileName = fileName;
            this.fileCount = fileCount;
            this.form = form;
            var cmd = GetCmd();
            while (cmd != "exit")
            {
                try
                {
                    var task = ThreadOperations(cmd);
                    task.Wait();
                    System.Diagnostics.Debug.WriteLine($"Task is {task.Status}");
                    cmd = GetCmd();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Exception 1");
                    Debug.WriteLine(e.StackTrace);
                }
            
            }
        }
        private string GetCmd()
        {
            try
            {
                byte[] recived = new byte[256];
                ns.Read(recived, 0, recived.Length); 
                s1 = ae.GetString(recived);
                int i = s1.IndexOf("|", 0);
                String cmd = s1.Substring(0, i);
                return cmd;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return "exit";
            }
        }
        public async Task ThreadOperations(string cmd)
        {
            try
            {
                if (cmd.CompareTo("view") == 0)
                {
                    byte[] sent = new byte[256];
                    FileStream fstr = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fstr);
                    sent = ae.GetBytes(sr.ReadToEnd());
                    sr.Close();
                    fstr.Close();
                    ns.Write(sent, 0, sent.Length);
                }
                if (cmd.CompareTo("add") == 0)
                {
                    int j = s1.IndexOf("*", 0);
                    int i = s1.IndexOf("|", 0);
                    String line = s1.Substring(i+1, j-i-1);
                    byte[] sent = new byte[256];
                    FileStream fstr = new FileStream(fileName, FileMode.Open, FileAccess.Write);
                    fstr.Seek(0, SeekOrigin.End);
                    StreamWriter sr = new StreamWriter(fstr);
                    sr.WriteLine(line);
                    sr.Close();
                    fstr.Close();
                    sent = ae.GetBytes("Subject was added succesfully!");
                    ns.Write(sent, 0, sent.Length);
                }
                if (cmd.CompareTo("delete") == 0)
                {
                    int j = s1.IndexOf("*", 0);
                    int i = s1.IndexOf("|", 0);
                    String line = s1.Substring(i + 1, j - i - 1);
                    int num = System.Int16.Parse(line);
                    byte[] sent = new byte[256];
                    StreamReader sr1 = new StreamReader(fileName, System.Text.Encoding.UTF8);
                    string line2;
                    ArrayList mas1 = new ArrayList();
                    while ((line2 = sr1.ReadLine()) != null)
                    {
                        mas1.Add(line2);
                    }
                    sr1.Close();
                    mas1.RemoveAt(num - 1);
                    TextWriter tw = null;
                    try
                    {
                        tw = File.CreateText(fileName);
                        foreach (object o in mas1)
                            tw.WriteLine(o.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error saving file!");
                    }
                    finally
                    {
                        if (tw != null)
                            tw.Close();
                    }
                    sent = ae.GetBytes("ID "+num+" was deleted!");
                    ns.Write(sent, 0, sent.Length);//отправка информации клиенту
                }
                if (cmd.CompareTo("edit") == 0)
                {
                    StreamReader sr = new StreamReader(fileName, System.Text.Encoding.UTF8);
                    string line3;
                    ArrayList mas3 = new ArrayList();
                    while ((line3 = sr.ReadLine()) != null)
                    {
                        mas3.Add(line3);
                    }
                    sr.Close();
                    int j = s1.IndexOf("*", 0);
                    int i = s1.IndexOf("|", 0);
                    int k = s1.IndexOf("#", 0);
                    String product = s1.Substring(i + 1, j - i - 1);//получает подстроку из экземпляра
                    String line = s1.Substring(j+1, k - j - 1);//получает подстроку из экземпляра
                    int num = System.Int16.Parse(line);
                    mas3[num - 1] = product;
                    TextWriter tw1 = null;
                    try
                    {
                        tw1 = File.CreateText(fileName);
                        foreach (object o in mas3)
                            tw1.WriteLine(o.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error saving file!");
                    }
                    finally
                    {
                        if (tw1 != null)
                            tw1.Close();
                    }
                    byte[] sent = new byte[256];
                    sent = ae.GetBytes("ID " + num + " was edited!");
                    ns.Write(sent, 0, sent.Length);
                }
                if (cmd.CompareTo("find") == 0)
                {
                    StreamReader sr = new StreamReader(fileName, System.Text.Encoding.UTF8);
                    string line3;
                    int num=-1;
                    ArrayList mas3 = new ArrayList();
                    while ((line3 = sr.ReadLine()) != null)
                    {
                        mas3.Add(line3);
                    }
                    sr.Close();
                    int j = s1.IndexOf("*", 0);
                    int i = s1.IndexOf("|", 0);
                    String subject = s1.Substring(i + 1, j - i - 1);
                    for(int k=0; k<mas3.Count; k++)
                    {
                        if(mas3[k].Equals(subject))
                        {
                            num = k;
                        }
                    }
                    TextWriter tw1 = null;
                    byte[] sent = new byte[256];
                    if (num >= 0 && num <= mas3.Count)
                    {
                        sent = ae.GetBytes("ID-" + (num + 1) + "\nSubject and students -" + subject);
                    }
                    else
                    {
                        sent = ae.GetBytes("Nothing found:(");
                    }
                    ns.Write(sent, 0, sent.Length);
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception 2");
                Debug.WriteLine(e.StackTrace);
            }
        }

    }

}
