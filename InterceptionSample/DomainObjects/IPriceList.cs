namespace InterceptionSample.DomainObjects
{
    public interface IPriceList
    {
        void Lookup(StockKeepingUnit item, ProductScanner productScanner);
    }
}