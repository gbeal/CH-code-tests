namespace SalesTax.Code
{
    public abstract class AbstractTaxableItem : IItem
    {

        public virtual bool IsTaxable
        {
            get { return true; }
        }
        public virtual bool IsImported { get; set; }
        public abstract double UnitPrice { get; set; }
        public abstract string Name { get; set; }
    }
}