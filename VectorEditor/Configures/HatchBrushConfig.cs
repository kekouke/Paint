using System.Windows;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Controls;
using System.Collections.Generic;

namespace VectorEditorApplication
{

    public class HatchBrushConfig : Config
    {
        public HatchStyle fillStyle { get; set; }
        public Color colorHatch { get; set; }
        

        List<string> styles = new List<string> { "Zig-Zag", "Horizontal", "Vertical", "Divot", "Plaid", "None" };

        public HatchBrushConfig (HatchStyle hatchStyle)
        {
            this.fillStyle = hatchStyle;

            Configurator = new ComboBox() { SelectedItem = styles[0], Width = 80, Height = 50, ItemsSource = styles, Margin = new Thickness(5) };
            (Configurator as ComboBox).SelectionChanged += HatchBrushConfig_selectionChangedEventHandler;
        }

        private void HatchBrushConfig_selectionChangedEventHandler(object sender, SelectionChangedEventArgs args)
        {
            var index = (sender as ComboBox).SelectedIndex.ToString();

            if (index == "0")
            {
                fillStyle = HatchStyle.ZigZag;
            }
            if (index == "1")
            {
                fillStyle = HatchStyle.Horizontal;
            }
            if (index == "2")
            {
                fillStyle = HatchStyle.Vertical;
            }
            if (index == "3")
            {
                fillStyle = HatchStyle.Divot;
            }
            if (index == "4")
            {
                fillStyle = HatchStyle.Plaid;
            }
        }
    }
}
