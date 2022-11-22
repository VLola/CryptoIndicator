using CryptoIndicator.Model;
using CryptoIndicator.Objects;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace CryptoIndicator.ConnectDB
{
    public static class ConnectCandle
    {
        public static void Insert(Candle candle)
        {
            ModelCandle modelCandle = new ModelCandle();
            modelCandle.Candles.Add(candle);
            modelCandle.SaveChanges();
        }
        public static void InsertRange(List<Candle> candles)
        {
            ModelCandle modelCandle = new ModelCandle();
            modelCandle.Candles.AddRange(candles);
            modelCandle.SaveChanges();
        }
        public static List<Candle> Get()
        {
            ModelCandle modelCandle = new ModelCandle();
            return modelCandle.Candles.ToList();
        }
        public static void DeleteAll()
        {
            ModelCandle modelCandle = new ModelCandle();
            modelCandle.Candles.RemoveRange(modelCandle.Candles.ToList());
            modelCandle.SaveChanges();
        }
        public static bool Update(Candle candle)
        {
            ModelCandle modelCandle = new ModelCandle();
            modelCandle.Candles.AddOrUpdate(candle);
            modelCandle.SaveChanges();
            return true;
        }
    }
}
