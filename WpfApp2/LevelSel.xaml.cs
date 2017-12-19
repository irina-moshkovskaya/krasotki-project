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
    /// Логика взаимодействия для LevelSel.xaml
    /// </summary>
    public partial class LevelSel : Page
    {
        private int Diff=1*60;
        private Uri levSS = new Uri("../../technicSS.png", UriKind.RelativeOrAbsolute);
        public LevelSel()
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

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Diff =  60 + 30;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            Diff = 1 * 60;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            Diff = 30;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav;
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new MainMenu());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService nav;
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new GameField(levSS,Diff));
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            levSS = new Uri("animalsSS.png", UriKind.RelativeOrAbsolute);
        }

        private void ListBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
           
            levSS = new Uri("../../technicSS.png", UriKind.RelativeOrAbsolute);
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
