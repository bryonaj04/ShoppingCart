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
                if (AllowedFruits.Contains(fruit.ToLower()) && fruit.ToLower() == Oranges)
                {
                    listOfFruitPrices.Add(CostOfOrange);

                }

                else if (AllowedFruits.Contains(fruit.ToLower()) && fruit.ToLower() == Apples)

                {

                    listOfFruitPrices.Add(CostOfApple);
                }

                else
                {
                    response.ErrorMessage = $"You have selected {fruit}. You can only purchase {string.Join(" and ", AllowedFruits)} from Andy's Fruit Cart";
                    response.TotalFruitPrice = listOfFruitPrices.Sum();
                    Console.WriteLine(response.ErrorMessage);
                    return response;

                }

            }
            response.TotalFruitPrice = listOfFruitPrices.Sum();
            return response;
        }

    }
}
