using NUnit.Framework;

namespace RuleEnginePattern.Tests
{
    [TestFixture]
    public abstract class DiscountCalculatorBaseTests<T>
       where T : IDiscountCalculator, new()
    {
        private IDiscountCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new T();
        }

        [Test]
        public void A3()
        {
            string skuId = "A,A,A";

            long activePromotionDiscount = _calculator.CalculateDiscountPercentage(skuId);

            Assert.AreEqual(130, activePromotionDiscount);
        }

        [Test]
        public void A2()
        {
            string skuId = "A,A";

            long activePromotionDiscount = _calculator.CalculateDiscountPercentage(skuId);

            Assert.AreEqual(100, activePromotionDiscount);
        }

        [Test]
        public void ReturnActivePromotionForSKUId_B()
        {
            string skuId = "B";

            long activePromotionDiscount = _calculator.CalculateDiscountPercentage(skuId);

            Assert.AreEqual(45, activePromotionDiscount);
        }

        [Test]
        public void ReturnActivePromotionForSKUId_C()
        {
            string skuId = "CD";

            long activePromotionDiscount = _calculator.CalculateDiscountPercentage(skuId);

            Assert.AreEqual(30, activePromotionDiscount);
        }

        [Test]
        public void ReturnActivePromotionForSKUId_D()
        {
            string skuId = "DC";

            long activePromotionDiscount = _calculator.CalculateDiscountPercentage(skuId);

            Assert.AreEqual(30, activePromotionDiscount);
        }
    }        
}