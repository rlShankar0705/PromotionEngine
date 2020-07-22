using System.Collections.Generic;

namespace RuleEngineDatabase
{
    public class ActivePromotion
    {
        public string SKUId { get; set; }
        public int DiscountOnUnitCount { get; set; }
        public long DiscountUnitPrice { get; set; }

        public bool IsCombinationDiscount { get; set; }
        public string CombinationSKUIds { get; set; }

        public int IsAppliedPromotionCountForSKUId { get; set; }

        public IEnumerable<ActivePromotion> GetActivePromotion()
        {
            List<ActivePromotion> items = new List<ActivePromotion>();
            items.Add(new ActivePromotion()
            {
                SKUId = "A",
                DiscountOnUnitCount = 3,
                DiscountUnitPrice = 130,
                IsCombinationDiscount = false,
                CombinationSKUIds = null,
                IsAppliedPromotionCountForSKUId = 1
            });
            items.Add(new ActivePromotion()
            {
                SKUId = "B",
                DiscountOnUnitCount = 2,
                DiscountUnitPrice = 45,
                IsCombinationDiscount = false,
                CombinationSKUIds = null,
                IsAppliedPromotionCountForSKUId = 1
            });
            items.Add(new ActivePromotion()
            {
                SKUId = "C",
                DiscountOnUnitCount = 0,
                DiscountUnitPrice = 30,
                IsCombinationDiscount = true,
                CombinationSKUIds = "C,D",
                IsAppliedPromotionCountForSKUId = 1
            });
            items.Add(new ActivePromotion()
            {
                SKUId = "D",
                DiscountOnUnitCount = 0,
                DiscountUnitPrice = 30,
                IsCombinationDiscount = true,
                CombinationSKUIds = "D,C",
                IsAppliedPromotionCountForSKUId = 1
            });

            return items;
        }
    }
}


