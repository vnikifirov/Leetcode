using System.Text;

static string DiscountPrices(string sentence, int discount)
{
    var splitedSentence = sentence.Split(' ');
    var discounts = new StringBuilder();

    foreach (var price in splitedSentence)
    {
        if (price.StartsWith("$") && price.Length > 1 && decimal.TryParse(price.Substring(1), out decimal value))
        {
            decimal discValue = (value * discount) / 100;
            discounts.AppendJoin(" ", (value - discValue).ToString("f2"));
        }
        else
        {
            discounts.AppendJoin(" ", price);
        }

    }

    return discounts.ToString().Substring(1);
}

// See https://aka.ms/new-console-template for more information
Console.WriteLine(DiscountPrices("1 2 $3 4 $5 $6 7 8$ $9 $10$", 100));

