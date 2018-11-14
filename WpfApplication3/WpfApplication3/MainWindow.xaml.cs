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

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        class Costumer
        {
            string name;
            string lastname;
            string patronymic;
            string address;
            int phonenum;
            int cardnum;
            int bankaccnum;
            public Costumer(string n, string l, string p, string add, int ph, int cn, int ban)
            {
                name = n;
                lastname = l;
                patronymic = p;
                address = add;
                phonenum = ph;
                cardnum = cn;
                bankaccnum = ban;
            }
            public override string ToString()
            {
                return $"{lastname} {name} {patronymic}.\nAddress: {address}. Phone num: {phonenum}.\nCard number: {cardnum}. Bank account number {bankaccnum}.";
            }

            public string getlastname()
            {
                return lastname;
            }
            public int getcardnum()
            {
                return cardnum;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        public void addcostumer()
        {
            try
            {
                Costumer costumer;
                costumer = new Costumer(tbfn.Text, tbln.Text, tbp.Text, tbad.Text, int.Parse(tbph.Text), int.Parse(tbcn.Text), int.Parse(tbbn.Text));
                listBox.Items.Add(costumer);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }       

        private void baddc_Click(object sender, RoutedEventArgs e)
        {
            addcostumer();
        }

        private void sort_Click(object sender, RoutedEventArgs e)
        {
            List<Costumer> q = new List<Costumer>();
            foreach (object o in listBox.Items)
                q.Add(o as Costumer);
            q = q.OrderBy(x => x.getlastname()).ToList();
            listBox.Items.Clear();
            foreach (object o in q)
                listBox.Items.Add(o);            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            foreach (object o in listBox.Items)
                listBoxh.Items.Add(o as Costumer);
            listBox.Items.Clear();
            List<Costumer> q = new List<Costumer>();
            foreach (object o in listBoxh.Items)
                q.Add(o as Costumer);
            q = q.FindAll(x => x.getcardnum() >= int.Parse(tbcardnummin.Text));
            q = q.FindAll(x => x.getcardnum() <= int.Parse(tbcardnummax.Text));
            foreach (object o in q)
                listBox.Items.Add(o as Costumer);
        }
        public void undocardrange()
        {
            listBox.Items.Clear();
            foreach (object o in listBoxh.Items)
                listBox.Items.Add(o as Costumer);
            listBoxh.Items.Clear();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            undocardrange();
        }
    }
}
