class MultihalmazElem
{
    public int ertek, multi;
    public MultihalmazElem(int ertek, int multi)
    {
        this.ertek = ertek;
        this.multi = multi;
    }
    public override string ToString()
    {
        return $"{ertek} {multi}";
    }
}
class Multihalmaz
{
    int MaxDb = 100;
    int db;
    MultihalmazElem[] elemek;

    public Multihalmaz()
    {
        db = 0;
        elemek = new MultihalmazElem[MaxDb];
    }


    public void Beolvasas()
    {
        string[] sor = Console.ReadLine().Split();
        db = int.Parse(sor[0]);
        for (int i = 0; i < db; i++)
        {
            elemek[i] = new MultihalmazElem(int.Parse(sor[i * 2 + 1]), int.Parse(sor[i * 2 + 2]));
        }
    }
    public void Rendezes()
    {
        for (int i = 0; i < db - 1; i++)
        {
            for (int j = i + 1; j < db; j++)
            {
                if (elemek[i].ertek > elemek[j].ertek)
                {
                    MultihalmazElem tmp = elemek[i];
                    elemek[i] = elemek[j];
                    elemek[j] = tmp;
                }
            }
        }
    }
    public void Kiiras()
    {
        Console.WriteLine(db);
        for (int i = 0; i < db; i++)
        {
            Console.Write(elemek[i] + " ");
        }
        Console.WriteLine();
    }


    public void Multihalmazba(MultihalmazElem elem)
    {
        int i = 0;
        while (i < db && elemek[i].ertek != elem.ertek) i++;

        if (i < db) elemek[i].multi += elem.multi;
        else
        {
            elemek[db] = elem;
            db++;
        }
    }
    public void Multihalmazbol(MultihalmazElem elem)
    {
        int i = 0;
        while (i < db && elemek[i].ertek != elem.ertek) i++;

        if (i < db)
        {
            elemek[i].multi -= elem.multi;
            if (elemek[i].multi <= 0)
            {
                elemek[i] = elemek[db - 1];
                db--;
            }
        }
    }
    public void Urites()
    {
        db = 0;
    }


    public bool ElemeE(int ertek)
    {
        int i = 0;
        while (i < db && elemek[i].ertek != ertek) i++;
        return i < db;
    }
    public bool BenneE(MultihalmazElem elem)
    {
        int i = 0;
        while (i < db && elemek[i].ertek != elem.ertek) i++;
        return i < db && elemek[i].multi >= elem.multi;
    }
    public bool ReszeE(Multihalmaz masik)
    {
        if (db > masik.db) return false;

        int i = 0;
        while (i < db && masik.BenneE(elemek[i])) i++;
        return i >= db;
    }
    public bool UresE()
    {
        return db == 0;
    }


    public Multihalmaz Unio(Multihalmaz masik)
    {
        Multihalmaz unio = new Multihalmaz();
        for (int i = 0; i < db; i++) unio.Multihalmazba(elemek[i]);
        for (int i = 0; i < masik.db; i++) unio.Multihalmazba(masik.elemek[i]);
        return unio;
    }
    public Multihalmaz Metszet(Multihalmaz masik)
    {
        Multihalmaz metszet = new Multihalmaz();
        for (int i = 0; i < this.db; i++)
        {
            int j = 0;
            while (j < masik.db && elemek[i].ertek != masik.elemek[j].ertek) j++;

            if (j < masik.db)
            {
                metszet.Multihalmazba(new MultihalmazElem(elemek[i].ertek, Math.Min(elemek[i].multi, masik.elemek[j].multi)));
            }
        }
        return metszet;
    }
    public Multihalmaz Kulonbseg(Multihalmaz masik)
    {
        Multihalmaz kulonbseg = new Multihalmaz();
        for (int i = 0; i < this.db; i++)
        {
            int j = 0;
            while (j < masik.db && elemek[i].ertek != masik.elemek[j].ertek) j++;

            if (j >= masik.db) kulonbseg.Multihalmazba(elemek[i]);
            else if (elemek[i].multi > masik.elemek[j].multi)
            {
                kulonbseg.Multihalmazba(new MultihalmazElem(elemek[i].ertek, elemek[i].multi - masik.elemek[j].multi));
            }
        }
        return kulonbseg;
    }
}