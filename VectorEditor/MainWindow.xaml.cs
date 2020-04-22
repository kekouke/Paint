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
            GraphApp = new VectorEditorApp(new WriteableBitmap(652, 432, 96, 96, PixelFormats.Pbgra32, null)); // 640 420
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
            Mouse.Capture(image);
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
            Mouse.Capture(null);
        }

        private void paintBox_MouseLeave(object sender, MouseEventArgs e)
        {
            GraphApp.currentTool.MouseLeaveHandler();
        }

        private void paintBox_MouseEnter(object sender, MouseEventArgs e)
        {
            Point coord = e.GetPosition(image);
            GraphApp.currentTool.MouseEnterHandler((int)coord.X, (int)coord.Y);
        }

        private void rectangle_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.SetCurrentTool(GraphApp.toolPicker.Rectabgle);
        }

        private void elipse_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.SetCurrentTool(GraphApp.toolPicker.Ellipse);
        }

        private void line_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.SetCurrentTool(GraphApp.toolPicker.Line);
        }

        private void cancel_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.GoBack();
        }

        private void next_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.GoNext();
        }

        private void pencil_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.SetCurrentTool(GraphApp.toolPicker.Pencil);
        }

        private void zoom_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.SetCurrentTool(GraphApp.toolPicker.Zoom);
        }

        private void hand_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.SetCurrentTool(GraphApp.toolPicker.Hand);
        }

        private void conturPalette_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            GraphApp.SetConturColor((Color)e.NewValue);
        }

        private void gradientPalette_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            GraphApp.SetGradientColor((Color)e.NewValue);
        }

        // TODO Dield
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GraphApp.SetThicknessValue((int)slider.Value);
            sliderValue.Text = ((int)slider.Value).ToString();
        }
    }
}