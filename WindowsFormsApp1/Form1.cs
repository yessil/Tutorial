using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Worker _worker;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _worker = new Worker();
            _worker.ProcessChanged += _worker_ProcessChanged;
            _worker.WorkCompleted += _worker_WorkCompleted;
            button1.Enabled = false;
            _worker.Work();
        }

        private void _worker_WorkCompleted(bool cancelled)
        {
            string message = cancelled ? "Cancelled" : "Completed";
            MessageBox.Show(message);
            button1.Enabled = true;
        }

        private void _worker_ProcessChanged(int progress)
        {
            progressBar1.Value = progress;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _worker.Cancel();
        }

    }
}
