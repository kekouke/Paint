using System.Windows;
using System.Drawing;
using System.Drawing.Drawing2D;
using Xceed.Wpf.Toolkit;
using System.Windows.Controls;
using System.Collections.Generic;

namespace VectorEditorApplication
{

    public class DashStyleConfig : Config
    {
        public DashStyle dashStyle { get; set; }
        List<string> styles = new List<string> {"Solid", "Dash", "Dot", "DashDot", "DashDotDot" };

        public DashStyleConfig(DashStyle dashStyle)
        {
            this.dashStyle = dashStyle;

            Configurator = new ComboBox() { SelectedItem = styles[0], Width = 80, Height = 50, ItemsSource = styles, Margin = new Thickness(5) };
            (Configurator as ComboBox).SelectionChanged += DashCapConfig_selectionChangedEventHandler;
        }

        private void DashCapConfig_selectionChangedEventHandler(object sender, SelectionChangedEventArgs args)
        {
            var index = (sender as ComboBox).SelectedIndex.ToString();

            if (index == "0")
            {
                dashStyle = DashStyle.Solid;
            }
            if (index == "1")
            {
                dashStyle = DashStyle.Dash;
            }
            if (index == "2")
            {
                dashStyle = DashStyle.Dot;
            }
            if (index == "3")
            {
                dashStyle = DashStyle.DashDot;
            }
            if (index == "4")
            {
                dashStyle = DashStyle.DashDotDot;
            }
        }
    }
}
