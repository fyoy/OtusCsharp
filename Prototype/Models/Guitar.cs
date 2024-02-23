public class Guitar : Instrument<Guitar>, ICloneable
{
    public int NumberOfStrings { get; set; }
    public override void Play()
    {
        Console.WriteLine("Sound of the guitar");
    }

    public object Clone()
    {
        var i = (Instrument<Guitar>)base.MyClone();

        return new Guitar()
        {
            Name = i.Name,
            NumberOfStrings = this.NumberOfStrings
        };
    }
}