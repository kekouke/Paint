using System;
using System.Collections.Generic;
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
using VectorEditorApplication;

namespace VectorEditor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VectorEditorApp GraphApp;
        public MainWindow()
        {
            InitializeComponent();
            GraphApp = new VectorEditorApp(new WriteableBitmap(630, 400, 96, 96, PixelFormats.Pbgra32, null));
            conturPalette.SelectedColor = Colors.Black;
            GraphApp.SetConturColor(conturPalette.SelectedColor.Value);
            gradientPalette.SelectedColor = Colors.Black;
            GraphApp.SetGradientColor(gradientPalette.SelectedColor.Value);
            image.Source = GraphApp.paintBox;
        }

        private void paintBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point clickCord = e.GetPosition(image);
            GraphApp.StartDraw((int)clickCord.X, (int)clickCord.Y); //TODO
            image.Source = GraphApp.paintBox;
            //MessageBox.Show(GraphApp.figures.Count.ToString());
        }

        private void paintBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point clickCord = e.GetPosition(image);
            GraphApp.ResizeFigure((int) clickCord.X, (int) clickCord.Y);
            image.Source = GraphApp.paintBox;
        }

        private void paintBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)//TODO: Add image.Source = GraphApp.paintBox; ???
        {
            GraphApp.FinishDraw();
            //image.Source = GraphApp.paintBox;
        }

        private void rectangle_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.SetCurrentTool(PaintTools.Rectabgle);
        }

        private void elipse_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.SetCurrentTool(PaintTools.Ellipse);
        }

        private void line_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.SetCurrentTool(PaintTools.Line);
        }
        private void smth_buttonClick(object sender, RoutedEventArgs e)
        {
            //GraphApp.CreateFigure();
        }

/*        private void pencil_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.SetCurrentTool(PaintTools.Pencil);
        }*/

        private void conturPalette_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            GraphApp.SetConturColor((Color) e.NewValue);
        }

        private void gradientPalette_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            GraphApp.SetGradientColor((Color) e.NewValue);
        }
    }
}
