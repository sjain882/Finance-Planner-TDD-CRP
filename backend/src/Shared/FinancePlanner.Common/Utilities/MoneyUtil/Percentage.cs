namespace FinancePlanner.Common.Utilities.MoneyUtil;

public class Percentage
{
    private Percentage(decimal percentage)
    {
        Value = percentage;
    }

    public decimal Value { get; }

    public static Percentage From(decimal percentage)
    {
        return new Percentage(percentage / 100);
    }

    public override bool Equals(object? obj)
    {
        var other = obj as Percentage;
        if (other == null) return false;
        return Value == other.Value;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value);
    }
}