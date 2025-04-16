static Tki[] Masol<Tbe, Tki>(int elemszam, Tbe[] elemek, Func<Tbe[], int, Tki> Fuggveny)
{
    Tki[] fvelemek = new Tki[elemszam];
    for (int i = 0; i < elemszam; i++)
    {
        fvelemek[i] = Fuggveny(elemek, i);
    }
    return fvelemek;
}