using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace VectorEditorApplication
{
    public class DrawingObject : FrameworkElement
    {
        private VisualCollection _collection;
        protected override int VisualChildrenCount => _collection.Count;

        public DrawingObject()
        {
            _collection = new VisualCollection(this);
        }

        public void Invalidate(LinkedList<Figure> figures)
        {
            _collection.Clear();

            DrawingVisual drawingVisual = new DrawingVisual();

            using (var drawingContext = drawingVisual.RenderOpen())
            {
                foreach (var figure in figures)
                {
                    figure.Draw(drawingContext);
                }
            }
            _collection.Add(drawingVisual);
        }

        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= _collection.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _collection[index];
        }
    }
}
