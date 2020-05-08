using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Interop;
using VectorEditorApplication;
using System.Drawing;
using Color = System.Drawing.Color;


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
            picture = new Bitmap(652, 452);
            GraphApp = new VectorEditorApp(picture); //652 452

            GraphApp.toolPicker.AddTool(new RectTool());
            GraphApp.toolPicker.AddTool(new EllipseTool());
            GraphApp.toolPicker.AddTool(new LineTool());
            GraphApp.toolPicker.AddTool(new PencilTool());
            GraphApp.toolPicker.AddTool(new ZoomTool());
            GraphApp.toolPicker.AddTool(new HandTool());
            GraphApp.toolPicker.AddTool(new PieTool());

            GraphApp.SetCurrentTool(GraphApp.toolPicker.tools[0].Item1);
            GraphApp.toolPicker.ShowInterface(param, GraphApp.toolPicker.tools[0].Item2, 0); //TODO

            //slider.Value = 1;
            //VectorEditorApp.thickness = (int)slider.Value;

            Display();
        }

        #region MouseHandlers
        private void paintBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(image);
            var clickCord = e.GetPosition(image);
            GraphApp.currentTool.MouseDownHandler((int)clickCord.X, (int)clickCord.Y);
            Display();
        }

        private void paintBox_MouseMove(object sender, MouseEventArgs e)
        {
            var clickCord = e.GetPosition(image);
            GraphApp.currentTool.MouseMoveHandler((int)clickCord.X, (int)clickCord.Y);

            if (GraphApp.currentTool is HandTool && HandTool.handActive)
            {
                ScrollViewer.ScrollToVerticalOffset(VectorEditorApp.screenOffsetY);
                ScrollViewer.ScrollToHorizontalOffset(VectorEditorApp.screenOffsetX);
            }

            Display();
        }

        private void paintBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GraphApp.currentTool.MouseUpHandler();

            if (GraphApp.currentTool is ZoomTool)
            {

                image.LayoutTransform = new ScaleTransform(VectorEditorApp.scaleX, VectorEditorApp.scaleY);

                if (ZoomTool.justClick)
                {
                    ScrollViewer.ScrollToVerticalOffset(e.GetPosition(image).Y);
                    ScrollViewer.ScrollToHorizontalOffset(e.GetPosition(image).X);
                }
                else
                {
                    ScrollViewer.ScrollToVerticalOffset(VectorEditorApp.distanceToPointY);
                    ScrollViewer.ScrollToHorizontalOffset(VectorEditorApp.distanceToPointX);
                }
            }

            Mouse.Capture(null);
            Display();
        }

        private void paintBox_MouseLeave(object sender, MouseEventArgs e)
        {
            GraphApp.currentTool.MouseLeaveHandler();
        }

        private void paintBox_MouseEnter(object sender, MouseEventArgs e)
        {
            var coord = e.GetPosition(image);
            GraphApp.currentTool.MouseEnterHandler((int)coord.X, (int)coord.Y);
        }

        private void paintBox_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (GraphApp.currentTool is ZoomTool)
            {
                GraphApp.currentTool.MouseRightUpHandler();
                image.LayoutTransform = new ScaleTransform(1, 1);
                ScrollViewer.ScrollToVerticalOffset(0);
                ScrollViewer.ScrollToHorizontalOffset(0);
            }
        }
        #endregion

        #region Tools
        private void rectangle_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.SetCurrentTool(GraphApp.toolPicker.tools[0].Item1);
            GraphApp.toolPicker.ShowInterface(param, GraphApp.toolPicker.tools[0].Item2, 0);
        }

        private void elipse_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.SetCurrentTool(GraphApp.toolPicker.tools[1].Item1);
            GraphApp.toolPicker.ShowInterface(param, GraphApp.toolPicker.tools[1].Item2, 1);
        }

        private void line_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.SetCurrentTool(GraphApp.toolPicker.tools[2].Item1);
            GraphApp.toolPicker.ShowInterface(param, GraphApp.toolPicker.tools[2].Item2, 2);
        }

        private void pencil_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.SetCurrentTool(GraphApp.toolPicker.tools[3].Item1);
            GraphApp.toolPicker.ShowInterface(param, GraphApp.toolPicker.tools[3].Item2, 3);
        }

        private void zoom_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.SetCurrentTool(GraphApp.toolPicker.tools[4].Item1);
            GraphApp.toolPicker.ShowInterface(param, GraphApp.toolPicker.tools[4].Item2, 4);
        }

        private void hand_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.SetCurrentTool(GraphApp.toolPicker.tools[5].Item1);
            GraphApp.toolPicker.ShowInterface(param, GraphApp.toolPicker.tools[5].Item2, 5);
        }
        private void pie_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.SetCurrentTool(GraphApp.toolPicker.tools[6].Item1);
            GraphApp.toolPicker.ShowInterface(param, GraphApp.toolPicker.tools[6].Item2, 6);
        }
        #endregion

        // TODO Field
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
        }

/*        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GraphApp.SetThicknessValue((int)slider.Value);
            sliderValue.Text = ((int)slider.Value).ToString();
        }*/

        private void image_Loaded(object sender, RoutedEventArgs e)
        {
            GraphApp.SetImageboxSize(image.ActualHeight, image.ActualWidth);
            //Display();
        }

        private void cancel_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.GoBack();
            Display();
        }

        private void Display()
        {
            var handle = picture.GetHbitmap();
            image.Source = Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            DeleteObject(handle);
        }

        private void next_buttonClick(object sender, RoutedEventArgs e)
        {
            GraphApp.GoNext();
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