using System.Drawing;
using System.Runtime.Serialization;

namespace VectorEditorApplication
{
    public interface IDrawable
    {
        void Draw(Graphics paintBox);
        void EditSize(int x, int y);
    }
}
