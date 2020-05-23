using System.Windows;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;

namespace VectorEditorApplication
{
    public class ConturColorConfig : Config
    {
        public Color Color { get; set; }

        public ConturColorConfig(Color color)
        {
            Color = color;

            Configurator = new ColorPicker() { SelectedColor = color, Width = 50, Height = 50, Margin = new Thickness(5) };
            (Configurator as ColorPicker).SelectedColorChanged += ConturColorConfig_SelectedColorChanged;
        }
        
        private void ConturColorConfig_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            Color = (Color) e.NewValue;
        }
    }
}
