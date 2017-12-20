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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Record.xaml
    /// </summary>
    public partial class Record : Page
    {
        string line;

        public Record(double timer)
        {
            InitializeComponent();
         
           
            line = timer.ToString();
            
        }
       

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string str = textBox.Text;
            if (str == null || str == "" || str.IndexOf(' ') != -1)
                MessageBox.Show("Рядок не може містити пробіл або бути порожнім", "Помилка");
            else if (str.Length > 10)
                MessageBox.Show("Рядок не може містити більше 10 символів", "Помилка");
            else
            {
                line = str + " " + line;
                using (StreamWriter file = new StreamWriter(@"Results.txt", true, Encoding.UTF8))
                {
                    file.WriteLine(line);
                }
                MessageBox.Show("Результат записано успішно", "Повідомлення");

                NavigationService nav;
                nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new MainMenu());
            }
        }
    }
}
