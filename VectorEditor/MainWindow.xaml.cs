using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Interop;
using VectorEditorApplication;
using System.Drawing;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
            picture = new Bitmap(1000, 1000);
            GraphApp = new VectorEditorApp(picture);

            GraphApp.toolPicker.AddTool(new RectTool());
            GraphApp.toolPicker.AddTool(new EllipseTool());
            GraphApp.toolPicker.AddTool(new LineTool());
            GraphApp.toolPicker.AddTool(new PencilTool());
            GraphApp.toolPicker.AddTool(new ZoomTool());
            GraphApp.toolPicker.AddTool(new HandTool());
            GraphApp.toolPicker.AddTool(new PieTool());

            GraphApp.toolPicker.DisplayInterface(toolParam, param);

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

            if (GraphApp.toolPicker.GetSelectedTool() is HandTool && HandTool.handActive)
            {
                ScrollViewer.ScrollToVerticalOffset(VectorEditorApp.screenOffsetY);
                ScrollViewer.ScrollToHorizontalOffset(VectorEditorApp.screenOffsetX);
            }

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
                    ScrollViewer.ScrollToVerticalOffset(e.GetPosition(image).Y);
                    ScrollViewer.ScrollToHorizontalOffset(e.GetPosition(image).X);
                }
                else
                {
                    ScrollViewer.ScrollToVerticalOffset(VectorEditorApp.distanceToPointY * VectorEditorApp.scaleY);
                    ScrollViewer.ScrollToHorizontalOffset(VectorEditorApp.distanceToPointX * VectorEditorApp.scaleX);
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
                ScrollViewer.ScrollToVerticalOffset(0);
                ScrollViewer.ScrollToHorizontalOffset(0);
                GraphApp.isZoomed = false;
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

        private void image_Loaded(object sender, RoutedEventArgs e)
        {
            GraphApp.SetImageboxSize(652, 452);
        }

        private void cancel_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.GoBack();
            Display();
        }

        private void next_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.GoNext();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;

            string value = menuItem.Header.ToString();


            if (value == "Exit")
            {
                Close();
            }
            if (value == "About")
            {
                MessageBox.Show("Paint Clone\n© Козицкий Михаил(kekouke),\n2020.");
            }
            if (value == "Save")
            {
                GraphApp.SaveImage();
            }
            if (value == "Open")
            {
                GraphApp.OpenImage();
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }
        /*        private void ScrollViewer_ScrollChanged(object sender, System.Windows.Controls.ScrollChangedEventArgs e)
{
if (GraphApp.currentTool is HandTool)
{
if (image.ActualWidth - e.HorizontalOffset < 900)
{
 VectorEditorApp.paintBox = VectorEditorApp.paintBox.Resize((int)image.ActualWidth + 10, (int)image.ActualHeight, WriteableBitmapExtensions.Interpolation.NearestNeighbor);
 Tool.Invalidate();
}
if (image.ActualHeight - e.VerticalOffset < 900)
{
 VectorEditorApp.paintBox = VectorEditorApp.paintBox.Resize((int)image.ActualWidth, (int)image.ActualHeight + 10, WriteableBitmapExtensions.Interpolation.NearestNeighbor);
 Tool.Invalidate();
}


image.Source = VectorEditorApp.paintBox;
GraphApp.SetImageboxSize(image.ActualHeight, image.ActualWidth);
}
}*/
    }
}