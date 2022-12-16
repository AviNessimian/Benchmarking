namespace Benchmarking.Equals;

class TestModel
{
    public string Prop1 { get; init; }
    public string Prop2 { get; init; }
    public string Prop3 { get; init; }
    public string Prop4 { get; init; }
    public string Prop5 { get; init; }


    public override bool Equals(object? obj)
    {
        var other = obj as TestModel;
        if(other == null) return false;

        return
            ((string.IsNullOrEmpty(Prop1) && string.IsNullOrEmpty(other.Prop1)) || (Prop1 == other.Prop1))
            &&
            ((string.IsNullOrEmpty(Prop2) && string.IsNullOrEmpty(other.Prop2)) || (Prop2 == other.Prop2))
            &&
            ((string.IsNullOrEmpty(Prop3) && string.IsNullOrEmpty(other.Prop3)) || (Prop3 == other.Prop3))
            &&
            ((string.IsNullOrEmpty(Prop4) && string.IsNullOrEmpty(other.Prop4)) || (Prop4 == other.Prop4))
            &&
            ((string.IsNullOrEmpty(Prop5) && string.IsNullOrEmpty(other.Prop5)) || (Prop5 == other.Prop5));

    }

    public override int GetHashCode()
    {
        return HashCode.Combine(
            string.IsNullOrEmpty(Prop1) ? string.Empty : Prop1,
            string.IsNullOrEmpty(Prop2) ? string.Empty : Prop2,
            string.IsNullOrEmpty(Prop3) ? string.Empty : Prop3,
            string.IsNullOrEmpty(Prop4) ? string.Empty : Prop4,
            string.IsNullOrEmpty(Prop5) ? string.Empty : Prop5
        );
    }
}