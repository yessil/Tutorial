using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Worker=WindowsFormsApp1.Worker;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WindowsFormsApp1.Worker _worker;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            _worker = new Worker();
            _worker.ProcessChanged += _worker_ProcessChanged;
            _worker.WorkCompleted += _worker_WorkCompleted;
            btnStart.IsEnabled = false;
            _worker.Work();

        }
        private void _worker_WorkCompleted(bool cancelled)
        {
            string message = cancelled ? "Cancelled" : "Completed";
            MessageBox.Show(message);
            btnStart.IsEnabled = true;
        }

        private void _worker_ProcessChanged(int progress)
        {
            indicator.Value = progress;
        }


        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            _worker.Cancel();
        }
    }
}
