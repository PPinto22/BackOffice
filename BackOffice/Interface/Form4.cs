using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackOffice.Interface
{
    public partial class Form4 : Form
    {
        public DateTime data {get; set;}

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("helo");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.data = monthCalendar1.SelectionRange.Start;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
