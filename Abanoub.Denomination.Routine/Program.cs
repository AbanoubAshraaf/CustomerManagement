using Abanoub.Denomination.Routine;

List<int> amounts = new List<int> { 30, 50, 60, 80, 140, 230, 370, 610, 980 };
foreach (var amount in amounts)
{
    Console.WriteLine($"Possible combinations for {amount} EUR:");
    List<List<Cartridge>> combinations = PayoutDenominations.getCombinations(amount, 1000);

    foreach (var combination in combinations)
    {
        string output = "";
        foreach (var item in combination)
        {
            output += $"{item.amount}*{item.value} EUR + ";
        }
        output = output.Substring(0, output.Length - 3);
        Console.WriteLine(output);
    }
    Console.WriteLine();

}