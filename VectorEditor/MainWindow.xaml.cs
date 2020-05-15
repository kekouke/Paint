using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Interop;
using VectorEditorApplication;
using System.Drawing;
using Microsoft.Win32;

namespace VectorEditor
{
    public partial class MainWindow : Window
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);


        VectorEditorApp GraphApp;
        Bitmap picture;

        public MainWindow()
        {
            InitializeComponent();
            picture = new Bitmap(770, 385);
            GraphApp = new VectorEditorApp(picture);

            GraphApp.toolPicker.AddTool(new RectTool());
            GraphApp.toolPicker.AddTool(new EllipseTool());
            GraphApp.toolPicker.AddTool(new LineTool());
            GraphApp.toolPicker.AddTool(new PencilTool());
            GraphApp.toolPicker.AddTool(new ZoomTool());
            GraphApp.toolPicker.AddTool(new HandTool());
            GraphApp.toolPicker.AddTool(new PieTool());

            GraphApp.toolPicker.DisplayInterface(toolParam, param);
            GraphApp.SetImageboxSize(1000, 1000);
            Display();
        }

        #region MouseHandlers
        private void paintBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(image);
            var clickCord = e.GetPosition(image);
            GraphApp.toolPicker.GetSelectedTool().MouseDownHandler((int)clickCord.X, (int)clickCord.Y);
            Display();
        }

        private void paintBox_MouseMove(object sender, MouseEventArgs e)
        {
            var clickCord = e.GetPosition(image);
            GraphApp.toolPicker.GetSelectedTool().MouseMoveHandler((int)clickCord.X, (int)clickCord.Y);

            scrollViewer.ScrollToVerticalOffset(VectorEditorApp.screenOffsetY);
            scrollViewer.ScrollToHorizontalOffset(VectorEditorApp.screenOffsetX);

            Display();
        }

        private void paintBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GraphApp.toolPicker.GetSelectedTool().MouseUpHandler();

            if (GraphApp.toolPicker.GetSelectedTool() is ZoomTool && !GraphApp.isZoomed)
            {

                image.LayoutTransform = new ScaleTransform(VectorEditorApp.scaleX, VectorEditorApp.scaleY);

                if (ZoomTool.justClick)
                {
                    scrollViewer.ScrollToVerticalOffset(e.GetPosition(image).Y);
                    scrollViewer.ScrollToHorizontalOffset(e.GetPosition(image).X);
                }
                else
                {
                    scrollViewer.ScrollToVerticalOffset(VectorEditorApp.distanceToPointY * VectorEditorApp.scaleY);
                    scrollViewer.ScrollToHorizontalOffset(VectorEditorApp.distanceToPointX * VectorEditorApp.scaleX);
                }
                GraphApp.isZoomed = true;
            }

            Mouse.Capture(null);
            Display();
        }

        private void paintBox_MouseLeave(object sender, MouseEventArgs e)
        {
            GraphApp.toolPicker.GetSelectedTool().MouseLeaveHandler();
        }

        private void paintBox_MouseEnter(object sender, MouseEventArgs e)
        {
            var coord = e.GetPosition(image);
            GraphApp.toolPicker.GetSelectedTool().MouseEnterHandler((int)coord.X, (int)coord.Y);
        }

        private void paintBox_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (GraphApp.toolPicker.GetSelectedTool() is ZoomTool)
            {
                GraphApp.toolPicker.GetSelectedTool().MouseRightUpHandler();
                image.LayoutTransform = new ScaleTransform(1, 1);
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
        private void Display()
        {
            var handle = picture.GetHbitmap();
            image.Source = Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            DeleteObject(handle);
        }

        // TODO Field
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
        }

        private void cancel_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.GoBack();
            Display();
        }

        private void next_buttonClick(object sender, RoutedEventArgs e)
        {
            //GraphApp.GoNext();
        }

        /*private void ScrollViewer_ScrollChanged(object sender, System.Windows.Controls.ScrollChangedEventArgs e)
        {
            if (GraphApp.currentTool is HandTool)
            {
                if (image.ActualWidth - e.HorizontalOffset < 900)
                {
                    VectorEditorApp.paintBox = VectorEditorApp.paintBox.Resize((int)image.ActualWidth + 10, (int)image.ActualHeight,
                    WriteableBitmapExtensions.Interpolation.NearestNeighbor);
                    Tool.Invalidate();
                }
                if (image.ActualHeight - e.VerticalOffset < 900)
                {
                    VectorEditorApp.paintBox = VectorEditorApp.paintBox.Resize((int)image.ActualWidth, (int)image.ActualHeight + 10,
                    WriteableBitmapExtensions.Interpolation.NearestNeighbor);
                    Tool.Invalidate();
                }


            image.Source = VectorEditorApp.paintBox;
            GraphApp.SetImageboxSize(image.ActualHeight, image.ActualWidth);
            }
        }*/
    }
}