using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEnginePattern
{
    public interface IDiscountCalculator
    {
        long CalculateDiscountPercentage(string skuId);
    }
}
