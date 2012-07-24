using System.Collections.Generic;

namespace InterceptionSample
{
    public class Checkout
    {
        private readonly IDictionary<string, int> prices;

        public Checkout()
        {
            prices = new Dictionary<string, int>
            {
                {"A", 50},
                {"B", 30},
                {"C", 20},
                {"D", 15}
            };
        }

        public int GetTotal(string skus)
        {
            int itemPrice;
            if (prices.TryGetValue(skus, out itemPrice))
            {
                return itemPrice;
            }

            return 0;
        }
    }
}