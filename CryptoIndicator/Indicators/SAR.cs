using CryptoIndicator.Objects;
using ScottPlot;
using ScottPlot.Plottable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CryptoIndicator.Indicators
{
    public class SAR
    {
        List<SarInfo> SarLong = new List<SarInfo>();
        List<SarInfo> SarShort = new List<SarInfo>();
        public (List<SarInfo>, List<SarInfo>) Calculate(List<OHLC> OhlcList)
        {
            int start = 0;
            bool position = false;
            while (true)
            {
                (int i, bool check, bool isLong) = Add(OhlcList, start, position);
                if (check)
                {
                    start = i;
                    position = isLong;
                }
                else
                {
                    break;
                }
            }
            return (SarLong, SarShort);
        }
        private (int, bool, bool) Add(List<OHLC> OhlcList, int select, bool isLong)
        {
            if (isLong)
            {
                SarLong.Add(new SarInfo()
                {
                    X = OhlcList[select].DateTime.ToOADate(),
                    Y = OhlcList[select].High,
                    High = OhlcList[select].High,
                    Low = OhlcList[select].Low
                });
            }
            else
            {
                SarShort.Add(new SarInfo()
                {
                    X = OhlcList[select].DateTime.ToOADate(),
                    Y = OhlcList[select].Low,
                    High = OhlcList[select].High,
                    Low = OhlcList[select].Low
                });
            }
            int k = 0;

            for (int i = select + 1; i < OhlcList.Count - 1; i++)
            {
                k++;
                SarInfo sarInfo = new SarInfo()
                {
                    X = OhlcList[i].DateTime.ToOADate(),
                    High = OhlcList[i].High,
                    Low = OhlcList[i].Low
                };
                if (isLong)
                {
                    double oldY = SarLong[SarLong.Count - 1].Y;
                    if (OhlcList[i].High > oldY)
                    {
                        return (i, true, false);
                    }
                    double oldHigh = SarLong[SarLong.Count - 1].High;
                    double acceleration = 0.02 + (k * 0.02);
                    double newY = (((oldHigh - oldY) * acceleration) + oldY);
                    sarInfo.Y = newY;
                    SarLong.Add(sarInfo);
                }
                else
                {
                    double oldY = SarShort[SarShort.Count - 1].Y;
                    if (OhlcList[i].Low < oldY)
                    {
                        return (i, true, true);
                    }
                    double oldLow = SarShort[SarShort.Count - 1].Low;
                    double acceleration = 0.02 + (k * 0.02);
                    double newY = (((oldLow - oldY) * acceleration) + oldY);
                    sarInfo.Y = newY;
                    SarShort.Add(sarInfo);
                }
            }
            return (0, false, false);
        }
        public class SarInfo
        {
            public double Y { get; set; }
            public double X { get; set; }
            public double Low { get; set; } 
            public double High { get; set; } 
        }
    }
}
