namespace Simulator;

public static class Validator
{
    public static int Limiter(int value, int min, int max)
    {
        return Math.Max(min, Math.Min(max, value));
    }

    public static string Shortener(string value, int min, int max, char placeholder)
    {
        value = value.Trim();
        if (value.Length < min)
            value = value.PadRight(min, placeholder);
        else if (value.Length > max)
            value = value.Substring(0, max).TrimEnd();

        return value;
    }
}
