using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using VectorEditorApplication;
using Microsoft.Win32;

namespace VectorEditor
{
    public partial class MainWindow : Window
    {

        PaintController GraphApp;

        public MainWindow()
        {
            InitializeComponent();
            GraphApp = new PaintController(Canvas);
            scrollViewer.AddHandler(MouseLeftButtonDownEvent, new MouseButtonEventHandler(paintBox_MouseLeftButtonDown), true);

            GraphApp.toolPicker.AddTool(new RectTool());
            GraphApp.toolPicker.AddTool(new EllipseTool());
            GraphApp.toolPicker.AddTool(new LineTool());
            GraphApp.toolPicker.AddTool(new PencilTool());
            GraphApp.toolPicker.AddTool(new ZoomTool());
            GraphApp.toolPicker.AddTool(new HandTool());
           // GraphApp.toolPicker.AddTool(new PieTool());
            GraphApp.toolPicker.AddTool(new Animate());

            GraphApp.toolPicker.DisplayInterface(toolParam, param);
        }

        #region MouseHandlers
        private void paintBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(scrollViewer);
            var clickPoint = e.GetPosition(scrollViewer);
            GraphApp.toolPicker.GetSelectedTool().MouseDownHandler(clickPoint, GraphApp.vp);
            GraphApp.Invalidate();
        }

        private void paintBox_MouseMove(object sender, MouseEventArgs e)
        {
            var clickPoint = e.GetPosition(Canvas);

            GraphApp.toolPicker.GetSelectedTool().MouseMoveHandler(clickPoint, GraphApp.vp);

            GraphApp.Invalidate();
        }

        private void paintBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GraphApp.toolPicker.GetSelectedTool().MouseUpHandler(GraphApp.vp);
            GraphApp.Invalidate();
            Mouse.Capture(null);
            //MessageBox.Show(GraphApp.vp.ToString());
        }

        private void paintBox_MouseLeave(object sender, MouseEventArgs e)
        {
            GraphApp.toolPicker.GetSelectedTool().MouseLeaveHandler();
        }

        private void paintBox_MouseEnter(object sender, MouseEventArgs e)
        {
            var coord = e.GetPosition(Canvas);
            GraphApp.toolPicker.GetSelectedTool().MouseEnterHandler((int)coord.X, (int)coord.Y);
        }
        #endregion

        #region MenuItemHandlers
        private void MenuExit_Click(object sender, RoutedEventArgs e) => Close();

        private void MenuAbout_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Paint Clone\n© Козицкий Михаил(kekouke),\n2020.");

        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PaintCLone files (*.json) | *.json";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (saveFileDialog.ShowDialog() == true)
            {
                GraphApp.SaveImage(saveFileDialog.FileName);
            }
        }

        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PaintCLone files (*.json) | *.json";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == true)
            {
                GraphApp.OpenImage(openFileDialog.FileName);
            }
        }
        #endregion


        // TODO Field
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
        }

        private void scrollViewer_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //GraphApp.vp.Scale += 5;
        }

        private void scrollViewer_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            GraphApp.toolPicker.GetSelectedTool().MouseRightUpHandler(GraphApp.vp, e.GetPosition(Canvas));
        }
    }
}