namespace pizza_byte.api.Commons.Logic;

public static class Utils
{
    internal static decimal UpdatePriceBasedOnSize(string size)
    {
        return size switch
        {
            "s" => 6.99m,
            "m" => 8.99m,
            "l" => 10.99m,
            _ => 5.99m
        };
    }
}