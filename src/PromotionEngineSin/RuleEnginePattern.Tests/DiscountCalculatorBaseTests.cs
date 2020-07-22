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
        public void S1()
        {
            string skuId = "A,B,C";

            long activePromotionDiscount = _calculator.CalculateDiscountPercentage(skuId);

            Assert.AreEqual(100, activePromotionDiscount);
        }

        [Test]
        public void S2()
        {
            string skuId = "A,A,A,A,A,B,B,B,B,B,C";

            long activePromotionDiscount = _calculator.CalculateDiscountPercentage(skuId);

            Assert.AreEqual(370, activePromotionDiscount);
        }

        [Test]
        public void S3()
        {
            string skuId = "A,A,A,,B,B,B,B,B,C,D";

            long activePromotionDiscount = _calculator.CalculateDiscountPercentage(skuId);

            Assert.AreEqual(280, activePromotionDiscount);
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
        public void CombineA3B2()
        {
            string skuId = "A,A,A,B,B";

            long activePromotionDiscount = _calculator.CalculateDiscountPercentage(skuId);

            Assert.AreEqual(175, activePromotionDiscount);
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