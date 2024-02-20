TestIMyCloneable();
TestICloneable();

static void TestICloneable()
{
    ElectricGuitar electricGuitar = new();
    AcousticGuitar acousticGuitar = new();

    var electricClone = (ElectricGuitar)electricGuitar.Clone();
    electricClone.Play();

    var acousticClone = (AcousticGuitar)acousticGuitar.Clone();
    acousticClone.Play();
}

static void TestIMyCloneable()
{
    new AcousticGuitar().MyClone().Play();
    new ElectricGuitar().MyClone().Play();
};

