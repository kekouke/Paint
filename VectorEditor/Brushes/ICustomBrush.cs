using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace VectorEditorApplication
{
    public interface ICustomBrush
    {
        public Brush GetBrush(Color color);
    }
}
