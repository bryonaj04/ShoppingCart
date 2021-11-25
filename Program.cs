using System;
using System.Collections.Generic;
using System.Globalization;

namespace ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            var itemsToBuy = new List<string>();

            Console.WriteLine("Welcome to Andy's Fruity Shopping Cart!");
            Console.WriteLine("What would you like to buy?");

            string item;
            int ctr = 0;
            do
            {
                ctr++;
                item = Console.ReadLine();
                if (!string.IsNullOrEmpty(item))
                {
                    itemsToBuy.Add(item);
                }
            } while (!string.IsNullOrEmpty(item));

            var cartCalculator = new CartCalculator();
            var calculateResponse = cartCalculator.Calculate(itemsToBuy);

            if (calculateResponse.ErrorMessage != null)
            {
                Console.WriteLine(calculateResponse.ErrorMessage);
                
            }
            else
            {
                Console.WriteLine($"Your total is {calculateResponse.TotalFruitPrice.ToString("C", CultureInfo.CurrentCulture)}");
            }
        }
    }
}
