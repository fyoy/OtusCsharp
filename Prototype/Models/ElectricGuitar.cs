public class ElectricGuitar : Guitar<ElectricGuitar>,ICloneable
{
    public string Type { get; set; }

    public override void Play()
    {
        Console.WriteLine("Sound of the electric guitar");
    }
    public object Clone()
    {
        return new ElectricGuitar()
        {
            Type = this.Type
        };
    }
}