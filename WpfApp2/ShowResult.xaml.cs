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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для ShowResult.xaml
    /// </summary>
    public partial class ShowResult : Page
    {
        string[] Lines;
        
        public ShowResult(string[] lines)
        {
            InitializeComponent();
            Lines = lines;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in Lines)
            {
                label.Content = label.Content+"\n" + item; 
                
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            NavigationService nav;
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new MainMenu());
        }
    }
}
