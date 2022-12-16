using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp_8_form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            var str = textBox1.Text;
            var pattern = "(?<hour>0[0-9]|1[0-9]|2[0-3]):(?<min>[0-5][0-9]):(?<sec>[0-5][0-9])";
            str = Regex.Replace(str, pattern, (m) =>
            {
                var ts = TimeSpan.Parse(m.Value);
                if (ts.Seconds >= 30)
                    ts = ts.Add(new TimeSpan(0, 1, 0));

                return ts.ToString(@"hh\:mm");
            });

            textBox2.Text += str;
        }
    }
}
