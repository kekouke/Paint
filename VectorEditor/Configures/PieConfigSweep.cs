using System;
using System.Windows;
using System.Windows.Controls;

namespace VectorEditorApplication
{
    public class PieConfigSweep : Config
    {
        public int sweepAngle { get; set; }


        public PieConfigSweep(int sweepAngle)
        {
            this.sweepAngle = sweepAngle;

            Configurator = new TextBox()
            {
                Width = 100,
                Height = 50,
                MaxLength = 3,
                Text = sweepAngle.ToString(),
                TextAlignment = TextAlignment.Center,
                FontSize = 10
            };

            (Configurator as TextBox).TextChanged += TextBox_TextChanged;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Int32.TryParse((Configurator as TextBox).Text, out _))
            {
                sweepAngle = Int32.Parse((Configurator as TextBox).Text);
            }
            else
            {
                sweepAngle = 0;
            }
        }
    }
}
