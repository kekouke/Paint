using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Collections.Generic;
using System;

namespace VectorEditorApplication
{

    public class DashStyleConfig : Config
    {
        public Type Pencil { get; set; }
        List<string> styles = new List<string> {"Solid", "Dot", "Dash", "DashDot", "DashDotDot" };

        public DashStyleConfig(Type penType)
        {
            Pencil = penType;
            Configurator = new ComboBox() { SelectedItem = styles[0], Width = 80, Height = 50, ItemsSource = styles, Margin = new Thickness(5) };
            (Configurator as ComboBox).SelectionChanged += DashCapConfig_selectionChangedEventHandler;
        }

        private void DashCapConfig_selectionChangedEventHandler(object sender, SelectionChangedEventArgs args)
        {
            var index = (sender as ComboBox).SelectedIndex.ToString();

            if (index == "0")
            {
               Pencil = typeof(SolidPen);
            }
            if (index == "1")
            {
                Pencil = typeof(DotPen);
            }
            if (index == "2")
            {
                Pencil = typeof(DashPen);
            }
            if (index == "3")
            {
                Pencil = typeof(DashDotPen);
            }
            if (index == "4")
            {
                Pencil = typeof(DashDotDotPen);
            }
        }
    }
}
