public class AcousticGuitar : Guitar<AcousticGuitar>,ICloneable
{
    public string BodyMaterial { get; set; }
    
    public override void Play()
    {
        Console.WriteLine("Sound of the acoustic guitar");
    }

    public object Clone()
    {
        return new AcousticGuitar()
        {
            BodyMaterial = this.BodyMaterial
        };
    }
}