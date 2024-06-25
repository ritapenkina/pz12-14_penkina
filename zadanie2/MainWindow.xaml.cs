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

namespace pz1_penkina
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var cont = new Dictionary<long, string>()
            {
                [89095086824] = "Tom",
                [89095006825] = "Sam",
                [89095086029] = "Bob",
                [89085086827] = "Sasha",
                [89095786822] = "Mike",
            };
            ContactPerebor(cont);
        }
        public void ContactPerebor(Dictionary<long, string> cont)
        {
            foreach (var key in cont)
            {
                listView1.Items.Add($"Имя: {key.Value}  Номер телефона: {key.Key}");
            }
        }

        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}


