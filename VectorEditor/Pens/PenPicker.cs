using System.Collections.Generic;
using System.Windows.Controls;
using System;
using System.Windows;

namespace VectorEditorApplication
{

    public static class PenPicker
    {
        private static readonly Dictionary<Type, ICustomPen> _pens = new Dictionary<Type, ICustomPen>();

        public static void AddPen(ICustomPen pen)
        {
            _pens.Add(pen.GetType(), pen);
        }

        private static ICustomPen GetSelectedPen(Type penType)
        {
            return _pens[penType];
        }

        public static ICustomPen GetPen(Type penType)
        {
            return GetSelectedPen(penType);
        }

    }
}
