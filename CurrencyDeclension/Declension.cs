using System;

public class Declension
{
    public static string FormatCurrency(int amount, string currency)
    {
        string result = currency;
        var words = currency.Split(' ');
        string baseCurrency = words[0];
        string declinedBaseCurrency = DeclineWord(amount, baseCurrency);

        if (words.Length > 1)
        {
            string additionalPart = words[1];
            string declinedAdditionalPart = DeclineWord(amount, additionalPart);
            result = $"{declinedBaseCurrency} {declinedAdditionalPart}";
        }
        else
            result = declinedBaseCurrency;

        return result;
    }

    private static string DeclineWord(int amount, string word)
    {
        int mod10 = amount % 10;
        int mod100 = amount % 100;

        if (mod100 >= 11 && mod100 <= 19)
            return GetPluralForm(word, 3);

        switch (mod10)
        {
            case 1:
                return GetPluralForm(word, 1);
            case 2:
            case 3:
            case 4:
                return GetPluralForm(word, 2);
            default:
                return GetPluralForm(word, 3);
        }
    }

    private static string GetPluralForm(string word, int form)
    {
        if (word.Equals("Российский", StringComparison.OrdinalIgnoreCase))
        {
            switch (form)
            {
                case 1: return "Российский";
                case 2: return "Российских";
                default: return "Российских";
            };
        }
        else if (word.Equals("рубль", StringComparison.OrdinalIgnoreCase))
        {
            switch (form)
            {
                case 1: return "рубль";
                case 2: return "рубля";
                default: return "рублей";
            };
        }
        else if (word.Equals("Доллар", StringComparison.OrdinalIgnoreCase))
        {
            switch (form)
            {
                case 1: return "Доллар";
                case 2: return "Доллара";
                default: return "Долларов";
            };
        }
        else if (word.Equals("США", StringComparison.OrdinalIgnoreCase))
        {
            return "США";
        }
        else if (word.Equals("Евро", StringComparison.OrdinalIgnoreCase))
        {
            return "Евро";
        }
        else if (word.Equals("Казахский", StringComparison.OrdinalIgnoreCase))
        {
            switch (form)
            {
                case 1: return "Казахский";
                case 2: return "Казахских";
                default: return "Казахских";
            };
        }
        else if (word.Equals("тенге", StringComparison.OrdinalIgnoreCase))
        {
            return "тенге";
        }
        else if (word.Equals("Китайский", StringComparison.OrdinalIgnoreCase))
        {
            switch (form)
            {
                case 1: return "Китайский";
                case 2: return "Китайских";
                default: return "Китайских";
            };
        }
        else if (word.Equals("юань", StringComparison.OrdinalIgnoreCase))
        {
            switch (form)
            {
                case 1: return "юань";
                case 2: return "юаня";
                default: return "юаней";
            };
        }

        return word;
    }
}