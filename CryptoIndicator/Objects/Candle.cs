using System;
using System.ComponentModel.DataAnnotations;

namespace CryptoIndicator.Objects
{
    public class Candle
    {
        [Key]
        public DateTime DateTime { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public long TimeSpan { get; set; }
    }
}
