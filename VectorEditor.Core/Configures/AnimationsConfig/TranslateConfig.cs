using System;
using System.Windows.Controls;
using System.Windows;

namespace VectorEditorApplication
{
    public class TranslateConfig : Config
    {
        public double TranslateValue { get; set; }

        public TranslateConfig(double value)
        {
            TranslateValue = value;

            Configurator = new Slider() { Minimum = 0, Maximum = 10, Width = 50, Margin = new Thickness(5) };
            (Configurator as Slider).ValueChanged += AnimationConfig_valueChangedEventHandler;
        }

        private void AnimationConfig_valueChangedEventHandler(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TranslateValue = e.NewValue;
        }
    }
}
