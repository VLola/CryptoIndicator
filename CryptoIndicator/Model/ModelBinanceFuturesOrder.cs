using Binance.Net.Objects.Models.Futures;
using System.Data.Entity;

namespace CryptoIndicator.Model
{
    public class ModelBinanceFuturesOrder : DbContext
    {
        public ModelBinanceFuturesOrder()
            : base("name=ModelBinanceFuturesOrder")
        {
        }
        public DbSet<BinanceFuturesOrder> BinanceFuturesOrders { get; set; }
    }
}