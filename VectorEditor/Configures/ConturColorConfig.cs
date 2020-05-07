using System.Windows;
using ConfigColor = System.Windows.Media.Color;
using ColorDrawing = System.Drawing.Color;
using Xceed.Wpf.Toolkit;

namespace VectorEditorApplication
{
    public class ConturColorConfig : Config
    {
        public ConfigColor colorSettings { get; set; }
        public ColorDrawing colorDrawing { get; set; }

        public ConturColorConfig(ConfigColor color)
        {
            this.colorSettings = color;
            this.colorDrawing = ColorDrawing.FromArgb(color.A, color.R, color.G, color.B);

            Configurator = new ColorPicker() { SelectedColor = color, Width = 50, Height = 50, Margin = new Thickness(5) };
            (Configurator as ColorPicker).SelectedColorChanged += ConturColorConfig_SelectedColorChanged;
        }

        private void ConturColorConfig_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<ConfigColor?> e)
        {
            colorSettings = (ConfigColor) e.NewValue;
            colorDrawing = ColorDrawing.FromArgb(colorSettings.A, colorSettings.R, colorSettings.G, colorSettings.B);
        }
    }
}
