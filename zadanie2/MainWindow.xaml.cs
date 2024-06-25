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


namespace pz2_penkina
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeContacts();
        }


        private List<Contact> contacts;

        private void InitializeContacts()
        {
            contacts = new List<Contact>
            {
                new Contact {Name = "Tom", Phone = "89045678767"},
                new Contact {Name = "Sam", Phone = "6789054323232"},
                new Contact {Name = "Jack", Phone = "78646423234"},
                new Contact {Name = "Bill", Phone = "111222333444"},
                new Contact {Name = "Sasha", Phone = "439883490583"},
            };
            Contacts.ItemsSource = contacts;
        }

        public class Contact
        {
            public string Name { get; set; }
            public string Phone { get; set; }
        }

        private void Save(string fileName)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, fileName);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var contact in contacts)
                {
                    writer.WriteLine($"{contact.Name}: {contact.Phone}");
                }
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "файл.txt";
            Save(filePath);
            MessageBox.Show("Контакты успешно сохранены на рабочем столе в файл.txt!");
        }
        private void Add(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2)
                {
                    string name = parts[0].Trim();
                    string phone = parts[1].Trim();
                    contacts.Add(new Contact { Name = name, Phone = phone });
                }
            }
            Contacts.ItemsSource = null;
            Contacts.ItemsSource = contacts;
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                Add(openFileDialog.FileName);
            }
        }

        private void Contacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}

