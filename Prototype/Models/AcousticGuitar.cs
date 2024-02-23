public class AcousticGuitar : Guitar, ICloneable
{
    public string BodyMaterial { get; set; }

    public override void Play()
    {
        Console.WriteLine("Sound of the acoustic guitar");
    }

    public object Clone()
    {
        var baseGuitar = (Guitar)base.Clone();

        return new AcousticGuitar()
        {
            Name = baseGuitar.Name,
            NumberOfStrings = baseGuitar.NumberOfStrings,
            BodyMaterial = this.BodyMaterial
        };
    }
}