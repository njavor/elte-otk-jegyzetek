static bool Van<T>(int elemszam, T[] elemek, Func<T[], int, bool> Feltetel)
{
    int i = 0;
    while(i<elemszam && !Feltetel(elemek,i))
    {
        i++;
    }
    return i<elemszam;
}