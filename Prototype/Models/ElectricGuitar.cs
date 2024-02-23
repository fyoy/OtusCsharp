public class ElectricGuitar : Guitar, ICloneable
{
    public string Type { get; set; }

    public override void Play()
    {
        Console.WriteLine("Sound of the electric guitar");
    }
    public object Clone()
    {
        var baseGuitar = (Guitar)base.Clone();

        return new ElectricGuitar()
        {
            Name = baseGuitar.Name,
            NumberOfStrings = baseGuitar.NumberOfStrings,   
            Type = this.Type
        };
    }
}