using System.Collections;

namespace FinancePlanner.Shared.Common.Utilities.Result;

public sealed class ResultT<TValue> : Result
{
    private readonly TValue? _value;

    private ResultT(
        TValue value
    )
    {
        _value = value;
    }

    private ResultT(
        Error error
    ) : base(error)
    {
        _value = default;
    }

    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("Value can not be accessed when IsSuccess is false");

    public static implicit operator ResultT<TValue>(Error error)
    {
        return new ResultT<TValue>(error);
    }

    public static implicit operator ResultT<TValue>(TValue value)
    {
        return new ResultT<TValue>(value);
    }

    public static ResultT<TValue> Success(TValue value)
    {
        return new ResultT<TValue>(value);
    }

    public new static ResultT<TValue> Failure(Error error)
    {
        return new ResultT<TValue>(error);
    }

    public override bool Equals(object? obj)
    {
        var other = obj as ResultT<TValue>;
        if (other == null) return false;

        if (IsSuccess && Value != null)
        {
            if (Value is IList && other.Value is IList)
            {
                var thisListValue = (IList)Value;
                var otherListValue = (IList)Value;

                if (!thisListValue.Equals(otherListValue))
                    return false;
            }
            else if (!Value.Equals(other.Value))
            {
                return false;
            }
        }

        return base.Equals(other);
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}