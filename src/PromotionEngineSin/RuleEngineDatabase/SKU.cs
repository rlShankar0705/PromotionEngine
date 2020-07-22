using System.Collections.Generic;

namespace RuleEngineDatabase
{
    public class SKU
    {
        public string SKUId { get; set; }
        public long AmountPerUnit { get; set; }

        public IEnumerable<SKU> GETUnitPriceForSKUID()
        {
            List<SKU> items = new List<SKU>();
            items.Add(new SKU() { SKUId = "A", AmountPerUnit = 50 });
            items.Add(new SKU() { SKUId = "B", AmountPerUnit = 30 });
            items.Add(new SKU() { SKUId = "C", AmountPerUnit = 20 });
            items.Add(new SKU() { SKUId = "D", AmountPerUnit = 15 });

            return items;
        }
    }
}
