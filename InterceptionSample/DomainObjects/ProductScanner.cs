using System;

namespace InterceptionSample.DomainObjects
{
    public class ProductScanner : IProductScanner
    {
        private readonly IPriceList priceList;

        public ProductScanner(IPriceList priceList)
        {
            if (priceList == null)
            {
                throw new ArgumentNullException("priceList");
            }

            this.priceList = priceList;
        }

        public void Scan(StockKeepingUnit item)
        {
            priceList.Lookup(item, this);
        }
    }
}