using System.Collections.Generic;

namespace RuleEngineDatabase
{
    public class ActivePromotion
    {
        public string SKUId { get; set; }
        public int DiscountOnUnitCount { get; set; }

        public bool IsCombinationDiscount { get; set; }
        public string CombinationSKUID { get; set; }

        public int IsAppliedPromotionCountForSKUId { get; set; }

        public IEnumerable<ActivePromotion> GetActivePromotion()
        {
            List<ActivePromotion> items = new List<ActivePromotion>();
            items.Add(new ActivePromotion()
            {
                SKUId = "A",
                DiscountOnUnitCount = 3,
                IsCombinationDiscount = false,
                CombinationSKUID = null,
                IsAppliedPromotionCountForSKUId = 1
            });
            items.Add(new ActivePromotion()
            {
                SKUId = "B",
                DiscountOnUnitCount = 2,
                IsCombinationDiscount = false,
                CombinationSKUID = null,
                IsAppliedPromotionCountForSKUId = 1
            });
            items.Add(new ActivePromotion()
            {
                SKUId = "C",
                DiscountOnUnitCount = 0,
                IsCombinationDiscount = true,
                CombinationSKUID = "C,D",
                IsAppliedPromotionCountForSKUId = 1
            });
            items.Add(new ActivePromotion()
            {
                SKUId = "A",
                DiscountOnUnitCount = 0,
                IsCombinationDiscount = true,
                CombinationSKUID = "D,C",
                IsAppliedPromotionCountForSKUId = 1
            });

            return items;
        }
    }
}
