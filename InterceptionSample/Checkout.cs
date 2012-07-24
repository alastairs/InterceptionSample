using System.Collections.Generic;
using System.Linq;

namespace InterceptionSample
{
    public class Checkout
    {
        private readonly IDictionary<char, int> prices;

        public Checkout()
        {
            prices = new Dictionary<char, int>
            {
                {'A', 50},
                {'B', 30},
                {'C', 20},
                {'D', 15}
            };
        }

        public int GetTotal(string skus)
        {
            return skus.Sum(sku => ScanItem(sku));
        }

        private int ScanItem(char sku)
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