using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Notepad
{
    class Shape
    {
        public Shape()
        {
        }

        public virtual void Draw(string caracte, Graphics graphic)
        {
        }

        public virtual String GetCaract()
        {
            return "";
        }

        public virtual String GetX()
        {
            return "";
        }
        public virtual String GetY()
        {
            return "";
        }

        public virtual void SetX(int x)
        {
            
        }
        public virtual void SetY(int y)
        {

        }
    }
}