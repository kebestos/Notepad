using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Notepad : Form
    {
        Bitmap B = new Bitmap(747, 308);
        Bitmap A = new Bitmap(300, 90);
        Graphics graphics;
        
        List<Image> Emot = new List<Image>();
        List<Shape> Objet = new List<Shape>();
        Graphics emotg;
        Color colorcaract = Color.Black;
        int x = 2;
        int y = 2;
        int index = 0;
        int element = 51;

        FontStyle fontstyle = FontStyle.Regular;

        public Notepad()
        {
            InitializeComponent();
            pictureBox1.Image = B;
            graphics = Graphics.FromImage(pictureBox1.Image);
            graphics.Clear(Color.White);
            pictureBox2.Image = A;
            emotg = Graphics.FromImage(pictureBox2.Image);
            emotg.Clear(Color.White);
            panel3.BackColor = Color.Blue;
            panel2.BackColor = Color.DarkRed;
            panel5.BackColor = Color.Yellow;
            panel4.BackColor = Color.Black;
            Emot.Add(Properties.Resources.emot1);
            Emot.Add(Properties.Resources.emot2);
            Emot.Add(Properties.Resources.emot3);
            Emot.Add(Properties.Resources.emot4);
            Emot.Add(Properties.Resources.emot5);
            Emot.Add(Properties.Resources.emot6);
            DrawEmot();
            DrawCursseur(-5);
        }

        public void DrawEmot()
        {
            float x1 = 2.0F;
            float y1 = 2.0F;
            foreach (Image emot in Emot)
            {
                emotg.DrawImage(emot, x1, y1, 40, 40);
                x1 += 45;
                if (x1 >= 137)
                {
                    x1 = 2;
                    y1 = 45;
                }
            }
        }

        public void DrawTout()
        {
            int a = Objet.Count();
            int width = (pictureBox1.Width) / 80;
            int height = (pictureBox1.Height) / 10;

            graphics.Clear(Color.White);
            foreach (Shape caracte in Objet)
            {                
                if(caracte.GetCaract() != "Enter")
                {
                    caracte.Draw(caracte.GetCaract(), graphics);
                } 
            }
            pictureBox1.Invalidate();
        }

        public void Removed(int width, int height)
        {
            if (index != 0)
            {
                index--;
                Objet.RemoveAt(index);
                Position(width, height);
                DrawTout();
                DrawCursseur(width);
            }                      
        }

        private void Notepad_KeyPress(object sender, KeyPressEventArgs e)
        {
            float fontsize = (int) numericUpDown1.Value;
            string font = comboBox1.Text;
            int height = (pictureBox1.Height) / 10;
            int width = (pictureBox1.Width) / 80;
            int count = Objet.Count();

            if (e.KeyChar != (char) Keys.Back && e.KeyChar != (char) Keys.Enter)
            {
                caractère caract = new caractère(e.KeyChar.ToString(), colorcaract, fontstyle, fontsize, font, x, y);
                Objet.Insert(index,caract);
                index++;                
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                if (Objet.Count() != 0)                {

                    Removed(width, height);
                }
                else
                {
                    x = 2;
                }
                
            }
            else if(e.KeyChar == (char)Keys.Enter)
            {
                caractère caract = new caractère("Enter", colorcaract, fontstyle, fontsize, font, x, y);
                Objet.Insert(index, caract);
                index++;
            }
            Position(width, height);
            DrawTout();
            DrawCursseur(width);
        }

        private void panel3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            colorcaract = panel3.BackColor;
        }

        private void panel5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            colorcaract = panel5.BackColor;
        }

        private void panel2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            colorcaract = panel2.BackColor;
        }

        private void panel4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            colorcaract = panel4.BackColor;
        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                fontstyle = FontStyle.Underline;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                fontstyle = FontStyle.Bold;
            }
        }

        private void Regular_CheckedChanged(object sender, EventArgs e)
        {
            if (Regular.Checked)
            {
                fontstyle = FontStyle.Regular;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                fontstyle = FontStyle.Italic;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.ActiveControl = pictureBox1;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            int width = (pictureBox1.Width) / 80;
            int height = (pictureBox1.Height) / 10;
            this.ActiveControl = pictureBox1;
            int a = Objet.Count();

            if (a != 0)
            {                
                if (keyData == (Keys.Right))
                {
                    if (index < Objet.Count())
                    {
                        index++;
                        x += width + 5;
                    }
                    DrawTout();
                    DrawCursseur(width);
                }
                if (keyData == (Keys.Left))
                {
                    if (index > 0)
                    {
                        index--;
                        x -= width + 5;
                    }                  
                    DrawTout();
                    DrawCursseur(width);
                }
                if (keyData == (Keys.Down))
                {
                    foreach (Shape objet in Objet)
                    {
                        if (index > 0)
                        {
                            if (objet.GetX() == Objet[index - 1].GetX() && Int32.Parse(objet.GetY()) == Int32.Parse(Objet[index - 1].GetY()) + height)
                            {
                                index = Objet.IndexOf(objet) + 1;
                                y += height;
                                x += width + 5;
                                break;
                            }
                        }
                        else
                        {
                            if (objet.GetX() == Objet[index].GetX() && Int32.Parse(objet.GetY()) == Int32.Parse(Objet[index].GetY()) + height)
                            {
                                index = Objet.IndexOf(objet);
                                y += height;
                                x += width + 5;
                                break;
                            }
                        }
                        
                    }
                    DrawTout();
                    DrawCursseur(width);
                }
                if (keyData == (Keys.Up))
                {
                    if (index > 0)
                    {
                        foreach (Shape objet in Objet)
                        {

                            if (objet.GetX() == Objet[index - 1].GetX() && Int32.Parse(objet.GetY()) == Int32.Parse(Objet[index - 1].GetY()) - height)
                            {
                                index = Objet.IndexOf(objet) + 1;
                                y -= height;
                                x += width + 5;
                                break;
                            }
                        }
                    }             
                    DrawTout();
                    DrawCursseur(width);
                }
            }            
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void DrawCursseur(int width)
        {
            Pen pen = new Pen(Color.Black);
            Point pt1;
            Point pt2;
            int height = pictureBox1.Height / 10;
            if (index != 0)
            {
                if (Objet[index-1].GetCaract()=="Enter") //|| index %element==0)
                {
                    pt1 = new Point(2, Int32.Parse(Objet[index -1].GetY())+height);
                    pt2 = new Point(2, Int32.Parse(Objet[index -1].GetY()) + 15+ height);                    
                }
                else if(Objet[index-1].GetType().Name == "caractère")
                {
                    pt1 = new Point(Int32.Parse(Objet[index - 1].GetX()) + width + 5, Int32.Parse(Objet[index - 1].GetY()));
                    pt2 = new Point(Int32.Parse(Objet[index - 1].GetX()) + width + 5, Int32.Parse(Objet[index - 1].GetY()) + 15);                  
                }
                else
                {
                    pt1 = new Point(Int32.Parse(Objet[index - 1].GetX()) + 2*(width + 5), Int32.Parse(Objet[index - 1].GetY()));
                    pt2 = new Point(Int32.Parse(Objet[index - 1].GetX()) + 2*(width + 5), Int32.Parse(Objet[index - 1].GetY()) + 15);
                }
            }           
            else
            {
                pt1 = new Point(2, 2);
                pt2 = new Point(2, 2 + 15);                
            }
            graphics.DrawLine(pen, pt1, pt2);
            pictureBox1.Invalidate();
        }
        private void button1_Click(object sender, EventArgs e)
        {            
            graphics.Clear(Color.White);
            Objet.Clear();            
            x = 2;
            y = 2;
            index = 0;
            DrawCursseur(0);
            pictureBox1.Invalidate();
        }
      
        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            int width = pictureBox1.Width / 80;
            int height = pictureBox1.Height / 10;
            float fontsize = (int)numericUpDown1.Value;
            Emote emot1 = new Emote(Properties.Resources.emot1, fontsize + 10, x, y);
            if (e.X < 47 && e.Y < 47)
            {
                Objet.Insert(index,emot1);
                index++;
                //element-=1;
                Position(width, height);
                DrawTout();
                DrawCursseur(width);
            }
            Emote emot2 = new Emote(Properties.Resources.emot2, fontsize + 10, x, y);
            if (e.X < 92 && e.Y < 47 && e.X > 47)
            {
                Objet.Insert(index,emot2);
                index++;
                //element--;
                Position(width, height);
                DrawTout();
                DrawCursseur(width);
            }
            Emote emot3 = new Emote(Properties.Resources.emot3, fontsize + 10, x, y);
            if (e.X > 92 && e.Y < 47 && e.X < 137)
            {
                Objet.Insert(index, emot3);
                index++;
                //element--;
                Position(width, height);
                DrawTout();
                DrawCursseur(width);
            }
            Emote emot4 = new Emote(Properties.Resources.emot4, fontsize + 10, x, y);
            if (e.X < 47 && e.Y > 47 && e.Y < 92)
            {
                Objet.Insert(index, emot4);
                index++;
                //element--;
                Position(width, height);
                DrawTout();
                DrawCursseur(width);
            }
            Emote emot5 = new Emote(Properties.Resources.emot5, fontsize + 10, x, y);
            if (e.X < 92 && e.Y > 47 && e.Y < 92 && e.X > 47)
            {
                Objet.Insert(index, emot5);
                index++;
                //element--;
                Position(width, height);
                DrawTout();
                DrawCursseur(width);
            }
            Emote emot6 = new Emote(Properties.Resources.emot6, fontsize + 10, x, y);
            if (e.X > 92 && e.Y > 47 && e.Y < 92 && e.X < 137)
            {
                Objet.Insert(index, emot6);
                index++;
                //element--;
                Position(width, height);
                DrawTout();
                DrawCursseur(width);
            }
        }

        public void Position(int width,int height)
        {
            x = 2;
            y = 2;
            foreach (Shape objet in Objet)
            {
                objet.SetX(x);
                objet.SetY(y);
                if (objet.GetType().Name == "Emote")
                {
                    x += 2*(width + 5);
                    Console.WriteLine("Lol");
                }
                else
                {                    
                    x += width + 5;
                    Console.WriteLine("Non");
                }   
                if (objet.GetCaract() == "Enter" || x>=width*79)
                {
                    x = 2;
                    y += height;
                    //element = 51;
                }
            }
        }
    }   
}