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
using System.Drawing;

namespace VectorEditor
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
       /* Code by Mary(github.com/dma117) But she speaks that It's from the Internet. But We also know that she lies.
        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            MyText.Text = "You chose: " + rb.GroupName + ": " + rb.Name;
        }
        */
        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void pictureBox_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void rectangle_buttonClick(object sender, RoutedEventArgs e)
        {

        }

        private void elipse_buttonClick(object sender, RoutedEventArgs e)
        {

        }

        private void line_buttonClick(object sender, RoutedEventArgs e)
        {

        }

        private void smth_buttonClick(object sender, RoutedEventArgs e)
        {

        }

        private void pencil_buttonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
