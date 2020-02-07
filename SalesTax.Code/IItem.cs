namespace SalesTax.Code
{
    public interface IItem
    {
        bool IsImported { get; }
        bool IsTaxable { get; }
        double UnitPrice { get; set; }
        string Name { get; set; }

    }


}