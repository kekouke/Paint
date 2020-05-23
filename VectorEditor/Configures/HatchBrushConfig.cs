using System.Windows;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Controls;
using System.Collections.Generic;
using System;

namespace VectorEditorApplication
{

    public class HatchBrushConfig : Config
    {
        public Type Brush { get; set; }    

        List<string> styles = new List<string> { "Solid", "Rectangle", "Lines" };

        public HatchBrushConfig (Type brushType)
        {
            Brush = brushType;

            Configurator = new ComboBox() { SelectedItem = styles[0], Width = 80, Height = 50, ItemsSource = styles, Margin = new Thickness(5) };
            (Configurator as ComboBox).SelectionChanged += HatchBrushConfig_selectionChangedEventHandler;
        }

        private void HatchBrushConfig_selectionChangedEventHandler(object sender, SelectionChangedEventArgs args)
        {
            var index = (sender as ComboBox).SelectedIndex.ToString();

            if (index == "0")
            {
                Brush = typeof(SolidBrush);
            }
            if (index == "1")
            {
                Brush = typeof(RectBrush);
            }
            if (index == "2")
            {
                Brush = typeof(LinesBrush);
            }
        }
    }
}
