using CryptoIndicator.Model;
using CryptoIndicator.Objects;
using System.Collections.Generic;
using System.Linq;

namespace CryptoIndicator.ConnectDB
{
    public static class ConnectHistoryOrder
    {
        public static void Insert(HistoryOrder order)
        {
            ModelHistoryOrder modelHistoryOrder = new ModelHistoryOrder();
            modelHistoryOrder.HistoryOrders.Add(order);
            modelHistoryOrder.SaveChanges();
        }
        public static List<HistoryOrder> Get()
        {
            ModelHistoryOrder modelHistoryOrder = new ModelHistoryOrder();
            return modelHistoryOrder.HistoryOrders.ToList();
        }
        public static void DeleteAll()
        {
            ModelHistoryOrder modelHistoryOrder = new ModelHistoryOrder();
            modelHistoryOrder.HistoryOrders.RemoveRange(modelHistoryOrder.HistoryOrders.ToList());
            modelHistoryOrder.SaveChanges();
        }
    }
}
