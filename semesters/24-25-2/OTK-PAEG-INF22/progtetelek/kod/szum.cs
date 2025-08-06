static int SzumEgesz(int elemszam, int[] elemek, Func<int[], int, bool> Feltetel)
{
    int ossz = 0;
    for (int i = 0; i < elemszam; i++)
    {
        if (Feltetel(elemek, i))
        {
            ossz += elemek[i];
        }
    }
    return ossz;
}