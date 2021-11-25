namespace ShoppingCart
{
    public class CartDiscountCalculator
    {
        public decimal CalculateDiscountManager(string fruit, decimal fruitCost, int FruitCount)
        {
            if (fruit.ToLower() == "apples")
            {
                return CalculateDiscountForApples(fruitCost, FruitCount);
            }
            else
            {
                return CalculateDiscountForOranges(fruitCost, FruitCount); 
            }
        }

        private decimal CalculateDiscountForApples(decimal AppleCost, int appleCount)
        {
            var countOfApplesToRemove = appleCount / 2;
            return AppleCost * countOfApplesToRemove;
        }
        private decimal CalculateDiscountForOranges(decimal orangeCost, int orangeCount)
        {
            var countOfOrangesToRemove = orangeCount / 3;
            return orangeCost * countOfOrangesToRemove;

        }
    }
}
