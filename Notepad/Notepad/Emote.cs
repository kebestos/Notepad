using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Notepad
{
    class Emote : Shape
    {
        Image image;
        public float size;
        public int x;
        public int y;
        public Emote(Image image, float size, int x, int y)
        {
            this.size = size;
            this.image = image;
            this.x = x;
            this.y = y;
        }

        public override void Draw(string caracte, Graphics graphic)
        {   
            graphic.DrawImage(image,x,y, size, size);
        }

        public override String GetX()
        {
            return Convert.ToString(x);
        }

        public override String GetY()
        {
            return Convert.ToString(y);
        }

        public override void SetX(int x)
        {
            this.x = x;
        }

        public override void SetY(int y)
        {
            this.y = y;
        }
    }
}

