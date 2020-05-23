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

        VectorEditorApp GraphApp;

        public MainWindow()
        {
            InitializeComponent();
            GraphApp = new VectorEditorApp(Canvas);
            scrollViewer.AddHandler(MouseLeftButtonDownEvent, new MouseButtonEventHandler(paintBox_MouseLeftButtonDown), true);

            GraphApp.toolPicker.AddTool(new RectTool());
            GraphApp.toolPicker.AddTool(new EllipseTool());
            GraphApp.toolPicker.AddTool(new LineTool());
            GraphApp.toolPicker.AddTool(new PencilTool());
            GraphApp.toolPicker.AddTool(new ZoomTool());
            GraphApp.toolPicker.AddTool(new HandTool());
            GraphApp.toolPicker.AddTool(new PieTool());

            GraphApp.toolPicker.DisplayInterface(toolParam, param);
        }

        #region MouseHandlers
        private void paintBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(scrollViewer);
            var clickCord = e.GetPosition(scrollViewer);
            GraphApp.toolPicker.GetSelectedTool().MouseDownHandler((int)clickCord.X, (int)clickCord.Y);
            GraphApp.Invalidate();
        }

        private void paintBox_MouseMove(object sender, MouseEventArgs e)
        {
            var clickCord = e.GetPosition(Canvas);
            GraphApp.toolPicker.GetSelectedTool().MouseMoveHandler((int)clickCord.X, (int)clickCord.Y);

            scrollViewer.ScrollToVerticalOffset(VectorEditorApp.screenOffsetY);
            scrollViewer.ScrollToHorizontalOffset(VectorEditorApp.screenOffsetX);

            GraphApp.Invalidate();
        }

        private void paintBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GraphApp.toolPicker.GetSelectedTool().MouseUpHandler();

            if (GraphApp.toolPicker.GetSelectedTool() is ZoomTool && !GraphApp.isZoomed)
            {

                Canvas.LayoutTransform = new ScaleTransform(VectorEditorApp.scaleX, VectorEditorApp.scaleY);

                if (ZoomTool.justClick)
                {
                    scrollViewer.ScrollToVerticalOffset(e.GetPosition(Canvas).Y);
                    scrollViewer.ScrollToHorizontalOffset(e.GetPosition(Canvas).X);
                }
                else
                {
                    scrollViewer.ScrollToVerticalOffset(VectorEditorApp.distanceToPointY * VectorEditorApp.scaleY);
                    scrollViewer.ScrollToHorizontalOffset(VectorEditorApp.distanceToPointX * VectorEditorApp.scaleX);
                }
                GraphApp.isZoomed = true;
            }

            GraphApp.Invalidate();
            Mouse.Capture(null);
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

        private void paintBox_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (GraphApp.toolPicker.GetSelectedTool() is ZoomTool)
            {
                GraphApp.toolPicker.GetSelectedTool().MouseRightUpHandler();
                Canvas.LayoutTransform = new ScaleTransform(1, 1);
                scrollViewer.ScrollToVerticalOffset(0);
                scrollViewer.ScrollToHorizontalOffset(0);
                GraphApp.isZoomed = false;
            }
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

        private void cancel_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.GoBack();
        }

        private void next_buttonClick(object sender, RoutedEventArgs e)
        {
            //GraphApp.GoNext();
        }

        /*private void ScrollViewer_ScrollChanged(object sender, System.Windows.Controls.ScrollChangedEventArgs e)
        {
            if (GraphApp.currentTool is HandTool)
            {
                if (Canvas.ActualWidth - e.HorizontalOffset < 900)
                {
                    VectorEditorApp.paintBox = VectorEditorApp.paintBox.Resize((int)Canvas.ActualWidth + 10, (int)Canvas.ActualHeight,
                    WriteableBitmapExtensions.Interpolation.NearestNeighbor);
                    Tool.Invalidate();
                }
                if (Canvas.ActualHeight - e.VerticalOffset < 900)
                {
                    VectorEditorApp.paintBox = VectorEditorApp.paintBox.Resize((int)Canvas.ActualWidth, (int)Canvas.ActualHeight + 10,
                    WriteableBitmapExtensions.Interpolation.NearestNeighbor);
                    Tool.Invalidate();
                }


            Canvas.Source = VectorEditorApp.paintBox;
            GraphApp.SetImageboxSize(Canvas.ActualHeight, Canvas.ActualWidth);
            }
        }*/
    }
}