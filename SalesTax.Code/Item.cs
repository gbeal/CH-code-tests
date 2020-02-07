namespace SalesTax.Code
{
    public class Item
    {
        private ItemType _itemType;
        private string _name;
        public bool IsImported { get; set; }
        public bool IsTaxable { get; private set; }
        public double UnitPrice { get; set; }

        //Accept a product name.  If it contains the word "imported", set the IsImported flag
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                if (_name.ToLower().Contains("imported"))
                {
                    IsImported = true;
                }
            }
        }

        //if the ItemType is Other, then set the IsTaxable flag
        public ItemType ItemType
        {
            get
            {
                return _itemType;
            }
            set
            {
                _itemType = value;
                if (_itemType == ItemType.Other)
                {
                    IsTaxable = true;
                }
                else
                {
                    IsTaxable = false;
                }
            }
        }
    }
}