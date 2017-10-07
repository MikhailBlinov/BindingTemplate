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
using System.Windows.Shapes;
using PersonLibrary;

namespace WpfTest
{
    /// <summary>
    /// Interaction logic for WindowNew.xaml
    /// </summary>
    public partial class ChangePersonWindow : Window
    {
        public bool ThisDialogResult { get; set; }

        public Person Person { get; set; }

        public ChangePersonWindow()
        {
            InitializeComponent();
        }
        public ChangePersonWindow(Person person)
        {
           this.Person = new Person(person);
           ThisDialogResult = false;
           InitializeComponent();
           this.DataContext = Person;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.ThisDialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
