﻿using System.Drawing;

namespace VectorEditorApplication
{
    public class PieTool : DrawingTool
    {

        ConturColorConfig conturColor;
        FillColorConfig fillColor;

        public ConturColorConfig ConturColor { get { return conturColor; } set { ConturColor = value; } }
        public FillColorConfig FillColor { get { return fillColor; } set { FillColor = value; } }

        public PieTool()
        {
            conturColor = new ConturColorConfig(System.Windows.Media.Colors.Black);
            fillColor = new FillColorConfig(System.Windows.Media.Colors.White);
        }

        public override void MouseDownHandler(int x, int y)
        {
            VectorEditorApp.figures.AddLast(CreateLayout(x, y, x, y, conturColor.colorDrawing, fillColor.colorDrawing, VectorEditorApp.thickness));
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

        public override void MouseUpHandler()
        {
            currentState = States.initial;
            LayoutToPie(VectorEditorApp.figures.Last.Value as Rectangle);
            Invalidate();
        }

        private Figure CreateLayout(int x1, int y1, int x2, int y2, Color conturColor, Color fillColor, int thickness)
        {
            return new Rectangle(x1, y1, x2, y2, conturColor, fillColor, thickness);
        }

        protected override Figure CreateFigure(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor, int thickness)
        {
            return new Pie(x1, y1, x2, y2, conturColor, gradientColor, thickness);
        }

        private void LayoutToPie(Rectangle rect)
        {
            VectorEditorApp.figures.AddLast(CreateFigure(rect.leftXDraw, rect.leftYDraw, rect.rightXDraw, rect.rightYDraw,
                                            rect.conturColor, rect.gradientColor, rect.thickness));

            VectorEditorApp.figures.Remove(VectorEditorApp.figures.Last.Previous);
        }

    }
}
