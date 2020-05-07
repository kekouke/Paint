using System.Drawing;

namespace VectorEditorApplication
{
    interface IDrawable
    {
        void Draw(Graphics paintBox);
        void EditSize(int x, int y);
    }
}
