﻿using Color = System.Drawing.Color;
using System.Windows.Controls;

namespace VectorEditorApplication
{
    public class RectTool : DrawingTool
    {
        private ConturColorConfig conturColor;
        private FillColorConfig fillColor;


        public ConturColorConfig ConturColor { get { return conturColor; } set { ConturColor = value; } }
        public FillColorConfig FillColor { get { return fillColor; } set { FillColor = value; } }

        public RectTool()
        {
            conturColor = new ConturColorConfig(System.Windows.Media.Colors.Black);
            fillColor = new FillColorConfig(System.Windows.Media.Colors.White);
        }

        public override void MouseDownHandler(int x, int y)
        {
            VectorEditorApp.figures.AddLast(CreateFigure(x, y, x, y, conturColor.colorDrawing, fillColor.colorDrawing, VectorEditorApp.thickness));
            Invalidate();
            currentState = States.mouseClick;
        }
        public override void MouseMoveHandler(int x, int y)
        {
            if (currentState == States.mouseClick)
            {
                VectorEditorApp.figures.Last.Value.EditSize(x, y);
                Invalidate();
            }
        }

        protected override Figure CreateFigure(int x1, int y1, int x2, int y2, Color conturColor, Color fillColor, int thickness)
        {
            return new Rectangle(x1, y1, x2, y2, conturColor, fillColor, thickness);
        }
    }
}
