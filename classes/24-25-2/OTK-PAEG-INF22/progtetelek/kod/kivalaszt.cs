static int Kivalaszt<T>(int elemszam, T[] elemek, Func<T[], int, bool> Feltetel)
{
    int ind = 0;
    while(!Feltetel(elemek,ind))
    {
        ind++;
    }
    return ind;
}