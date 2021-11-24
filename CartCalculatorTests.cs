using NUnit.Framework;
using ShoppingCart;
using System;
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
            var emptyCart = new List<string>() {"Pears","Melons"};
            var result = testCalculator.Calculate(emptyCart);
            Assert.That(result.TotalFruitPrice, Is.EqualTo(0));
            Assert.That(result.ErrorMessage, Is.EqualTo("You have selected Pears. You can only purchase oranges and apples from Andy's Fruit Cart"));
        }

        [Test]
        public void CorrectCalculationForAnOrangeAndAnApple()
        {
            var emptyCart = new List<string>() { "Oranges", "Apples" };
            var result = testCalculator.Calculate(emptyCart);
            Assert.That(result.TotalFruitPrice, Is.EqualTo(0.85));
            Assert.That(result.ErrorMessage, Is.EqualTo(string.Empty));
        }

        [Test]
        public void CorrectCalculationForMultipleApplesAndOranges()
        {
            var emptyCart = new List<string>() { "Apples", "Apples", "Oranges", "Apples"};
            var result = testCalculator.Calculate(emptyCart);
            Assert.That(result.TotalFruitPrice, Is.EqualTo(2.05));
            Assert.That(result.ErrorMessage, Is.EqualTo(string.Empty));
        }

        [Test]
        public void CorrectCalculationForApplesAndOrangesAndRogueFruit()
        {
            var emptyCart = new List<string>() { "Apples", "Apples", "Oranges", "Melons"};
            var result = testCalculator.Calculate(emptyCart);
            Assert.That(result.TotalFruitPrice, Is.EqualTo(1.45));
            Assert.That(result.ErrorMessage, Is.EqualTo("You have selected Melons. You can only purchase oranges and apples from Andy's Fruit Cart"));
        }
    }
}