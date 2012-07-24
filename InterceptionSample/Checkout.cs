using System;
using System.Linq;

namespace InterceptionSample
{
    public class Checkout : ICheckout
    {
        private readonly IStockRoom stockRoom;

        public Checkout(IStockRoom stockRoom)
        {
            if (stockRoom == null)
            {
                throw new ArgumentNullException("stockRoom");
            }

            this.stockRoom = stockRoom;
        }

        public int GetTotal(string skus)
        {
            return skus.Sum(sku => ScanItem(sku));
        }

        private int ScanItem(char sku)
        {
            return stockRoom.GetPriceForItem(sku);
        }
    }
}