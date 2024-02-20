public abstract class Instrument<T> : IMyCloneable<T>
{
    public string Name { get; set; }
    public abstract void Play();

    public T MyClone()
    {
        return (T)this.MemberwiseClone();
    }
}