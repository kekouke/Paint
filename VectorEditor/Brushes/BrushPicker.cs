using System.Collections.Generic;
using System;

namespace VectorEditorApplication
{

    public static class BrushPicker
    {
        private static readonly Dictionary<Type, ICustomBrush> _brushes = new Dictionary<Type, ICustomBrush>();

        public static void AddBrush(ICustomBrush brush)
        {
            _brushes.Add(brush.GetType(), brush);
        }

        private static ICustomBrush GetSelectedBrush(Type brushType)
        {
            return _brushes[brushType];
        }

        public static ICustomBrush GetBrush(Type brushType)
        {
            return GetSelectedBrush(brushType);
        }

    }
}
