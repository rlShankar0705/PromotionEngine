using RuleEngineDatabase;
using System;

namespace RuleEnginePattern
{
    public class DiscountCalculator : IDiscountCalculator
    {
        public long CalculateDiscountPercentage(string skuId)
        {
            var activePromotion = new ActivePromotion();
            var listOfActivePromotion = activePromotion.GetActivePromotion();


            return 0;
        }
    }
}
