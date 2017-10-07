using System.Windows;


namespace PersonLibrary
{
    public class Person : DependencyObject
    {
        public string LastName
        {
            get { return (string)GetValue(LastNameProperty); }
            set { SetValue(LastNameProperty, value); }
        }

        public static DependencyProperty LastNameProperty =
             DependencyProperty.Register("LastName", typeof(string), typeof(Person),
             new PropertyMetadata("LastName Hello"));

        public string FirstName
        {
            get { return (string)GetValue(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }

        public static DependencyProperty FirstNameProperty =
             DependencyProperty.Register("FirstName", typeof(string), typeof(Person),
             new PropertyMetadata("LastName Hello"));

        public int Age
        {
            get { return (int)GetValue(AgeProperty); }
            set { SetValue(AgeProperty, value); }
        }

        public static DependencyProperty AgeProperty =
             DependencyProperty.Register("Age", typeof(int), typeof(Person),
             new PropertyMetadata(123));


        public Person(Person person)
        {
            this.Age = person.Age;
            this.FirstName = person.FirstName;
            this.LastName = person.LastName;
        }

        public Person()
        {
            
        }

    }

}
