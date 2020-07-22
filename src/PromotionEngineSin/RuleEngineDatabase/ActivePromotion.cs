using System.Collections.Generic;

namespace RuleEngineDatabase
{
    public class ActivePromotion
    {
        public string SKUId { get; set; }
        public int DiscountOnUnitCount { get; set; }
        public long DiscountUnitPrice { get; set; }

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
                DiscountUnitPrice = 130,
                IsCombinationDiscount = false,
                CombinationSKUID = null,
                IsAppliedPromotionCountForSKUId = 1
            });
            items.Add(new ActivePromotion()
            {
                SKUId = "B",
                DiscountOnUnitCount = 2,
                DiscountUnitPrice = 45,
                IsCombinationDiscount = false,
                CombinationSKUID = null,
                IsAppliedPromotionCountForSKUId = 1
            });
            items.Add(new ActivePromotion()
            {
                SKUId = "C",
                DiscountOnUnitCount = 0,
                DiscountUnitPrice = 30,
                IsCombinationDiscount = true,
                CombinationSKUID = "C,D",
                IsAppliedPromotionCountForSKUId = 1
            });
            items.Add(new ActivePromotion()
            {
                SKUId = "D",
                DiscountOnUnitCount = 0,
                DiscountUnitPrice = 30,
                IsCombinationDiscount = true,
                CombinationSKUID = "D,C",
                IsAppliedPromotionCountForSKUId = 1
            });

            return items;
        }
    }
}


________________________________________

*** CONFIDENTIALITY NOTICE : This electronic transmission and any documents or other writings sent with it constitute confidential information, which is intended only for the named recipient.If you are not the intended recipient, please reply to the sender that you have received the message in error and delete it.Any disclosure, copying, distribution or the taking of any action concerning the contents of this communication or any attachment(s) by anyone other than the intended recipient is strictly prohibited. ***
