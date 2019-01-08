
using System.Windows;
using System.Windows.Forms;
using System.Drawing;
using FileManager;
using System.Collections.Generic;
using DrawGraph;
using Exel_Reader;
using System.Threading;
using Model;

namespace Task_7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Excel ex = new Excel();
                List<Candle> input = ex.ReadFile(openFileDialog.FileName);
                Drawer dr = new Drawer(input, Graph_image.DesiredSize.Width, Graph_image.DesiredSize.Height);
                Indicator ind = new Indicator(input, Graph_image.DesiredSize.Width, Graph_image.DesiredSize.Height);
                Graph_image.Source = Converter.ToBitmapImage(dr.DrawOne(150));
                IndicatorImage.Source = Converter.ToBitmapImage(ind.Calculate());
            }
        }
    }
}
