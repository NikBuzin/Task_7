using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Candle
   {
        public long TimeStamp { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Open { get; set; }
        public decimal Close { get; set; }
        public DateTime Time { get; set; }
        public Candle(decimal high, decimal low, decimal open, decimal close, DateTime time)
        {
            High = high;
            Low = low;
            Open = open;
            Close = close;
            Time = time;
        }
        public Candle(long timeStamp, decimal high, decimal low, decimal open, decimal close)
        {
            TimeStamp = timeStamp;
            High = high;
            Low = low;
            Open = open;
            Close = close;
            Time = new DateTime(1970, 1, 1).AddSeconds(timeStamp);
        }
   }
}
