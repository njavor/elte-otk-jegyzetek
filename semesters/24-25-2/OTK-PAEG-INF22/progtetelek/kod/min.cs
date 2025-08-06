static (int, int) MinEgesz(int elemszam, int[] elemek)
{
	int minhely = 0;
    int minert = elemek[0];
    for (int i = 1; i < elemszam; i++)
    {
		if (elemek[i] < minert)
        {
			minhely = i;
			minert = elemek[i];
        }
    }
    return (minhely, minert);
}