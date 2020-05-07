using System.Windows;
using ConfigColor = System.Windows.Media.Color;
using ColorDrawing = System.Drawing.Color;
using Xceed.Wpf.Toolkit;

namespace VectorEditorApplication
{
    public class FillColorConfig : Config
    {
        public ConfigColor colorSettings { get; set; }
        public ColorDrawing colorDrawing { get; set; }

        public FillColorConfig(ConfigColor color)
        {
            this.colorSettings = color;
            this.colorDrawing = ColorDrawing.FromArgb(color.A, color.R, color.G, color.B);

            Configurator = new ColorPicker() { SelectedColor = color, Width = 50, Height = 50, Margin = new Thickness(5) };
            (Configurator as ColorPicker).SelectedColorChanged += FillColorConfig_SelectedColorChanged;
        }

        private void FillColorConfig_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<ConfigColor?> e)
        {
            colorSettings = (ConfigColor) e.NewValue;
            colorDrawing = ColorDrawing.FromArgb(colorSettings.A, colorSettings.R, colorSettings.G, colorSettings.B);
        }
    }
}
