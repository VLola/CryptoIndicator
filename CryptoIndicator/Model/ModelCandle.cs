using CryptoIndicator.Objects;
using System.Data.Entity;

namespace CryptoIndicator.Model
{
    public class ModelCandle : DbContext
    {
        public ModelCandle()
            : base("name=ModelCandle")
        {
        }
        public virtual DbSet<Candle> Candles { get; set; }
    }
}