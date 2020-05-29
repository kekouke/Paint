using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace VectorEditorApplication
{
    public class Animate : NotDrawingTool
    {
        private RotateConfig _rotation;
        private ScaleConfig _scale;
        private TranslateConfig _translate;

        public RotateConfig Rotation { get => _rotation; set => Rotation = value; }
        public ScaleConfig Scale { get => _scale; set => Scale = value; }
        public TranslateConfig Translate { get => _translate; set => Translate = value; }

        public Animate()
        {
            _translate = new TranslateConfig(0);
            _rotation = new RotateConfig(0);
            _scale = new ScaleConfig(0);

            ToolForm = new Button()
            {
                Width = 60,
                Height = 30,
                Content = "Animate!",
                Margin = new Thickness(5)
            };
        }

        public override void MouseDownHandler(Point point, ViewPort vp)
        {
            Figure selectLayout = new Rectangle(point, point, PenPicker.GetPen(typeof(DashPen)).GetPen(Colors.Black, 3), new SolidColorBrush());
            selectLayout.ToLocalSpace(vp);

            PaintController.figures.AddLast(selectLayout);
            currentState = States.mouseClick;
        }

        public override void MouseMoveHandler(Point point, ViewPort vp)
        {
            if (currentState == States.mouseClick)
            {
                PaintController.figures.Last.Value.EditSize(point, vp);
            }
        }

        public override void MouseUpHandler(ViewPort vp)
        {
            currentState = States.initial;
            StartPoint = PaintController.figures.Last.Value.firstPoint;
            EndPoint = PaintController.figures.Last.Value.secondPoint;
            PaintController.figures.RemoveLast();
            MakeAnimation();
        }

        private void MakeAnimation()
        {
            foreach (var shape in PaintController.figures)
            {
                if (shape.CheckIntersection(StartPoint, EndPoint))
                {
                    if (Rotation.RotationValue != 0)
                    {
                        shape.AddAnim(new RotationAnimation(Rotation.RotationValue));
                    }
                    if (Scale.ScaleValue != 0)
                    {
                        shape.AddAnim(new ScaleAnimation(Scale.ScaleValue));
                    }
                    if (Translate.TranslateValue != 0)
                    {
                        shape.AddAnim(new TranslateAnimation(Translate.TranslateValue));
                    }
                }
            }
        }
    }
}
