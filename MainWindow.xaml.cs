using System;
using System.Collections.Generic;
using System.Globalization;
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
using PersonLibrary;

namespace WpfTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Person PersonNew { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            PersonNew = new Person() { Age = 33, FirstName = "FName", LastName = "LName" };
            Grd.DataContext = PersonNew;



            listBox.ItemsSource = new List<Person>()
                                  {
                                      new Person() {Age = 111, LastName = "1111LastName", FirstName = "11111"},
                                      new Person() {Age = 222, LastName = "2222LastName", FirstName = "22222"},
                                      new Person() {Age = 333, LastName = "3333LastName", FirstName = "33333"}
                                  };

            listBoxNew.ItemsSource = new List<Person>()
                                  {
                                      new Person() {Age = 111, LastName = "1111LastName", FirstName = "11111"},
                                      new Person() {Age = 222, LastName = "2222LastName", FirstName = "22222"},
                                      new Person() {Age = 333, LastName = "3333LastName", FirstName = "33333"}
                                  };
             listBoxNew.DisplayMemberPath = "LastName";
        }

        private void listBoxNew_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBox tmpList = (ListBox) e.Source;

            Person person = (Person)tmpList.Items.GetItemAt(tmpList.SelectedIndex);


            if (person != null)
            {
                ChangePersonWindow newWindow = new ChangePersonWindow(person);

                newWindow.ShowDialog();

                if (newWindow.ThisDialogResult == true)
                {
                    person.Age = newWindow.Person.Age;
                    person.LastName = newWindow.Person.LastName;
                    person.FirstName = newWindow.Person.FirstName;

                    MessageBox.Show(person.LastName + "  " + person.FirstName + " " + person.Age.ToString());
                }
            }
        }

      }

    [ValueConversion(typeof(int),typeof(string))]
    public class MyValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Преобразует Int to string (от источника приемнику на экране)
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Преобразует string to int (с экрана приемник передает источнику. если данные менялись)
            return int.Parse(value.ToString());
        }
    }
}
