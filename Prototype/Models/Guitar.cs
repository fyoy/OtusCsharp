public class Guitar<T> : Instrument<T>, ICloneable
{
    public int NumberOfStrings { get; set; }

    public override void Play()
    {
        Console.WriteLine("Sound of the guitar");
    }

    public object Clone()
    {
        return new Guitar<T>()
        {
            NumberOfStrings = this.NumberOfStrings
        };
    }
}