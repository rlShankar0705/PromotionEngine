using RuleEngineDatabase;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RuleEnginePattern
{
    public class DiscountCalculator : IDiscountCalculator
    {
        public long CalculateDiscountPercentage(string skuIds)
        {
            long totalPrice = 0;
            skuIds = new String(skuIds.Where(c => char.IsLetter(c)).ToArray());
            var skuIdCounts = skuIds.ToUpper().GroupBy(c => c)
                     .OrderBy(c => c.Key)
                     .ToDictionary(grp => grp.Key, grp => grp.Count());
            var activePromotion = new ActivePromotion();
            var listOfActivePromotion = activePromotion.GetActivePromotion();

            foreach (var item in skuIdCounts)
            {
                var skuId = item.Key.ToString();
                var discountOnUnitCount = item.Value;
                var selectedSKUId = listOfActivePromotion
                                    .Where(x => x.SKUId.Equals(skuId, StringComparison.InvariantCultureIgnoreCase))
                                    .FirstOrDefault();

                if (selectedSKUId.SKUId.Equals(skuId, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (discountOnUnitCount >= selectedSKUId.DiscountOnUnitCount
                     && selectedSKUId.IsCombinationDiscount == false)
                    {
                        if (selectedSKUId.DiscountOnUnitCount == discountOnUnitCount)
                        {
                            totalPrice = totalPrice + selectedSKUId.DiscountUnitPrice;
                        }
                        else
                        {
                            if (discountOnUnitCount > selectedSKUId.DiscountOnUnitCount)
                            {
                                totalPrice = totalPrice + selectedSKUId.DiscountUnitPrice;
                            }
                            else
                            {
                                var sku = new SKU();
                                var skuIdItem = sku.GETUnitPriceForSKUID()
                                    .Where(x => x.SKUId.Equals(skuId, StringComparison.InvariantCultureIgnoreCase))
                                    .FirstOrDefault();

                                totalPrice = totalPrice + (skuIdItem.AmountPerUnit * discountOnUnitCount);
                            }
                        }
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }

            return totalPrice;
        }
    }
}


________________________________________

*** CONFIDENTIALITY NOTICE : This electronic transmission and any documents or other writings sent with it constitute confidential information, which is intended only for the named recipient.If you are not the intended recipient, please reply to the sender that you have received the message in error and delete it.Any disclosure, copying, distribution or the taking of any action concerning the contents of this communication or any attachment(s) by anyone other than the intended recipient is strictly prohibited. ***
