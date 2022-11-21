using Binance.Net.Enums;

namespace CryptoIndicator.Interval
{
    public class Interval
    {
        public string name { get; set; }
        public KlineInterval interval { get; set; }
        public long timespan { get; set; }
        public override string ToString()
        {
            return name;
        }
    }
}
