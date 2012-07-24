using System.Collections.Generic;

namespace InterceptionSample
{
    public class StockRoom : IStockRoom
    {
        private readonly Dictionary<char, int> prices;

        public StockRoom()
        {
            prices = new Dictionary<char, int>
            {
                {'A', 50},
                {'B', 30},
                {'C', 20},
                {'D', 15}
            };
        }

        public int GetPriceForItem(char sku)
        {
            int itemPrice;
            if (prices.TryGetValue(sku, out itemPrice))
            {
                return itemPrice;
            }

            return itemPrice;
        }
    }
}