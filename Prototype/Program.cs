TestIMyCloneable();
TestICloneable();

static void TestICloneable()
{
    var elec = new ElectricGuitar();
    var acos = new AcousticGuitar();

    var elecClone = (ElectricGuitar)elec.Clone();
    elecClone.Play();

    var acosClone = (AcousticGuitar)acos.Clone();
    acosClone.Play();
}

static void TestIMyCloneable()
{
    AcousticGuitar a = new();

    a.MyClone().Play();

    ElectricGuitar e = new();

    e.MyClone().Play();
};

