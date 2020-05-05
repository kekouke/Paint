using System;
using System.Windows;
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
        VectorEditorApp GraphApp;
        Bitmap picture;

        public MainWindow()
        {
            InitializeComponent();
            picture = new Bitmap(652, 452);
            GraphApp = new VectorEditorApp(picture); //652 452
            slider.Value = 1;
            VectorEditorApp.thickness = (int)slider.Value;
            conturPalette.SelectedColor = Colors.Black;
            fillPalette.SelectedColor = Colors.White;
            GraphApp.SetFillColor(Color.White);
            GraphApp.SetConturColor(Color.Black);
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
        #endregion

        #region Palette
        private void conturPalette_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color?> e)
        {
            var fillColor = (System.Windows.Media.Color)e.NewValue;
            var drawingcolor = Color.FromArgb(fillColor.A, fillColor.R, fillColor.G, fillColor.B);
            GraphApp.SetConturColor(drawingcolor);
        }

        private void fillPalette_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color?> e)
        {
            var fillColor = (System.Windows.Media.Color) e.NewValue;
            var drawingcolor = Color.FromArgb(fillColor.A, fillColor.R, fillColor.G, fillColor.B);
            GraphApp.SetFillColor(drawingcolor);
        }
        #endregion
        // TODO Field
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GraphApp.SetThicknessValue((int)slider.Value);
            sliderValue.Text = ((int)slider.Value).ToString();
        }

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