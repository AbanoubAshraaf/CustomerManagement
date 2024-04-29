namespace Abanoub.Denomination.Routine
{
    public static class PayoutDenominations
    {
        private static readonly List<int> cartridges = new List<int> { 100, 50, 10 };
        public static List<List<Cartridge>> getCombinations(int amount, int last)
        {
            if (amount == 0) return new List<List<Cartridge>>();

            var result = new List<List<Cartridge>>();
            foreach (var cartridge in cartridges)
            {
                int currentAmount = amount;
                while (currentAmount >= cartridge && cartridge < last)
                {
                    currentAmount -= cartridge;
                    int count = (amount - currentAmount) / cartridge;
                    if (currentAmount == 0)
                    {
                        result.Add(new List<Cartridge> { new Cartridge(cartridge, count) });
                        continue;
                    }
                    var curResult = getCombinations(currentAmount, cartridge);
                    var subList = new List<List<Cartridge>>();
                    foreach (var cur in curResult)
                    {
                        cur.Add(new Cartridge(cartridge, count));
                        subList.Add(cur);
                    }
                    result.AddRange(subList);
                }
            }
            return result;
        }
    }
}
