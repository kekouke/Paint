using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace VectorEditorApplication
{
    public class SolidBrush : ICustomBrush
    {
        public Brush GetBrush(Color color)
        {
            return new SolidColorBrush(color);
        }
    }
}
