using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System;

namespace VectorEditorApplication
{

    public class RotateConfig : Config
    {
        public double RotationValue { get; set; }

        public RotateConfig(double value)
        {
            RotationValue = value;

            Configurator = new Slider() { Minimum = 0, Maximum = 10, Width = 50, Margin = new Thickness(5) };
            (Configurator as Slider).ValueChanged += AnimationConfig_valueChangedEventHandler;
        }

        private void AnimationConfig_valueChangedEventHandler(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            RotationValue = e.NewValue;
        }
    }
}