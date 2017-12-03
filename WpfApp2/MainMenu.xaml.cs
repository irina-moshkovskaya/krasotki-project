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
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            
            InitializeComponent();
            this.Loaded += OnLoad;
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            NavigationService nav;
            nav = NavigationService.GetNavigationService(this);
            if (nav.CanGoBack)
            {
                nav.RemoveBackEntry();
            }
           
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string[] lines;
            lines = File.ReadAllLines("Results.txt");

            if (lines.Length == 0)
                MessageBox.Show("Нікому ще не вдавалося перемогти.\nВи можете бути першими!", "Повідомлення");
            else
            {
                NavigationService nav;
                nav = NavigationService.GetNavigationService(this);
            }

        }

        private void button_NewGame_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService nav;
            nav = NavigationService.GetNavigationService(this);
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Application app = Application.Current;
            app.Shutdown();
        }
    }
}
