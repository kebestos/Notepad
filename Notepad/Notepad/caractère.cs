using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Notepad 
{
    class caractère : Shape
    {
        public string caractere;
        public Color couleur;
        public FontStyle fontstyle;
        public float size;
        public string font1;
        public int x;
        public int y;
        
        public caractère(string caractere,Color couleur, FontStyle fontstyle,float size,string font1, int x, int y)
        {
            this.font1 = font1;
            this.caractere = caractere;
            this.couleur = couleur;
            this.fontstyle = fontstyle;
            this.size = size;
            this.x = x;
            this.y = y;
        }

        public override String GetCaract()
        {
            return caractere;
        }

        public override void Draw(string caracte, Graphics graphic) 
        {            
            Font font = new Font(font1, size, fontstyle);
            SolidBrush sb = new SolidBrush(couleur);
            graphic.DrawString(caracte, font, sb,x,y);
            
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
