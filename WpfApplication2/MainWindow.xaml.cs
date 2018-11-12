using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundWorker worker = new BackgroundWorker();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BusyIndicator_Click(object sender, RoutedEventArgs e)
        {
            worker.DoWork += (o, ea) =>
                {
                    Dispatcher.Invoke((Action)(() =>
                    {
                        for (int i = 0; i <= 10000; i++)
                        {
                            Debug.WriteLine(i);
                        }
                    }), DispatcherPriority.Background);
                };
            worker.RunWorkerCompleted += (o, ea) =>
            {
                //BusyIndicator.IsBusy = false;
            };
            BusyIndicator.IsBusy = true;
            worker.RunWorkerAsync();
        }

        private void myGif_MediaEnded(object sender, RoutedEventArgs e)
        {
            var myGif = sender as MediaElement;
            myGif.Position = new TimeSpan(0, 0, 1);
            myGif.Play();
        }

        private void BusyIndicator_Loaded(object sender, RoutedEventArgs e)
        {
            DataTemplate template = BusyIndicator.BusyContentTemplate;
            var borderelemnt = new FrameworkElementFactory(typeof(Border));
            var gridelemnt = new FrameworkElementFactory(typeof(Grid));
            borderelemnt.SetValue(Border.BackgroundProperty,new SolidColorBrush(Colors.Transparent));
            gridelemnt.SetValue(Grid.BackgroundProperty,new SolidColorBrush(Colors.Transparent));
            template.LoadContent();
            //template.a = borderelemnt;
            //DependencyObject parent = VisualTreeHelper.GetChild(BusyIndicator, 0);
            //int childIndex = 2;
            //while (parent != null)
            //{
            //    parent = VisualTreeHelper.GetChild(parent, childIndex);
            //    if (parent is ContentPresenter)
            //    {
            //        childIndex = 0;
            //    }
            //    if(parent is Border)
            //    {
            //        (parent as Border).Background = new SolidColorBrush(Colors.Transparent);
            //        (parent as Border).BorderThickness = new Thickness(0);
            //        break;
            //    }
            //}
        }
    }
}
