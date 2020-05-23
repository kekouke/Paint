using System.Windows;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;

namespace VectorEditorApplication
{
    public class FillColorConfig : Config
    {
        public Color Color { get; set; }

        public FillColorConfig(Color color)
        {
            Color = color;

            Configurator = new ColorPicker() { SelectedColor = color, Width = 50, Height = 50, Margin = new Thickness(5) };
            (Configurator as ColorPicker).SelectedColorChanged += FillColorConfig_SelectedColorChanged;
        }

        private void FillColorConfig_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            Color = (Color) e.NewValue;
        }
    }
}
