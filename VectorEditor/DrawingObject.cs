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

        public void Invalidate(LinkedList<Figure> figures, ViewPort vp)
        {
            _collection.Clear();

            var drawingVisual = new DrawingVisual();

            using (var drawingContext = drawingVisual.RenderOpen())
            {
                foreach (var figure in figures)
                {
                    //MessageBox.Show((figure as TwoPointFigure).points[0].ToString() + "or");
                    var globalFigure = (figure.Clone() as Figure);
                    globalFigure.ToWorldSpace(vp);
                    //MessageBox.Show((globalFigure as TwoPointFigure).points[0].ToString());
                    globalFigure.Draw(drawingContext, vp);
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
