using RuleEngineDatabase;

namespace RuleEnginePattern
{
    public interface IDiscountCalculator
    {
        long CalculateDiscountPercentage(string skuId);
        SKU GetSelectedSKUId(string skuId);
    }
}
