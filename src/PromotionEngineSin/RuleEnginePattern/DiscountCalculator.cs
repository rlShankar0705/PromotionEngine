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
                    if (selectedSKUId.IsCombinationDiscount == false)
                    {
                        if (selectedSKUId.DiscountOnUnitCount == discountOnUnitCount)
                        {
                            totalPrice = totalPrice + selectedSKUId.DiscountUnitPrice;
                        }
                        else
                        {
                            var skuIdItem = this.GetSelectedSKUId(skuId);

                            if (discountOnUnitCount > selectedSKUId.DiscountOnUnitCount)
                            {
                                int v = discountOnUnitCount / selectedSKUId.DiscountOnUnitCount;
                                totalPrice = totalPrice + (v * selectedSKUId.DiscountUnitPrice);

                                if (discountOnUnitCount % selectedSKUId.DiscountOnUnitCount != 0)
                                {
                                    totalPrice = totalPrice + (skuIdItem.AmountPerUnit * (discountOnUnitCount % selectedSKUId.DiscountOnUnitCount));
                                }
                            }
                            else
                            {
                                totalPrice = totalPrice + (skuIdItem.AmountPerUnit * discountOnUnitCount);
                            }
                        }
                    }
                    else
                    {
                        var combinationSKUIds = selectedSKUId.CombinationSKUIds.Split(',');

                        var pre = skuIdCounts.Where(x => x.Key.ToString()
                                  .Equals(combinationSKUIds[combinationSKUIds.Count() - 1], StringComparison.InvariantCultureIgnoreCase))
                                  .FirstOrDefault();

                        if (pre.Value > 0)
                        {
                            totalPrice = totalPrice + selectedSKUId.DiscountUnitPrice;

                            var c1 = skuIdCounts.FirstOrDefault(x => x.Key.ToString() == skuId.ToString()).Value;

                            if (c1 > 1)
                            {
                                var skuIdItem = this.GetSelectedSKUId(skuId.ToString());
                                totalPrice = totalPrice + ((c1 - 1) * skuIdItem.AmountPerUnit);
                            }

                            var c2 = skuIdCounts.FirstOrDefault(x => x.Key.ToString() == pre.Key.ToString()).Value;

                            if (c2 > 1)
                            {
                                var skuIdItem = this.GetSelectedSKUId(pre.Key.ToString());
                                totalPrice = totalPrice + ((c2 - 1) * skuIdItem.AmountPerUnit);
                            }

                            break;
                        }
                        else
                        {
                            var skuIdItem = this.GetSelectedSKUId(skuId);
                            totalPrice = totalPrice + skuIdItem.AmountPerUnit;
                        }
                    }
                }
                else
                {

                }
            }

            return totalPrice;
        }

        public SKU GetSelectedSKUId(string skuId)
        {
            var sku = new SKU();
            return sku.GETUnitPriceForSKUID()
                 .Where(x => x.SKUId.Equals(skuId, StringComparison.InvariantCultureIgnoreCase))
                 .FirstOrDefault();
        }
    }
}