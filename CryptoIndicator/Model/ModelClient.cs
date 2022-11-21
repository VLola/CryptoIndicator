using CryptoIndicator.Binance;
using System;
using System.Data.Entity;
using System.Linq;

namespace CryptoIndicator.Model
{
    public class ModelClient : DbContext
    {
        public ModelClient()
            : base("name=ModelClient")
        {
        }
        public virtual DbSet<Client> Clients { get; set; }
    }

}