using System.Windows;
using System.Windows.Controls;

namespace VectorEditorApplication
{
    public class ThicknessConfig : Config
    {
        public int Thickness { get; set; }

        public ThicknessConfig(int thickness)
        {
            this.Thickness = thickness;

            Configurator = new Slider() { Width = 70, Height = 50, Value = 1, Maximum = 30, Minimum = 0 };
            (Configurator as Slider).ValueChanged += ThicknessConfig_changedEventHandler;
        }

        private void ThicknessConfig_changedEventHandler(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Thickness = (int) e.NewValue;
        }

    }
}
