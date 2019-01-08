using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Model;

namespace DrawGraph
{
    public class Drawer
    {
        public List<Candle> candles;
        private Size size;
        public Drawer(List<Candle> candles, double width, double height)
        {
            this.candles = candles;
            size = new Size((int)width,(int)height);
        }

        public Bitmap DrawOne(int count)
        {
            Bitmap bmp = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(bmp);
            bmp = DrawAxes(bmp);
            Bitmap tmp = new Bitmap(size.Width, size.Height);
            for (int i = 0; i < count; i++)
            {
                bmp = DrawCandle(bmp, candles[i], i);
            }
            g.Dispose();
            return bmp;
        }

        public Bitmap DrawCandle(Bitmap bmp, Candle candle, int place)
        {
            Graphics g = Graphics.FromImage(bmp);
            Candle cndl = candle;
            cndl.Open -= 100000;
            cndl.Close -= 100000;
            cndl.Low -= 100000;
            cndl.High -= 100000;
            cndl.Open /= 10;
            cndl.Close /= 10;
            cndl.Low /= 10;
            cndl.High /= 10;
            cndl.Open -= 550;
            cndl.Close -=550;
            cndl.Low -= 550;
            cndl.High -= 550;
            
            if (cndl.Close> cndl.Open) 
            {
                g.FillRectangle(Brushes.Green, 10 * place, (float)cndl.Open, 8, (float)cndl.Close - (float)cndl.Open);
                g.DrawLine(Pens.Black, 10 * place + 4, (float)cndl.Close , 10 * place + 4,(float)cndl.High);
                g.DrawLine(Pens.Black, 10 * place + 4, (float)cndl.Open, 10 * place + 4, (float)cndl.Low);
            }
            else if(cndl.Close < cndl.Open)
            {
                g.FillRectangle(Brushes.Red, 10 * place, (float)cndl.Close , 8, -(float)cndl.Close  + (float)cndl.Open);
                g.DrawLine(Pens.Black, 10 * place + 4, (float)cndl.Open , 10 * place + 4, (float)cndl.High);
                g.DrawLine(Pens.Black, 10 * place + 4, (float)cndl.Close, 10 * place + 4, (float)cndl.Low);
            }
            else if (cndl.Close == cndl.Open)
            {
                g.DrawLine(Pens.Black, 10 * place, (float)cndl.Open, 10 * place + 8, (float)cndl.Open);
                g.DrawLine(Pens.Black, 10 * place + 4, (float)cndl.Open, 10 * place + 4, (float)cndl.High);
                g.DrawLine(Pens.Black, 10 * place + 4, (float)cndl.Open, 10 * place + 4, (float)cndl.Low);
            }
            g.Dispose();
            return bmp;
        }

        public Bitmap DrawAxes(Bitmap bmp)
        {
            Graphics g = Graphics.FromImage(bmp);
            g.DrawLine(Pens.Black, 0, bmp.Height / 2, bmp.Width, bmp.Height/2);
            g.DrawLine(Pens.Black,0,0,0,bmp.Height);
            g.Dispose();
            return bmp;
        }
    }
}
