static (bool,int) Keres<T>(int elemszam, T[] elemek, Func<T[], int, bool> Feltetel)
{
    int ind = 0;
    while(ind < elemszam && !Feltetel(elemek,ind))
    {
        ind++;
    }
    bool van = ind < elemszam;
    return (van, ind);
}