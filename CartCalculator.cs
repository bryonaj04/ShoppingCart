using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart
{
    public class CartCalculator
    {
        private readonly decimal CostOfOrange = 0.25M;
        private readonly decimal CostOfApple = 0.60M;

        private const string Oranges = "oranges";
        private const string Apples = "apples";

        private readonly List<string> AllowedFruits = new List<string> { "oranges", "apples" };

        int orangeCounter = 0;
        int appleCounter = 0;

        public CartCalculateRespnse Calculate(List<string> ListOfFruits)
        {
            var response = new CartCalculateRespnse()
            {
                TotalFruitPrice = 0M,
                ErrorMessage = string.Empty
            };

            var listOfFruitPrices = new List<decimal>();

            if (!ListOfFruits.Any())
            {
                response.ErrorMessage = "Please add an item to your cart";
                Console.WriteLine(response.ErrorMessage);
                return response;

            }

            foreach (var fruit in ListOfFruits)
            {
                if (AllowedFruits.Contains(fruit.ToLower()))
                {
                    if (fruit.ToLower() == Oranges)
                    {
                        listOfFruitPrices.Add(CostOfOrange);
                        orangeCounter++;
                    }

                    else if (fruit.ToLower() == Apples)
                    {
                        listOfFruitPrices.Add(CostOfApple);
                        appleCounter++;
                    }

                }
                else
                {
                    response.ErrorMessage = $"You have tried to purchase {fruit}. You can only purchase {string.Join(" and ", AllowedFruits)} from Andy's Fruit Cart";
                }
            }

            response.TotalFruitPrice = listOfFruitPrices.Sum();
            var cartDiscountResponse = new CartDiscountCalculator();

            if (appleCounter == 0 && orangeCounter == 0)
            {
                response.ErrorMessage = $"You can only purchase {string.Join(" and ", AllowedFruits)} from Andy's Fruit Cart";
                return response;
            }

            if (appleCounter >= 2)
            {
                if ((appleCounter % 2 == 0 && appleCounter != 0) || ((appleCounter - 1) % 2 == 0 && appleCounter != 0))
                {
                    var costOfApplesWithDiscount = cartDiscountResponse.CalculateDiscountManager(Apples, CostOfApple, appleCounter);
                    response.TotalFruitPrice = listOfFruitPrices.Sum() - costOfApplesWithDiscount;
                }

            }

            if (orangeCounter >= 3)
            {
                if ((orangeCounter % 3 == 0 && orangeCounter != 0) || ((orangeCounter - 1) % 3 == 0 && orangeCounter != 0) || ((orangeCounter - 2) % 3 == 0 && orangeCounter != 0))
                {
                    var costOfOrangesWithDiscount = cartDiscountResponse.CalculateDiscountManager(Oranges, CostOfOrange, orangeCounter);
                    response.TotalFruitPrice -= costOfOrangesWithDiscount;
                }
            }

            return response;
        }
    }
}
