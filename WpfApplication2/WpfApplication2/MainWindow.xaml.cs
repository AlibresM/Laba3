using System;
using System.Collections.Generic;
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

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public double area(double r, double h)
        {      
             return Math.PI * r * (r+Math.Sqrt(h*h+r*r));            
        }
        public double volume(double r, double h)
        {
            return Math.PI * r * r * h / 3;
        }
        public double mass(double r, double h, double p)
        {
            return volume(r, h)*p;
        }

        private void bpl_Click(object sender, RoutedEventArgs e)
        {
            ans.Content = area(double.Parse(tbr.Text), double.Parse(tbh.Text));
        }

        private void bob_Click(object sender, RoutedEventArgs e)
        {
            ans.Content = volume(double.Parse(tbr.Text), double.Parse(tbh.Text));
        }

        private void bma_Click(object sender, RoutedEventArgs e)
        {
            ans.Content = mass(double.Parse(tbr.Text), double.Parse(tbh.Text), double.Parse(tbp.Text));
        }
    }
}
