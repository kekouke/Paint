using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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
            GraphApp = new VectorEditorApp(new WriteableBitmap(650, 430, 96, 96, PixelFormats.Pbgra32, null)); // 640 420
            conturPalette.SelectedColor = Colors.Black;
            GraphApp.SetConturColor(conturPalette.SelectedColor.Value);
            gradientPalette.SelectedColor = Colors.White;
            GraphApp.SetGradientColor(gradientPalette.SelectedColor.Value);
            slider.Value = 1;
            VectorEditorApp.thickness = (int) slider.Value;
            image.Source = VectorEditorApp.paintBox;
        }

        private void paintBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point clickCord = e.GetPosition(image);
            GraphApp.currentTool.MouseDownHandler((int)clickCord.X, (int)clickCord.Y); //GraphApp.StartDraw((int)clickCord.X, (int)clickCord.Y);
            image.Source = VectorEditorApp.paintBox;
        }

        private void paintBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point clickCord = e.GetPosition(image);
            GraphApp.currentTool.MouseMoveHandler((int)clickCord.X, (int)clickCord.Y);
            image.Source = VectorEditorApp.paintBox;
        }

        private void paintBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GraphApp.currentTool.MouseUpHandler();
        }

        private void rectangle_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.SetCurrentTool(GraphApp.cats.Rectabgle);
            GraphApp.isNotPencil = true;
        }

        private void elipse_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.SetCurrentTool(GraphApp.cats.Ellipse);
            GraphApp.isNotPencil = true;
        }

        private void line_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.SetCurrentTool(GraphApp.cats.Line);
            GraphApp.isNotPencil = true;
        }
        private void smth_buttonClick(object sender, RoutedEventArgs e)
        {

        }

        private void pencil_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.SetCurrentTool(GraphApp.cats.Pencil);
            GraphApp.isNotPencil = false;
        }

        private void conturPalette_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            GraphApp.SetConturColor((Color)e.NewValue);
        }

        private void gradientPalette_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            GraphApp.SetGradientColor((Color)e.NewValue);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void paintBox_MouseLeave(object sender, MouseEventArgs e)
        {
            GraphApp.MouseOutOfRange();
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GraphApp.SetThicknessValue((int) e.NewValue);
        }
    }
}