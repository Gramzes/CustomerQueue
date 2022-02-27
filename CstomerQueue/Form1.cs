using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CstomerQueue
{
    public partial class Form1 : Form
    {
        Queue<Customer> customers = new Queue<Customer>();
        int clientNumber = 0;
        bool[] que = { false, false, false };
        int firstQueTimer = 30;
        int secondQueTimer = 60;
        int thirdQueTimer = 150;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "0";
            label2.Text = "0";
            label3.Text = "0";
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clientNumber += 1;
            var clientName = NameGenerator.Generate();
            Customer customer = new Customer(clientName.firstName, clientName.lastName, string.Format("{0:d3}", clientNumber));
            customers.Enqueue(customer);
            listBox1.Items.Add(customer);
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if(que[0])
            {
                firstQueTimer -= 1;
                if (firstQueTimer == 0)
                {
                    que[0] = false;
                    firstQueTimer = 30;
                    textBox1.Text = "";
                }
                label1.Text = firstQueTimer.ToString();
            }
            if (!que[0] && customers.Count!=0)
            {
                Customer customer = customers.Dequeue();
                textBox1.Text = customer.ToString();
                label1.Text = firstQueTimer.ToString();
                que[0] = true;
                listBox1.Items.Remove(customer);
            }

            if (que[1])
            {
                secondQueTimer -= 1;
                if (secondQueTimer == 0)
                {
                    que[1] = false;
                    secondQueTimer = 60;
                    textBox2.Text = "";
                }
                label2.Text = secondQueTimer.ToString();
            }
            if (!que[1] && customers.Count != 0)
            {
                Customer customer = customers.Dequeue();
                textBox2.Text = customer.ToString();
                label2.Text = secondQueTimer.ToString();
                que[1] = true;
                listBox1.Items.Remove(customer);
            }

            if (que[2])
            {
                thirdQueTimer -= 1;
                if (thirdQueTimer == 0)
                {
                    que[2] = false;
                    thirdQueTimer = 150;
                    textBox3.Text = "";
                }
                label3.Text = thirdQueTimer.ToString();
            }
            if (!que[2] && customers.Count != 0)
            {
                Customer customer = customers.Dequeue();
                textBox3.Text = customer.ToString();
                label3.Text = thirdQueTimer.ToString();
                que[2] = true;
                listBox1.Items.Remove(customer);
            }
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = 1000 / trackBar1.Value;
        }
    }
}
