namespace MoneyTracker.Common.Utilities.MoneyUtil;

public class Money
{
    private Money(decimal amount)
    {
        Amount = amount;
    }

    public decimal Amount { get; }

    public static Money Zero { get; } = new(0);

    public static Money From(decimal amount)
    {
        int numberOfDecimalPlaces = BitConverter.GetBytes(decimal.GetBits(amount)[3])[2];
        if (numberOfDecimalPlaces > 2)
            throw new InvalidDataException($"Money value has too many decimal places: {amount}");
        if (amount < 0) throw new InvalidDataException($"Money value cannot be negative: {amount}");

        return new Money(amount);
    }

    public static Money From(string amount)
    {
        if (!decimal.TryParse(amount, out var tmpAmount))
            throw new InvalidDataException($"Money value must be a valid number: {amount}");

        return From(tmpAmount);
    }

    public static Money From(Money money)
    {
        return new Money(money.Amount);
    }

    public static Money operator /(Money money1, decimal divisor)
    {
        return new Money(decimal.Round(money1.Amount / divisor, 2, MidpointRounding.ToNegativeInfinity));
    }

    public static Money operator *(Money money1, decimal multiplier)
    {
        return new Money(decimal.Round(money1.Amount * multiplier, 2, MidpointRounding.ToNegativeInfinity));
    }

    public static Money operator +(Money money1, Money money2)
    {
        return new Money(money1.Amount + money2.Amount);
    }

    public static Money operator -(Money money1, Money money2)
    {
        return new Money(money1.Amount - money2.Amount);
    }

    public static Money operator /(Money money1, Percentage divisor)
    {
        return new Money(decimal.Round(money1.Amount / divisor.Value, 2, MidpointRounding.ToNegativeInfinity));
    }

    public static Money operator *(Money money1, Percentage multiplier)
    {
        return new Money(decimal.Round(money1.Amount * multiplier.Value, 2, MidpointRounding.ToNegativeInfinity));
    }

    public static bool operator <(Money money1, Money money2)
    {
        return money1.Amount < money2.Amount;
    }

    public static bool operator >(Money money1, Money money2)
    {
        return money1.Amount > money2.Amount;
    }

    public static bool operator <=(Money money1, Money money2)
    {
        return money1.Amount <= money2.Amount;
    }

    public static bool operator >=(Money money1, Money money2)
    {
        return money1.Amount > money2.Amount;
    }

    public static bool operator <(Money money1, int money2)
    {
        return money1.Amount < money2;
    }

    public static bool operator >(Money money1, int money2)
    {
        return money1.Amount >= money2;
    }

    public static bool operator <=(Money money1, decimal money2)
    {
        return money1.Amount <= money2;
    }

    public static bool operator >=(Money money1, decimal money2)
    {
        return money1.Amount >= money2;
    }

    public static Money Max(Money val1, Money val2)
    {
        return val1.Amount >= val2.Amount ? val1 : val2;
    }

    public static Money Min(Money val1, Money val2)
    {
        return val1.Amount <= val2.Amount ? val1 : val2;
    }

    public override bool Equals(object? obj)
    {
        var other = obj as Money;
        if (other == null)
            return false;
        return Amount == other.Amount;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Amount);
    }
}