using System;
using System.Collections.Generic;
using System.Windows;
using System.Text;

namespace VectorEditorApplication
{
    abstract class Animation
    {
        public abstract void Tick();
        public abstract Point Transform(Point p);
        public abstract double Transform(double angle);
    }
}
