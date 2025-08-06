static (int,int[]) KivalogatInd<T>(int elemszam, T[] elemek, Func<T[], int, bool> Feltetel)
{
    (int db, int[] kivelemek) = (0, new int[elemszam]);
    for(int i=0;i<elemszam;i++)
    {
        if(Feltetel(elemek,i))
        {
            kivelemek[db] = i;
            db++;
        }
    }
    return (db,kivelemek);
}

static (int,T[]) KivalogatElem<T>(int elemszam, T[] elemek, Func<T[], int, bool> Feltetel)
{
    (int db, T[] kivelemek) = (0, new T[elemszam]);
    for(int i=0;i<elemszam;i++)
    {
        if(Feltetel(elemek,i))
        {
            kivelemek[db] = elemek[i];
            db++;
        }
    }
    return (db,kivelemek);
}