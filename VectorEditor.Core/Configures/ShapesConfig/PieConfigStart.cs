using System;
using System.Windows;
using System.Windows.Controls;

namespace VectorEditorApplication
{
    public class PieConfigStart : Config
    {
        public int startAngle { get; set; }


        public PieConfigStart(int startAngle)
        {
            this.startAngle = startAngle;

            Configurator = new TextBox()
            {
                Width = 100,
                Height = 50,
                MaxLength = 3,
                Text = startAngle.ToString(),
                TextAlignment = TextAlignment.Center,
                FontSize = 10
            };

            (Configurator as TextBox).TextChanged += TextBox_TextChanged;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Int32.TryParse((Configurator as TextBox).Text, out _))
            {
                startAngle = Int32.Parse((Configurator as TextBox).Text);
            }
            else
            {
                startAngle = 0;
                (Configurator as TextBox).Text = "0";
            }
        }
    }
}