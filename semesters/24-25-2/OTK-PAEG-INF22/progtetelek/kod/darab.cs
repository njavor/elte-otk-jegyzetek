static int Darab<T>(int elemszam, T[] elemek, Func<T[], int, bool> Feltetel)
{
    int db = 0;
    for (int i = 0; i < elemszam; i++)
    {
        if (Feltetel(elemek, i))
        {
            db++;
        }
    }
    return db;
}