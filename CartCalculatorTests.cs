using NUnit.Framework;
using ShoppingCart;
using System.Collections.Generic;

namespace ShoppingCartTest
{
    public class Tests
    {
        private CartCalculator testCalculator;
        [SetUp]
        public void Setup()
        {
            testCalculator = new CartCalculator();
        }

        [Test]
        public void NoItemsAddedToCart()
        {
            var emptyCart = new List<string>();
            var result = testCalculator.Calculate(emptyCart);
            Assert.That(result.TotalFruitPrice, Is.EqualTo(0));
            Assert.That(result.ErrorMessage, Is.EqualTo("Please add an item to your cart"));
        }

        [Test]
        public void IncorrectItemsAddedToCart()
        {
            var cart = new List<string>() {"Pears","Melons"};
            var result = testCalculator.Calculate(cart);
            Assert.That(result.TotalFruitPrice, Is.EqualTo(0));
            Assert.That(result.ErrorMessage, Is.EqualTo("You can only purchase oranges and apples from Andy's Fruit Cart"));
        }

        [Test]
        public void CorrectCalculationForAnOrangeAndAnApple()
        {
            var cart = new List<string>() { "Oranges", "Apples" };
            var result = testCalculator.Calculate(cart);
            Assert.That(result.TotalFruitPrice, Is.EqualTo(0.85));
            Assert.That(result.ErrorMessage, Is.EqualTo(string.Empty));
        }

        [Test]
        public void CorrectCalculationForMultipleApplesAndOranges()
        {
            var cart = new List<string>() { "Apples", "Apples", "Oranges", "Apples"};
            var result = testCalculator.Calculate(cart);
            Assert.That(result.TotalFruitPrice, Is.EqualTo(1.45));
            Assert.That(result.ErrorMessage, Is.EqualTo(string.Empty));
        }

        [Test]
        public void CorrectCalculationForApplesAndOrangesAndRogueFruit()
        {
            var cart = new List<string>() { "Apples", "Apples", "Oranges", "Melons"};
            var result = testCalculator.Calculate(cart);
            Assert.That(result.TotalFruitPrice, Is.EqualTo(0.85));
            Assert.That(result.ErrorMessage, Is.EqualTo("You have tried to purchase Melons. You can only purchase oranges and apples from Andy's Fruit Cart"));
        }

        [Test]
        public void CorrectCalculationForApplesWithTwoForOneDiscount()
        {
            var cart = new List<string>() { "Apples", "Apples"};
            var result = testCalculator.Calculate(cart);
            Assert.That(result.TotalFruitPrice, Is.EqualTo(.60));
            Assert.That(result.ErrorMessage, Is.EqualTo(string.Empty));
        }

        [Test]
        public void CorrectCalculationForOrangesWithThreeForTwoDiscount()
        {
            var cart = new List<string>() { "Oranges", "Oranges", "Oranges" };
            var result = testCalculator.Calculate(cart);
            Assert.That(result.TotalFruitPrice, Is.EqualTo(.50));
            Assert.That(result.ErrorMessage, Is.EqualTo(string.Empty));
        }

        [Test]
        public void CorrectCalculationForOrangesAndApplesDiscount()
        {
            var cart = new List<string>() { "Oranges", "Oranges", "Oranges", "Apples", "Apples" };
            var result = testCalculator.Calculate(cart);
            Assert.That(result.TotalFruitPrice, Is.EqualTo(1.10));
            Assert.That(result.ErrorMessage, Is.EqualTo(string.Empty));
        }

        [Test]
        public void CorrectCalculationForFourOranges()
        {
            var cart = new List<string>() { "Oranges", "Oranges", "Oranges", "Oranges" };
            var result = testCalculator.Calculate(cart);
            Assert.That(result.TotalFruitPrice, Is.EqualTo(.75));
            Assert.That(result.ErrorMessage, Is.EqualTo(string.Empty));
        }

        [Test]
        public void CorrectCalculationForFiveOranges()
        {
            var cart = new List<string>() { "Oranges", "Oranges", "Oranges", "Oranges", "Oranges" };
            var result = testCalculator.Calculate(cart);
            Assert.That(result.TotalFruitPrice, Is.EqualTo(1.00));
            Assert.That(result.ErrorMessage, Is.EqualTo(string.Empty));
        }

        [Test]
        public void CorrectCalculationForSixOranges()
        {
            var cart = new List<string>() { "Oranges", "Oranges", "Oranges", "Oranges", "Oranges", "Oranges"};
            var result = testCalculator.Calculate(cart);
            Assert.That(result.TotalFruitPrice, Is.EqualTo(1.00));
            Assert.That(result.ErrorMessage, Is.EqualTo(string.Empty));
        }

    }
}