using System.Collections.Generic;

namespace InterceptionSample.DomainObjects
{
    public class StockKeepingUnit : IEqualityComparer<StockKeepingUnit>
    {
        private readonly char id;

        public StockKeepingUnit(char id)
        {
            this.id = id;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as StockKeepingUnit);
        }

        public bool Equals(StockKeepingUnit obj)
        {
            return Equals(this, obj);
        }

        public bool Equals(StockKeepingUnit x, StockKeepingUnit y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x == null && y == null)
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            return x.id == y.id;
        }

        public int GetHashCode(StockKeepingUnit obj)
        {
            return obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }
    }
}
