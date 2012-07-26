namespace InterceptionSample.DomainObjects
{
    public class Product
    {
        private readonly StockKeepingUnit id;

        public Product(StockKeepingUnit id)
        {
            this.id = id;
        }

        public void CheckoutWith(IProductScanner scanner)
        {
            scanner.Scan(id);
        }
    }
}