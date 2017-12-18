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
using System.Windows.Threading;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для GameField.xaml
    /// </summary>
    public partial class GameField : Page
    {
        private Rectangle[] BArray = new Rectangle[16];
        private int[] IndArray = new int[17];
        private ImageBrush[] PicsArray = new ImageBrush[8];
        private ImageBrush PicStub;
        private int CurBut=-1, CurBut1 = -1;
        private DispatcherTimer MainTmr;
        private DispatcherTimer CloseTmr;
        private double TLimit;
        private double Result;
        private double tlimit;

        public GameField(Uri SpriteSheet, double tLimit)
        {
            this.TLimit = tLimit;
            Result = tLimit;
           
            int[] BHash = new int[8];
            for (int i=0;i<8;i++)
            {
                PicsArray[i] = new ImageBrush();
                PicsArray[i].ImageSource = new BitmapImage(SpriteSheet);
                PicsArray[i].ViewboxUnits = BrushMappingMode.Absolute;
                PicsArray[i].Viewbox = new Rect(165 * i, 0, 165, 165);
                BHash[i] = 2;
            }
            PicStub = new ImageBrush();
            PicStub.ImageSource = new BitmapImage(SpriteSheet);
            PicStub.ViewboxUnits = BrushMappingMode.Absolute;
            PicStub.Viewbox = new Rect(165 * 8, 0, 165, 165);
            InitializeComponent();
            int Margin = 22,Size=120;          
            for (int i=0;i<16;i++)
            {
                BArray[i] = new Rectangle();
                BArray[i].Height = Size;
                BArray[i].Width = Size;
                GameCanvas.Children.Add(BArray[i]);
                Canvas.SetLeft(BArray[i], Margin + (i%4) * Margin + (i%4) * Size );
                Canvas.SetTop(BArray[i], Margin + Math.Floor((float)i/4) * Margin + Math.Floor((float)i / 4) * Size);

                BArray[i].MouseDown += ClickPic;
            }

            Random rand = new Random();
            int j = 0;
            while(j<16)
            {
                int Ind = rand.Next(8);
                if(BHash[Ind]>0)
                {
                    BHash[Ind]--;
                    IndArray[j] = Ind;
                    
                    BArray[j].Fill = PicStub;
                    j++;
                }
            }
            IndArray[16] = 8;
            Canvas.SetZIndex(FinLbl, 1);
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
            MainTmr = new DispatcherTimer();
            MainTmr.Interval = new TimeSpan(0,0,1);
            MainTmr.Tick += MainTick;
            MainTmr.Start();
        }

        private void MainTick(object sender, EventArgs e)
        {
            
            if (TLimit<0)
            {
                FinLbl.Content = "Ви програли!";
                FinLbl.Visibility = Visibility.Visible;
                FinLbl.Foreground = Brushes.Red;
                
                return;
            }
            if(IndArray[16]==0)
            {
                FinLbl.Content = "Ви перемогли!";
                FinLbl.Visibility = Visibility.Visible;
                FinLbl.Foreground = Brushes.Red;
                button.Visibility = Visibility.Visible;

                tlimit = Result - TLimit;   
               
                return;
                

            }
            double mins = Math.Floor(TLimit / 60);
            double secs = (TLimit % 60);
            string smins,ssecs;
            if(mins<10)
            {
                smins = "0" + mins.ToString();
            }
            else
            {
                smins = mins.ToString();
            }
            if (secs < 10)
            {
                ssecs = "0" + secs.ToString();
            }
            else
            {
                ssecs = secs.ToString();
            }

            TimeLb.Content = smins + ":" + ssecs;
            TLimit--;     
            MainTmr.Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav;
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new LevelSel());
        }

        private void ClickPic(object sender, RoutedEventArgs e)
        {
            DispatcherTimer TmrClose = new DispatcherTimer(); 
            int BNum = -1;
            for(int i=0;i<16;i++)
            {
                if (sender.Equals(BArray[i]))
                {
                    BNum = i;
                    break;
                }
            }
            
            if (CurBut==-1)
            {
                BArray[BNum].Fill = PicsArray[IndArray[BNum]];
                CurBut = BNum;
                CloseTmr = new DispatcherTimer();
                CloseTmr.Interval = new TimeSpan(0,0,5);
                CloseTmr.Tick += CloseTick;
                CloseTmr.Start();
            }else if(CurBut1==-1)
            {
                if (CurBut != BNum)
                {
                    BArray[BNum].Fill = PicsArray[IndArray[BNum]];
                    CurBut1 = BNum;

                    
                    TmrClose.Interval = new TimeSpan(0, 0, 1);
                    TmrClose.Tick += PairClose; ;
                    TmrClose.Start();
                }
            }
            else
            {
                TmrClose.Stop();
                PairClose(null, null);
            }

        }

        private void PairClose(object sender, EventArgs e)
        {
            CloseTmr.Stop();
            if (CurBut != -1 && CurBut1 != -1)
            {
                if (IndArray[CurBut] == IndArray[CurBut1])
                {
                    BArray[CurBut].MouseDown -= CloseTick;
                    BArray[CurBut1].MouseDown -= CloseTick;
                    BArray[CurBut].Opacity = 0;
                    BArray[CurBut1].Opacity = 0;
                    IndArray[16]--;
                }
                BArray[CurBut].Fill = PicStub;
                CurBut = -1;
                BArray[CurBut1].Fill = PicStub;
                CurBut1 = -1;
            }
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService nav;
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Record(tlimit));
            tlimit= 0;
        }

        private void CloseTick(object sender, EventArgs e)
        {
            if (CurBut != -1)
            {
                BArray[CurBut].Fill = PicStub;
                CurBut = -1;
            }
        }

        
    }
}
