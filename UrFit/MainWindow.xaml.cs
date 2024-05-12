using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

namespace UrFit
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Exercises_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new Exercises();
        }

        private void Calculator_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new Calculator();
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = null;
        }
    }
}

