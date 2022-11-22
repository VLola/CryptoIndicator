using Binance.Net.Objects.Models.Futures;
using CryptoIndicator.Model;
using System.Collections.Generic;
using System.Linq;

namespace CryptoIndicator.ConnectDB
{
    public static class ConnectOrder
    {
        public static void Insert(BinanceFuturesOrder order)
        {
            ModelBinanceFuturesOrder modelBinanceFuturesOrder = new ModelBinanceFuturesOrder();
            modelBinanceFuturesOrder.BinanceFuturesOrders.Add(order);
            modelBinanceFuturesOrder.SaveChanges();
        }
        public static List<BinanceFuturesOrder> Get()
        {
            ModelBinanceFuturesOrder modelBinanceFuturesOrder = new ModelBinanceFuturesOrder();
            return modelBinanceFuturesOrder.BinanceFuturesOrders.ToList();
        }
        public static void DeleteAll()
        {
            ModelBinanceFuturesOrder modelBinanceFuturesOrder = new ModelBinanceFuturesOrder();
            modelBinanceFuturesOrder.BinanceFuturesOrders.RemoveRange(modelBinanceFuturesOrder.BinanceFuturesOrders.ToList());
            modelBinanceFuturesOrder.SaveChanges();
        }
    }
}
