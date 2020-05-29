using System.Windows;
using System.Windows.Controls;

namespace VectorEditorApplication
{

    public class FlashConfig : Config
    {
        public double FlashValue { get; set; }

        public FlashConfig(double value)
        {
            FlashValue = value;

            Configurator = new Slider() { Minimum = 0, Maximum = 10, Width = 50, Margin = new Thickness(5) };
            (Configurator as Slider).ValueChanged += AnimationConfig_valueChangedEventHandler;
        }

        private void AnimationConfig_valueChangedEventHandler(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            FlashValue = e.NewValue;
        }
    }
}