using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R61_M3_Class_25_Work_03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.textBox2.AppendText(e.KeyChar.ToString());
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.label1.Text = $"({e.X}, {e.Y})";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
