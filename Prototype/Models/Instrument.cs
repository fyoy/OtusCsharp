public abstract class Instrument<T> : IMyCloneable<T>
{
    public string Name { get; set; }
    public abstract void Play();

    public virtual T MyClone()
    {
        return (T)this.MemberwiseClone();
    }
}
