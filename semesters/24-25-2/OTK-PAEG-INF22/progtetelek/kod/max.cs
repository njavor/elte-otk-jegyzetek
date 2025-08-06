static (int, int) MaxEgesz(int elemszam, int[] elemek)
{
	int maxhely = 0;
    int maxert = elemek[0];
    for (int i = 1; i < elemszam; i++)
    {
		if (elemek[i] > maxert)
        {
			maxhely = i;
			maxert = elemek[i];
        }
    }
    return (maxhely, maxert);
}