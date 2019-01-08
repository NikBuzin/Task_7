using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Drawing;

namespace DrawGraph
{
    public class Indicator
    {
        public List<Candle> candles;
        public List<double> Up;
        public List<double> Down;
        public int _period = 1;
        private Size size;
        public Indicator(List<Candle> list, double width, double height)
        {
            candles = list;
            size = new Size((int)width, (int)height);
            Up = new List<double>();
            Down = new List<double>();
        }
        public Bitmap Calculate()
        {
            Bitmap bmp = new Bitmap(size.Width, size.Height);
            DrawAxes(bmp);            
            for (var i = _period; i < candles.Count; i++)
            {
                Up.Add(CalculateAroonUp(i));
                Down.Add(CalculateAroonDown(i));
                _period++;
            }
            DrawLines(bmp);
            return bmp;
        }
        private Bitmap DrawLines(Bitmap bmp)
        {
            Graphics g = Graphics.FromImage(bmp);
            for (int i = 0; i < candles.Count-2; i++)
            {
                g.DrawLine(Pens.Green, i, (float)(bmp.Height / 2 + Up[i]), i+1, (float)(bmp.Height / 2 + Up[i + 1]));
                g.DrawLine(Pens.Red, i, (float)(bmp.Height / 2 + Down[i]), i + 1, (float)(bmp.Height / 2 + Down[i + 1]));
            }
            g.Dispose();
            return bmp;
        }
        private double CalculateAroonUp(int i)
        {
            var maxIndex = FindMax(i - _period, i);

            var up = CalcAroon(i - maxIndex);

            return up;
        }

        private double CalculateAroonDown(int i)
        {
            var minIndex = FindMin(i - _period, i);

            var down = CalcAroon(i - minIndex);

            return down;
        }
        private double CalcAroon(int numOfDays)
        {
            var result = ((_period - numOfDays)) * ((double)100 / _period);
            return result;
        }

        private int FindMin(int startIndex, int endIndex)
        {
            var min = double.MaxValue;
            var index = startIndex;
            for (var i = startIndex; i <= endIndex; i++)
            {
                if (min < (double)candles[i].Low)
                    continue;

                min = (double)candles[i].Low;
                index = i;
            }
            return index;
        }

        private int FindMax(int startIndex, int endIndex)
        {
            var max = double.MinValue;
            var index = startIndex;
            for (var i = startIndex; i <= endIndex; i++)
            {
                if (max > (double)candles[i].High)
                    continue;

                max = (double)candles[i].High;
                index = i;
            }
            return index;
        }                

        public Bitmap DrawAxes(Bitmap bmp)
        {
            Graphics g = Graphics.FromImage(bmp);
            g.DrawLine(Pens.Black, 0, bmp.Height / 2, bmp.Width, bmp.Height / 2);
            g.DrawLine(Pens.Black, 0, 0, 0, bmp.Height);
            g.Dispose();
            return bmp;
        }
    }
}